namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtKey = new TextBox();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            btnHash = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtKey
            // 
            txtKey.Location = new Point(88, 19);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(353, 27);
            txtKey.TabIndex = 0;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(88, 55);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(353, 27);
            txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(88, 88);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(353, 27);
            txtOutput.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(15, 180);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(118, 61);
            btnEncrypt.TabIndex = 3;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(139, 180);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(118, 61);
            btnDecrypt.TabIndex = 4;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnHash
            // 
            btnHash.Location = new Point(263, 180);
            btnHash.Name = "btnHash";
            btnHash.Size = new Size(108, 61);
            btnHash.TabIndex = 5;
            btnHash.Text = "Hash";
            btnHash.UseVisualStyleBackColor = true;
            btnHash.Click += btnHash_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 6;
            label1.Text = "Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 55);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 7;
            label2.Text = "Input";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 87);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 8;
            label3.Text = "Output";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 350);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnHash);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Controls.Add(txtKey);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKey;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Button btnHash;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
