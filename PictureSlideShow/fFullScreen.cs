using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureSlideShow
{
    public partial class fFullScreen : Form
    {
        //Initialize
        public fFullScreen()
        {
            InitializeComponent();
        }

        //Slide image autoproperty. Only a set is required.
        public Image Slide { set { this.PBFullScreen.Image = value; }}

        //Close on click.
        private void PBFullScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
