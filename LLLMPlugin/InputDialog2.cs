using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLLMPlugin
{
    public partial class InputDialog2 : Form
    {
        public string InputText { get; private set; }
        public InputDialog2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text;
            this.DialogResult = DialogResult.OK; // Formu OK olarak kapat
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Formu Cancel olarak kapat
            this.Close();
        }
    }
}
