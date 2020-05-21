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
        private Form1 parenForm;                                            //Required for calling the skip method.
        
        //Initialize
        public fFullScreen(Form1 form1)
        {
            InitializeComponent();
            parenForm = form1;                                                          //Passing parent form so the skip method can be called.
        }

        //Slide image autoproperty. Only a set is required.
        public Image Slide { set { this.PBFullScreen.Image = value; }}

        //Close on click.
        private void PBFullScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Handle keyboard shortcuts.
        private void fFullScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Control)
            {
                parenForm.Skip(-1, "file");
            }
            else if (e.KeyCode == Keys.Right && e.Control)
            {
                parenForm.Skip(1, "file");
            }
            else if (e.KeyCode == Keys.Up && e.Control)
            {
                parenForm.Skip(1, "folder");
            }
            else if (e.KeyCode == Keys.Down && e.Control)
            {
                parenForm.Skip(-1, "folder");
            }
            else if (e.KeyCode == Keys.F4 && e.Control)
            {
                Application.Exit();
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                this.Close();
            }
        }
    }
}
