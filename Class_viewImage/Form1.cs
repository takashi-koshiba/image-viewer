using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace Class_viewImage
{
    public partial class form : Form
    {
        ClassVIewImage C_view;


        public form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            string[] cmds = System.Environment.GetCommandLineArgs();
           
            C_view = new ClassVIewImage(this,3, cmds);
            C_view.getFormSize(this.Size);

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            C_view.AddImageDrop(e);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            C_view.AddImageEnter(e);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            C_view.reViewImage();
            C_view.getFormSize(this.Size);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            C_view.reViewImage();
            C_view.getFormSize(this.Size);
        }
        
    }
}
