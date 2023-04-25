using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_CA1
{
    public partial class ParentForm : Form
    {
        public Form1 form1;
        public Form2 form2;
        public Form3 form3;
        public ParentForm()
        {
            InitializeComponent();
            this.normalModeToolStripMenuItem.Click += new EventHandler(this.normalModeToolStripMenuItem_Click);
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }

        private void simulationModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void normalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(form1 != null)
            {
                form1.Show();
            } else
            {
                form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            }
        }

        private void safeDistanceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void safeDistanceSmartModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
