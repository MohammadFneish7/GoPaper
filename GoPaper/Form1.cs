using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Drawing;
using NAPS2.Wia;
using Emgu.CV.Reg;
using System;

namespace GoPaper
{
    public partial class Form1 : Form
    {
        private byte[]? outputfile;

        public Form1()
        {
            InitializeComponent();
        }

        private void Print(byte[] byteArray)
        {
            BitArray bitArray = new BitArray(byteArray);

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings = new PageSettings()
            {
                Margins = new Margins(0, 0, 0, 0),
                PaperSize = new PaperSize("A4", 827, 1169),
                PrinterResolution = new PrinterResolution() { Kind = PrinterResolutionKind.High },
                Color = false,
                Landscape = false
            };
            pd.PrintPage += (sender, args) =>
            {
                // Create a new font
                Font font = new Font("Arial", 11);

                StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                };

                args.Graphics?.DrawString("█", font, Brushes.Black, new RectangleF(0, 0, 827, 1169), sf);

                var chunkSize = 185;
                var contentParts = new List<string>();
                int lettersCount = 3;
                int rowsCount = 0;
                string row = "";


                foreach (bool bit in bitArray)
                {
                    if (bit)
                        row += ",";
                    else
                        row += ".";
                    lettersCount++;

                    if (lettersCount == chunkSize)
                    {
                        contentParts.Add(row);
                        rowsCount++;
                        if (rowsCount < 2)
                            lettersCount = 3;
                        else
                            lettersCount = 0;
                        row = "";
                    }
                }

                if (!string.IsNullOrEmpty(row))
                {
                    contentParts.Add(row);
                }

                var last_i = 0;
                // Print the text at the top-left corner of the page
                var len = 0;
                for (int i = 0; i < contentParts.Count(); i++)
                {
                    last_i = i;
                    len += contentParts[i].Length;
                    args.Graphics?.DrawString(contentParts[i], font, Brushes.Black, new RectangleF(i < 2 ? 13.3f : 0, (i * 8) - 7, 827, 1169), sf);
                }
                args.Graphics?.DrawString("▃", font, Brushes.Black, new RectangleF(780, (last_i * 8) - 6, 827, 1169), sf);
            };

            PrintDialog pdlg = new PrintDialog();
            pdlg.Document = pd;
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                pdlg.Document.Print();  // This will print the document
            }
        }

        private void ReadImage(Bitmap bitmap)
        {
            try
            {
                // Read the image file
                Image<Bgr, byte> img = bitmap.ToImage<Bgr, byte>();

                // Convert the image to grayscale
                Image<Gray, byte> gray = img.Convert<Gray, byte>();

                // Threshold the image to get a binary image
                Image<Gray, byte> binary = gray.ThresholdBinary(new Gray(150), new Gray(255));

                // Initialize storage for contours
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                // Find contours
                CvInvoke.FindContours(binary, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

                MemoryStream ms = new MemoryStream();
                BitArray bitArray = new BitArray(8);
                int currentBit = 0;
                // Draw contours
                for (int i = 0; i < contours.Size; i++)
                {
                    var boundingBox = CvInvoke.BoundingRectangle(contours[i]);
                    var area = boundingBox.Width * boundingBox.Height;
                    if (area >= 15 && area <= 160)
                    {
                        if (area < 35)
                            bitArray[currentBit] = false;
                        else
                            bitArray[currentBit] = true;
                        currentBit++;
                        if (currentBit == 8)
                        {
                            currentBit = 0;
                            byte[] bytes = new byte[1];
                            bitArray.CopyTo(bytes, 0);
                            ms.Write(bytes);
                            bitArray = new BitArray(8);
                        }
                    }
                    Debug.WriteLine(area);
                    CvInvoke.DrawContours(img, contours, i, new MCvScalar(0, 0, 255), 1);
                }
                var bmp = img.ToBitmap();
                pictureBox1.Image = bmp;
                outputfile = ms.ToArray();
            }
            catch (Exception)
            {
                MessageBox.Show("فشل في إعادة بناء الملف");
            }
        }

        private byte[] encrypt(byte[] buffer)
        {
            return buffer;
        }

        private byte[] decrypt(byte[] buffer)
        {
            return buffer;
        }

        public byte[] Compress(byte[] buffer, string? extension = null)
        {
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("invalid buffer");
            }
            byte[] header = new byte[4];
            byte[] extensionBytes;
            if (string.IsNullOrEmpty(extension))
            {
                extension = "txt";
            }

            extension = extension.Replace(".", "");
            extensionBytes = Encoding.ASCII.GetBytes(extension);
            Buffer.BlockCopy(extensionBytes, 0, header, 0, extensionBytes.Length);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer,0, buffer.Length);
            }
            byte[] data = encrypt(ms.ToArray());
            byte[] result = new byte[4 + data.Length];

            Buffer.BlockCopy(header, 0, result, 0, header.Length);
            Buffer.BlockCopy(data, 0, result, header.Length, data.Length);

            return result;
        }

        public Tuple<byte[], string> Decompress(byte[] buffer)
        {
            if (buffer == null || buffer.Length < 4)
            {
                throw new ArgumentException("invalid buffer");
            }
            byte[] extension = new byte[4];
            byte[] data = new byte[buffer.Length-4];
            Buffer.BlockCopy(buffer, 0, extension, 0, 4);
            Buffer.BlockCopy(buffer, 4, data, 0, buffer.Length - 4);
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                data = decrypt(resultStream.ToArray());
            }
            var ext = Encoding.ASCII.GetString(extension).Trim();
            return new Tuple<byte[], string>(data, string.IsNullOrEmpty(ext) ? "txt" : ext.Trim());
        }

        private void radfile_CheckedChanged(object sender, EventArgs e)
        {
            if (radfile.Checked)
            {
                btnbrowseSend.Enabled = true;
                txtInputtext.Enabled = false;
            }
            else
            {
                btnbrowseSend.Enabled = false;
                txtInputtext.Enabled = true;
            }
        }

        private void btnbrowseSend_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Multiselect = false
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtinputfile.Text = dlg.FileName;
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            string? extension = null;
            if (radfile.Checked)
            {
                if (string.IsNullOrEmpty(txtinputfile.Text))
                {
                    MessageBox.Show("الرجاء إختيار ملف أوّلاً");
                    return;
                }
                extension = Path.GetExtension(txtinputfile.Text);
                bytes = File.ReadAllBytes(txtinputfile.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(txtInputtext.Text))
                {
                    MessageBox.Show("الرجاء إدخال نص أوّلاً");
                    return;
                }
                bytes = Encoding.UTF8.GetBytes(txtInputtext.Text.Trim());
            }
            if (bytes != null && bytes.Length > 0)
            {
                if (bytes.Length > 10000000)
                {
                    MessageBox.Show("حجم الملف بعد الضغط لا يجب أن يتعدّى 3051 بايت");
                    return;
                }
                else
                {
                    bytes = Compress(bytes, extension);
                    if (bytes.Length > 3051)
                    {
                        MessageBox.Show("حجم الملف بعد الضغط لا يجب أن يتعدّى 3051 بايت");
                        return;
                    }
                    else
                    {
                        Print(bytes);
                    }
                }
            }
            else
            {
                MessageBox.Show("فشل في قراءة الملف");
                return;
            }
        }

        private void btnbrowserecieve_Click(object sender, EventArgs e)
        {
            try
            {
                outputfile = null;
                pictureBox1.Image = null;

                var dlg = new OpenFileDialog()
                {
                    Multiselect = false
                };

                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;

                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }

                dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

                dlg.DefaultExt = ".png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtinputfilerecieve.Text = dlg.FileName;
                    ReadImage(new Bitmap(dlg.FileName));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("فشل في قراءة الملف");
            }
        }

        private void radfilerecieve_CheckedChanged(object sender, EventArgs e)
        {
            if (radfilerecieve.Checked)
            {
                btnbrowserecieve.Enabled = true;
                btnscan.Enabled = false;
            }
            else
            {
                btnbrowserecieve.Enabled = false;
                btnscan.Enabled = true;
            }
        }

        private void btnscan_Click(object sender, EventArgs e)
        {
            try
            {
                outputfile = null;
                pictureBox1.Image = null;

                using var deviceManager = new WiaDeviceManager();

                // Prompt the user to select a scanner
                using var device = deviceManager.PromptForDevice();

                // Select either "Flatbed" or "Feeder"
                var item = device.FindSubItem("Feeder");
                if(item == null)
                {
                    item = device.FindSubItem("Flatbed");
                }
                using var feeder = item;

                feeder.SetProperty(WiaPropertyId.IPS_PAGES,
                                 WiaPropertyValue.FRONT_FIRST);

                // Set up the scan
                using var transfer = item.StartTransfer();
                transfer.PageScanned += (sender, args) =>
                {
                    using (args.Stream)
                    {
                        ReadImage(new Bitmap(args.Stream));
                    }
                };

                transfer.Download();
            }
            catch (Exception)
            {
                MessageBox.Show("فشل في قراءة الملف");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (outputfile == null || outputfile.Length == 0)
            {
                MessageBox.Show("الرجاء إختيار أو مسح ملف أوّلاً");
                return;
            }

            try
            {
                var result = Decompress(outputfile);
                var sfdlg = new SaveFileDialog()
                {
                    FileName = $"{DateTime.Now.Millisecond}.{result.Item2}"
                };
                if (sfdlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfdlg.FileName, result.Item1);
                }
                MessageBox.Show("تم حفظ الملف بنجاح");
            }
            catch (Exception)
            {
                MessageBox.Show("فشل في حفظ الملف");
            }
        }
    }
}