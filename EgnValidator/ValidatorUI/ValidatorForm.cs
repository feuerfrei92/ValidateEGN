using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidatorService;

namespace ValidatorUI
{
    public partial class ValidatorForm : Form
    {
        private IDataDisplayer _displayer;

        public ValidatorForm(IDataDisplayer displayer)
        {
            InitializeComponent();
            _displayer = displayer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string egn = textBox1.Text;
            label1.Text = _displayer.ValidationMessage(egn);
            if (label1.Text.Equals(Consts.Success))
            {
                label1.ForeColor = Color.Green;
            }
            else
            {
                label1.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = string.Empty;
            label1.ForeColor = Color.Black;
        }
    }
}
