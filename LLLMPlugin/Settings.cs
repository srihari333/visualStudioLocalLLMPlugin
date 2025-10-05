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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            aiserver.Text = Properties.Settings.Default.aiserver;
            url.Text = Properties.Settings.Default.url;
            model.Text = Properties.Settings.Default.model;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.aiserver = aiserver.Text;  
            Properties.Settings.Default.url = url.Text; 
            Properties.Settings.Default.model = model.Text;  
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
