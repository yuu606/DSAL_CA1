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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        //Close form 
        //=============================================================================
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form3 = null;
        }
        //=============================================================================

        //event handler when load button is clicked 
        //=============================================================================
        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when save button is clicked 
        //=============================================================================
        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when undo button is clicked 
        //=============================================================================
        private void buttonUndo_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when redo button is clicked 
        //=============================================================================
        private void buttonRedo_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when generate seats button is clicked 
        //=============================================================================
        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================


        //event handler when end sim. button is clicked 
        //=============================================================================
        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when reset sim. button is clicked 
        //=============================================================================
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================
    }
}
