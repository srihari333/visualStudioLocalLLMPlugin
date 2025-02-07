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

namespace LLLMPlugin
{
    public partial class MyForm : Form
    {
        
            public bool IsConfirmed { get; private set; } = false;
            public string UserInputText => textBoxInput.Text;
            public string  ChatBoxlines => chatBox.Text;

            public MyForm(string initialText)
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
 
                        resultLines.Add(replacementWord +  line );
                    
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
