using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLMPlugin
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

        private void InputDialog2_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(661, 172);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            txtInput.Location = new Point(12, 12);
            txtInput.Size = new Size(624, 39);


            btnStart.Location = new Point(12, 57);
            btnStart.Size = new Size(307, 43);

            btnEnd.Location = new Point(321, 57);
            btnEnd.Size = new Size(307, 43);
        }
    }
}
