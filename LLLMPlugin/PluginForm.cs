using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;

namespace LLMPlugin
{
    public partial class PluginForm : Form
    {

        public bool IsConfirmed { get; private set; } = false;
        public string UserInputText => textBoxInput.Text;
        public string ChatBoxlines => chatBox.Text;

        public PluginForm(string initialText)
        {
            InitializeComponent();
            textBoxInput.Text = initialText;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            await SendPostRequestApiChatAsync(textBoxInput.Text + Prompt.Text);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task SendPostRequestApiChatAsync(string data)

        {
            string ai = Properties.Settings.Default.aiserver;
            string url = Properties.Settings.Default.url;
            string model = Properties.Settings.Default.model;

            if (ai == "ollama")
            {
                using (var client = new HttpClient())
                {

                    var requestData = new
                    {
                        model = model,
                        prompt = data
                    };

                    string jsonString = JsonConvert.SerializeObject(requestData);

                    var request = new HttpRequestMessage(HttpMethod.Post, url);


                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    request.Content = content;

                    try
                    {

                        var response = await client.SendAsync(request);


                        response.EnsureSuccessStatusCode();


                        var responseBody = await response.Content.ReadAsStringAsync();

                        var responseParts = responseBody.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                        StringBuilder fullResponse = new StringBuilder();
                        foreach (var part in responseParts)
                        {

                            JObject jsonResponse = JObject.Parse(part);


                            var responseContent = jsonResponse["response"]?.ToString();
                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                fullResponse.Append(responseContent);
                            }
                        }



                        string pattern = @"<think>.*?</think>";
                        string result = Regex.Replace(fullResponse.ToString().Replace("\\u003c", "<").Replace("\\u003e", ">").Trim(), pattern, "");
                        result = result.Replace("<think>", "");
                        result = result.Replace("</think>", "");
                        chatBox.Text = result;
                    }
                    catch (Exception ex)
                    {

                        chatBox.Text = ($"Error: {ex.Message}");
                    }
                }

            }



        }

        public static byte[] CompressString(string str)
        {
            using (var ms = new MemoryStream())
            {
                using (var gzip = new GZipStream(ms, CompressionMode.Compress))
                using (var writer = new StreamWriter(gzip))
                {
                    writer.Write(str);
                }
                return ms.ToArray();
            }
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1024, 1024); 
            this.AutoScaleMode = AutoScaleMode.Dpi;

            lbl1.Location = new Point(12, 11);
            lbl1.Size = new Size(149, 25);

            textBoxInput.Location = new Point(12, 42);
            textBoxInput.Size = new Size(976, 103); 
            label2.Location = new Point(12, 148);
            label2.Size = new Size(125, 25);
            chatBox.Location = new Point(12, 176);
            chatBox.Size = new Size(976, 485);

            label3.Location = new Point(12, 670);
            label3.Size = new Size(80, 25);


            Prompt.Location = new Point(12, 698);
            Prompt.Size = new Size(845, 149);

            btn_SendAi.Location = new Point(865, 698);
            btn_SendAi.Size = new Size(123, 149);

            btn_Remove.Location = new Point(12, 854);
            btn_Remove.Size = new Size(211, 97);


            btn_ModRep.Location = new Point(229, 854);
            btn_ModRep.Size = new Size(211, 97);

            btn_EraseStart.Location = new Point(446, 854);
            btn_EraseStart.Size = new Size(143, 97);

            btn_EraseEnd.Location = new Point(600, 854);
            btn_EraseEnd.Size = new Size(143, 97);


            btn_Sttings.Location = new Point(749, 854);
            btn_Sttings.Size = new Size(108, 97);

            btn_Credit.Location = new Point(865, 854);
            btn_Credit.Size = new Size(121, 97);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string[] lines = textBoxInput.Lines;
            var uniqueLines = lines.Distinct().ToArray();
            chatBox.Lines = uniqueLines;
            IsConfirmed = true;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_ModRep_Click(object sender, EventArgs e)
        {
            string[] lines = textBoxInput.Lines;

            string[] replacementWords = Prompt.Lines;

            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string inputWord = inputDialog.InputText;

                if (string.IsNullOrEmpty(inputWord))
                {
                    MessageBox.Show("Enter Word.");
                    return;
                }


                var resultLines = new System.Collections.Generic.List<string>();


                foreach (var line in lines)
                {
                    if (line.Contains(inputWord))
                    {

                        foreach (var replacementWord in replacementWords)
                        {
                            resultLines.Add(line.Replace(inputWord, replacementWord));
                        }
                    }
                    else
                    {

                        resultLines.Add(line);
                    }
                }


                chatBox.Lines = resultLines.ToArray();
                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_EraseStart_Click(object sender, EventArgs e)
        {
            string[] inputText = textBoxInput.Lines;

            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {

                string replacementWord = inputDialog.InputText;

                if (string.IsNullOrEmpty(replacementWord))
                {
                    MessageBox.Show("Enter Word.");
                    return;
                }


                var resultLines = new System.Collections.Generic.List<string>();

                foreach (var line in inputText)
                {

                    int index = line.IndexOf(replacementWord);

                    if (index >= 0)
                    {
                        resultLines.Add(line.Substring(index + replacementWord.Length));
                    }
                    else
                    {
                        resultLines.Add(line);
                    }
                }


                chatBox.Lines = resultLines.ToArray();
                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;

            }
            else if (inputDialog.ShowDialog() == DialogResult.Cancel)
            {

                string replacementWord = inputDialog.InputText;

                if (string.IsNullOrEmpty(replacementWord))
                {
                    MessageBox.Show("Enter Word.");
                    return;
                }


                var resultLines = new System.Collections.Generic.List<string>();

                foreach (var line in inputText)
                {

                    int index = line.IndexOf(replacementWord);

                    if (index >= 0)
                    {
                        resultLines.Add(line.Substring(0, index));
                    }
                    else
                    {
                        resultLines.Add(line);
                    }
                }


                chatBox.Lines = resultLines.ToArray();
                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;

            }
        }

        private void btn_EraseEnd_Click(object sender, EventArgs e)
        {
            string[] inputText = textBoxInput.Lines;

            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {

                string replacementWord = inputDialog.InputText;

                if (string.IsNullOrEmpty(replacementWord))
                {
                    MessageBox.Show("Enter Word.");
                    return;
                }


                var resultLines = new System.Collections.Generic.List<string>();

                foreach (var line in inputText)
                {

                    resultLines.Add(replacementWord + line);

                }


                chatBox.Lines = resultLines.ToArray();
                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;

            }
            else if (inputDialog.ShowDialog() == DialogResult.Cancel)
            {

                string replacementWord = inputDialog.InputText;

                if (string.IsNullOrEmpty(replacementWord))
                {
                    MessageBox.Show("Enter Word.");
                    return;
                }


                var resultLines = new System.Collections.Generic.List<string>();

                foreach (var line in inputText)
                {
                    resultLines.Add(line + replacementWord);
                }


                chatBox.Lines = resultLines.ToArray();
                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;

            }

        }

        private void btn_Sttings_Click(object sender, EventArgs e)
        {
            Settings SettingsD = new Settings();
            SettingsD.ShowDialog();

        }
    }
}
