using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Class_viewImage
{
    public partial class  pic:PictureBox 
    {
        int i;
        public pic(int i)
        {
            this.i = i;


        }
        public int getI()
        {
            return this.i;
        }
    }
    public partial class menu1 : ToolStripMenuItem
    {
        public int i;
        public menu1(int i)
        {
            this.i = i;


        }

        public void get()
        {
            MessageBox.Show(i.ToString());
        }

        public int getI()
        {
            return this.i;
        }
    }
}
