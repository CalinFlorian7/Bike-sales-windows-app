using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    public partial class Testare : Form
    {
        public Testare()
        {
            InitializeComponent();
           
            label1.Text= "0123456789  \nabcdefghijklmnopqrs";
            label1.Width = 60;
            using (Graphics g = label1.CreateGraphics())
            {
                SizeF size = g.MeasureString(label1.Text, label1.Font, label1.Width);

                // Update the height of the label to fit the text
                label1.Height = (int)Math.Ceiling(size.Height);
            }
            


        }

        private void Testare_Load(object sender, EventArgs e)
        {

        }
    }
}
