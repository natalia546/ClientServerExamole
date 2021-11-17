using AuthorizationExample.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorizationExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var authorizationControl = new AuthorizationControl();
            this.Controls.Add(authorizationControl);
            this.Size = new Size(authorizationControl.Size.Width, authorizationControl.Size.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
