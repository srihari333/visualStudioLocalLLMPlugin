namespace LLLMPlugin
{
    partial class MyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Sttings = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_ModRep = new System.Windows.Forms.Button();
            this.btn_EraseStart = new System.Windows.Forms.Button();
            this.btn_EraseEnd = new System.Windows.Forms.Button();
            this.btn_Credit = new System.Windows.Forms.Button();
            this.btn_SendAi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 42);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ReadOnly = true;
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(966, 103);
            this.textBoxInput.TabIndex = 2;
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 176);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(966, 485);
            this.chatBox.TabIndex = 3;
            // 
            // Prompt
            // 
            this.Prompt.Location = new System.Drawing.Point(12, 698);
            this.Prompt.Multiline = true;
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(845, 149);
            this.Prompt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Response:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 670);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prompt:";
            // 
            // btn_Sttings
            // 
            this.btn_Sttings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Sttings.Location = new System.Drawing.Point(749, 854);
            this.btn_Sttings.Name = "btn_Sttings";
            this.btn_Sttings.Size = new System.Drawing.Size(108, 49);
            this.btn_Sttings.TabIndex = 0;
            this.btn_Sttings.Text = "Settings";
            this.btn_Sttings.UseVisualStyleBackColor = true;
            this.btn_Sttings.Click += new System.EventHandler(this.btn_Sttings_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Remove.Location = new System.Drawing.Point(12, 854);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(211, 49);
            this.btn_Remove.TabIndex = 0;
            this.btn_Remove.Text = "Remove Duplicate";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_ModRep
            // 
            this.btn_ModRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ModRep.Location = new System.Drawing.Point(229, 854);
            this.btn_ModRep.Name = "btn_ModRep";
            this.btn_ModRep.Size = new System.Drawing.Size(211, 49);
            this.btn_ModRep.TabIndex = 0;
            this.btn_ModRep.Text = "Modify && replicate";
            this.btn_ModRep.UseVisualStyleBackColor = true;
            this.btn_ModRep.Click += new System.EventHandler(this.btn_ModRep_Click);
            // 
            // btn_EraseStart
            // 
            this.btn_EraseStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_EraseStart.Location = new System.Drawing.Point(446, 854);
            this.btn_EraseStart.Name = "btn_EraseStart";
            this.btn_EraseStart.Size = new System.Drawing.Size(143, 49);
            this.btn_EraseStart.TabIndex = 0;
            this.btn_EraseStart.Text = "Erase";
            this.btn_EraseStart.UseVisualStyleBackColor = true;
            this.btn_EraseStart.Click += new System.EventHandler(this.btn_EraseStart_Click);
            // 
            // btn_EraseEnd
            // 
            this.btn_EraseEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_EraseEnd.Location = new System.Drawing.Point(600, 854);
            this.btn_EraseEnd.Name = "btn_EraseEnd";
            this.btn_EraseEnd.Size = new System.Drawing.Size(143, 49);
            this.btn_EraseEnd.TabIndex = 0;
            this.btn_EraseEnd.Text = "Add";
            this.btn_EraseEnd.UseVisualStyleBackColor = true;
            this.btn_EraseEnd.Click += new System.EventHandler(this.btn_EraseEnd_Click);
            // 
            // btn_Credit
            // 
            this.btn_Credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Credit.Location = new System.Drawing.Point(865, 854);
            this.btn_Credit.Name = "btn_Credit";
            this.btn_Credit.Size = new System.Drawing.Size(115, 49);
            this.btn_Credit.TabIndex = 0;
            this.btn_Credit.Text = "Credit";
            this.btn_Credit.UseVisualStyleBackColor = true;
            this.btn_Credit.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn_SendAi
            // 
            this.btn_SendAi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SendAi.Location = new System.Drawing.Point(865, 698);
            this.btn_SendAi.Name = "btn_SendAi";
            this.btn_SendAi.Size = new System.Drawing.Size(115, 149);
            this.btn_SendAi.TabIndex = 0;
            this.btn_SendAi.Text = "Send AI";
            this.btn_SendAi.UseVisualStyleBackColor = true;
            this.btn_SendAi.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 909);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.btn_EraseEnd);
            this.Controls.Add(this.btn_EraseStart);
            this.Controls.Add(this.btn_ModRep);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Credit);
            this.Controls.Add(this.btn_Sttings);
            this.Controls.Add(this.btn_SendAi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "visualStudioLocalLLMPlugin";
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Sttings;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_ModRep;
        private System.Windows.Forms.Button btn_EraseStart;
        private System.Windows.Forms.Button btn_EraseEnd;
        private System.Windows.Forms.Button btn_Credit;
        private System.Windows.Forms.Button btn_SendAi;
    }
}