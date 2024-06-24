using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Class_viewImage
{
    class ClassVIewImage
    {

        string[] drags;
        int picturbox_count=0;
        static Size size;//フォームのサイズ
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> pictureBoxes2 = new List<PictureBox>();
        bool flag = true;

        form form;
        int max_x_count;

        PointF point;

        Point msP=new Point(3,3);
        float ratio = 1.0F;



        float x;

        float y;
        string[] args;
        Label label;
        ContextMenuStrip menu;
        ToolStripMenuItem tsi1;
        

        public ClassVIewImage(form form,int max_x_count,string[] args)
        {
            this.form = form;
            this.max_x_count = max_x_count;

            this.point.X = 0;
            this.point.Y = 0;
            this.tsi1 = new ToolStripMenuItem();
            this.menu = new ContextMenuStrip();
            this.args = args;
            tsi1.Text = "削除";
            menu.Items.Add(tsi1);
            tsi1.Click += del;


            if (args.Length > 1)
            {
                AddImageDropload(args);
            }
            //    
            
         
            
        }

        private void del(object sender, EventArgs e)
        {
            foreach (var item in pictureBoxes)
            {
                item.Image.Dispose();

                item.Dispose();
              
            }
            foreach (var item in pictureBoxes2)
            {

                item.Image.Dispose();
             
                item.Dispose();
            }
      
            pictureBoxes = new List<PictureBox>();
                pictureBoxes2 = new List<PictureBox>();
            //  item.Dispose();

          
            
            
        }

        public void AddImageEnter(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        public void AddImageDrop(DragEventArgs e)
        {
            drags =
            (string[])e.Data.GetData(DataFormats.FileDrop, false);

            int count_item = drags.Length;
            int i = pictureBoxes.Count + picturbox_count;
            

            foreach (var item in drags)
            {
                pictureBoxes.Add(new pic(i));
                pictureBoxes2.Add(new pic(i));
               
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Normal;

                pictureBoxes[i].Image = NewBitmap(new System.IO.FileInfo(item));
                pictureBoxes2[i].Image =pictureBoxes[i].Image;

                
                pictureBoxes[i].Width = size.Width / xcount(count_item);
                pictureBoxes[i].Height = size.Height / ycount(count_item);
                pictureBoxes[i].Location = new Point(pictureBoxes[i].Width * (i % this.max_x_count), pictureBoxes[i].Height * (int)Math.Floor((double)i / (double)this.max_x_count));
                pictureBoxes[i].DragDrop += PictureBox_drop;
                pictureBoxes[i].DragEnter += PictureboxDragEnter;
                pictureBoxes[i].MouseDown += PictureboxMousedown;
                pictureBoxes[i].MouseMove += PictureboxMousemove;
                pictureBoxes[i].MouseUp += picturebxomouseup;
                pictureBoxes[i].MouseWheel += PictureboxMouseWheel;
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[i].ContextMenuStrip = menu;
                pictureBoxes[i].MouseDoubleClick += ClassVIewImage_MouseDoubleClick1;

         //       int p= pictureBoxes[i].Image.Width;
                    pictureBoxes[i].Image = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                //  CreateGraphics(picturebox, ref _gPic);
                this.form.Controls.Add(pictureBoxes[i]);
                //CreateGraphics(pictureBoxes[i], ref _gPic);

                ToolStripMenuItem tsi2=new menu1(i);
                //tsi2.Text = i + "番目";
                //tsi2.Tag = i;
                //tsi2.Click += Tsi2_Click;
              

                tsi1.DropDownItems.Add(tsi2);
                i++;
            }
            reViewImage();

            //   pictureBox1.Image = System.Drawing.Image.FromFile(item);

        }  //y軸の画像の行数

     

        public void AddImageDropload(string[] args)
        {

       
            
            int count_item = args.Length-1;
            int i = pictureBoxes.Count + picturbox_count;
            
            for(int ii = 1; ii < args.Length; ii++)
            {


                pictureBoxes.Add(new pic(i));
                pictureBoxes2.Add(new pic(i));

                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Normal;

                pictureBoxes[i].Image = NewBitmap(new System.IO.FileInfo(args[ii]));
                pictureBoxes2[i].Image = pictureBoxes[i].Image;


                pictureBoxes[i].Width = 1000 / xcount(count_item);
                pictureBoxes[i].Height = 1000 / ycount(count_item);
                pictureBoxes[i].Location = new Point(pictureBoxes[i].Width * (i % this.max_x_count), pictureBoxes[i].Height * (int)Math.Floor((double)i / (double)this.max_x_count));
                pictureBoxes[i].DragDrop += PictureBox_drop;
                pictureBoxes[i].DragEnter += PictureboxDragEnter;
                pictureBoxes[i].MouseDown += PictureboxMousedown;
                pictureBoxes[i].MouseMove += PictureboxMousemove;
                pictureBoxes[i].MouseUp += picturebxomouseup;
                pictureBoxes[i].MouseWheel += PictureboxMouseWheel;
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[i].ContextMenuStrip = menu;
                pictureBoxes[i].MouseDoubleClick += ClassVIewImage_MouseDoubleClick1;
            //    MessageBox.Show(i.ToString());
                //       int p= pictureBoxes[i].Image.Width;
                pictureBoxes[i].Image = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);

                //  CreateGraphics(picturebox, ref _gPic);
                this.form.Controls.Add(pictureBoxes[i]);
                //CreateGraphics(pictureBoxes[i], ref _gPic);

                ToolStripMenuItem tsi2 = new menu1(i);
                //tsi2.Text = i + "番目";
                //tsi2.Tag = i;
                //tsi2.Click += Tsi2_Click;


                tsi1.DropDownItems.Add(tsi2);
                i++;
            }
        
            reViewImage();

            //   pictureBox1.Image = System.Drawing.Image.FromFile(item);

        }

        private void ClassVIewImage_MouseDoubleClick1(object sender, MouseEventArgs e)
        {
            if (flag)
            {

                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                flag = false;
            }
            else
            {
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.WindowState = FormWindowState.Normal;
                flag = true;
            }
        }

        private void Tsi2_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureboxMouseWheel(object sender, MouseEventArgs e)
        {
            // Scaling(1.2);
            int i = 0;
            float scale;
            if (e.Delta > 0)
            {
                scale = 1.2F;
          
            }
            else
            {
                scale =0.8F;
            }

            float MoveScale = scale - 1;

            //拡大の上限
            //if (imgbox1Viewer.ImgWidth > intputImgWidth*320) return;

            //位置を変える
            x += (float)((x - e.Location.X) * MoveScale);
            y += (float)((y - e.Location.Y) * MoveScale);

            DrawImage(x, y, pictureBoxes, pictureBoxes2, pictureBoxes.Count, scale, e.Location);
         //   DrawImage(pointx, pointy, pictureBoxes, pictureBoxes2, pictureBoxes.Count, MoveScale, e.Location);



        }

        private void picturebxomouseup(object sender, MouseEventArgs e)
        {
            //   x = x+ e.Location.X - point.X;
            //  imgPointy = imgPointy + e.Location.Y - pointy;
            // pointyy = e.Location.Y;
            if (e.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            
        }

        private void PictureboxMousemove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
             

                    x =e.X-point.X;
                    y = e.Y-point.Y;

                msP = e.Location;
           


          

                DrawImage(x, y, pictureBoxes, pictureBoxes2,pictureBoxes.Count,1.0F,e.Location);
                    
                

                //imgPointx = e.X - pointx;
             
            }

          

            //pointx = e.Location.X - pointx;
            //pointy = e.Location.Y;


        }

        private void PictureboxMousedown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point.X = e.X - x;
                point.Y = e.Y - y;
            }
            else if(e.Button==MouseButtons.Right)
            {

                //   menu.Show(e.Location);

               
            }
          

        }

        public int ycount(int count)
        {
            int i = (int)Math.Ceiling((double)count / (double)this.max_x_count);
            return i;
        }

        //x軸のの画像の数
        public int xcount(int count)
        {
            if (count > this.max_x_count)
            {
                return this.max_x_count;
            }
            else
            {
                return count;
            }

        }
        private void PictureboxDragEnter(object sender, DragEventArgs e)
        {
            AddImageEnter(e);

        }

        private void PictureBox_drop(object sender, DragEventArgs e)
        {
            AddImageDrop(e);

        }
        public void reViewImage()
        {
            int i = 0;
            int count_item = pictureBoxes.Count;
            foreach (var item in pictureBoxes)
            {
                pictureBoxes[i].Width = this.form.Size.Width / xcount(count_item);
                pictureBoxes[i].Height = this.form.Size.Height / ycount(count_item);
                pictureBoxes[i].Location = new Point(pictureBoxes[i].Width * (i % this.max_x_count), pictureBoxes[i].Height * (int)Math.Floor((double)i / (double)this.max_x_count));
                
                i++;
            }
            //CreateGraphics(item, ref _gPic);

            DrawImage(x, y, pictureBoxes, pictureBoxes2, pictureBoxes.Count, 1.0F, msP);
        }
        public void getFormSize(Size sized)
        {
            size = sized;
        }

        //すべてをbitmapに変換
        public  Bitmap NewBitmap(FileInfo fi)
        {
            Bitmap bitmap = null;
            try
            {
                bitmap = new Bitmap(fi.FullName);
            }
            catch (Exception)
            {

                using (var magickImages = new MagickImageCollection(fi))
                {
                    var ms = new System.IO.MemoryStream();
                    if (magickImages.Count > 1)
                    {
                        magickImages.Write(ms, MagickFormat.Gif);
                    }
                    else
                    {
                        magickImages.Write(ms, MagickFormat.Png);
                    }
                    bitmap?.Dispose();
                    bitmap = new Bitmap(ms);

                    bitmap.Tag = ms;
                }
            }
            return bitmap;
        }
   

        public void DrawImage(float x1, float y1, List<PictureBox> picturebox, List<PictureBox> picturebox2, int count,float ratio, PointF msPoint)
        {//DrawImage(imgPoint.X,imgPoint.Y, item,pictureBoxes2[i],pictureBoxes.Count,1.0F);
            try
            {
                int i = 0;
                foreach (var item in picturebox)
                {

                    // Ensure picturebox2 has a valid image
                    if (picturebox2[i].Image == null)
                        return;


                    double MoveScale = ratio - 1;
            
                    //拡大の上限
                    //if (imgbox1Viewer.ImgWidth > intputImgWidth*320) return;

                    //位置を変える
                  //  pointx += (float)((pointx - msPoint.X) * MoveScale);
                    //pointy += (float)((pointy - msPoint.Y) * MoveScale);

                    // Dispose of the old image to release resources
                    picturebox[i].Image?.Dispose();
                    float w, h, w2, h2, w3, h3;


                    if (pictureBoxes2[i].Image.Width > pictureBoxes2[i].Image.Height)
                    {
                        float arg = (float)pictureBoxes2[i].Image.Height / (float)pictureBoxes2[i].Image.Width;
                        w = (float)this.form.Size.Width * (float)this.ratio;
                        w2 = (float)(w * ratio) / xcount(count);
                        
                        h = w*arg;
                        h2 = (float)(h * ratio) / xcount(count);
                    }
                    else
                    {
                        float arg =  (float)pictureBoxes2[i].Image.Width/(float)pictureBoxes2[i].Image.Height ;
                        h = (float)this.form.Size.Height * (float)this.ratio;
                   
                        h2 = (float)(h * ratio) / ycount(count);
                        w = h * arg;
                        w2 = (float)(w * ratio) / ycount(count);
                    }
                  
          
          
                  


                    // Set interpolation mode
                    picturebox[i].Image = new Bitmap(picturebox[i].Width, picturebox[i].Height);
                    using (Graphics g = Graphics.FromImage(picturebox[i].Image))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                        // Draw the image directly on the existing PictureBox Image
                        g.DrawImage(picturebox2[i].Image, (float)x1, (float)y1, w2, h2);
                    }
                  //  imgPoint.X = (float)pointx;
                 //   imgPoint.Y = (float)pointy;
                    if (ratio != 1.0)
                    {
                    //    imgPointx = (float)imgPointx;
                    //    imgPointy = (float)imgPointy;
                    }

                    // Refresh the PictureBox to trigger the repaint
                    picturebox[i].Refresh();
                    i++;

                }

              

            
  
                //   this.ratio = ratio;
                this.ratio *= ratio;

            
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                Console.WriteLine("Error in DrawImage: " + ex.Message);
            }
        }


        public void CreateGraphics(PictureBox pic, ref Graphics g)
        {
            if (g != null)
            {
                g.Dispose();
                g = null;
            }
            if (pic.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }

            if ((pic.Width == 0) || (pic.Height == 0))
            {
                return;
            }

            pic.Image = new Bitmap(pic.Width, pic.Height);

            g = Graphics.FromImage(pic.Image);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            
        }


    }

}

