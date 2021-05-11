
namespace PresentationMaker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</para
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.keyWordsTip = new System.Windows.Forms.ToolTip();
            this.SuspendLayout();
            // label1
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(63, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вкажіть шлях до текстового файлу";
            // TextFile
            this.TextFile.Location = new System.Drawing.Point(63, 120);
            this.TextFile.Name = "TextFile";
            this.TextFile.Size = new System.Drawing.Size(250, 27);
            this.TextFile.TabIndex = 1;
            // label2
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(63, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введіть ключові слова";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // keyWordsTip
            this.keyWordsTip.ShowAlways = true;
            this.keyWordsTip.SetToolTip(this.KeyWords, "Формат: слово, слово");
            // KeyWords
            this.KeyWords.Location = new System.Drawing.Point(63, 183);
            this.KeyWords.Name = "KeyWords";
            this.KeyWords.Size = new System.Drawing.Size(250, 27);
            this.KeyWords.TabIndex = 3;
            // label3
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(63, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вкажіть шлях до вихідного файлу\r\n";
            // textBox2
            this.textBox2.Location = new System.Drawing.Point(63, 248);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 27);
            this.textBox2.TabIndex = 5;
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(407, 388);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeyWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextFile);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "MainForm";
            this.Text = "PresentationMaker";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeyWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolTip keyWordsTip;
    }
}

