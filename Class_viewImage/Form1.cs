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
        static Mutex mutex;

        public form()
        {
            InitializeComponent();
        }

        private static void kill()
        {
            
            bool createdNew;

            mutex = new Mutex(true, "imageviewer", out createdNew);

            if (!createdNew)
            {
                var currentProcess = Process.GetCurrentProcess();
                var runningProcess = Process.GetProcessesByName(currentProcess.ProcessName);

                foreach (var item in runningProcess)
                {
                    if (item.Id != currentProcess.Id)  item.Kill(); 

                }
                                            


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kill();
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

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            mutex.ReleaseMutex();
            mutex.Close();
        }
    }
}
