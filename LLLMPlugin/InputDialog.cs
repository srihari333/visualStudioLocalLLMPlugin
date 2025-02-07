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
    public partial class InputDialog : Form
    {
        public string InputText { get; private set; }
        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(661, 172);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            txtInput.Location = new Point(12, 12);
            txtInput.Size = new Size(624, 39);


            btnSend.Location = new Point(12, 57);
            btnSend.Size = new Size(307, 43);

            btnclose.Location = new Point(321, 57);
            btnclose.Size = new Size(307, 43);

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text;
            this.DialogResult = DialogResult.OK; // Formu OK olarak kapat
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Formu Cancel olarak kapat
            this.Close();
        }
    }
}
