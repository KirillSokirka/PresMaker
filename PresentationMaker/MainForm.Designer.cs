using System;
using System.Collections.Generic;
using System.Windows;

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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TextFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultFile = new System.Windows.Forms.TextBox();
            this.keyWordsTip = new System.Windows.Forms.ToolTip(this.components);
            this.openTxtFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GetTxtFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(63, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вкажіть шлях до текстового файлу";
            // 
            // TextFile
            // 
            this.TextFile.Location = new System.Drawing.Point(63, 120);
            this.TextFile.Name = "TextFile";
            this.TextFile.Size = new System.Drawing.Size(250, 27);
            this.TextFile.TabIndex = 1;
            this.TextFile.Validated += new System.EventHandler(this.txtFileValidate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(63, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введіть ключові слова";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyWords
            // 
            this.KeyWords.Location = new System.Drawing.Point(63, 183);
            this.KeyWords.Name = "KeyWords";
            this.KeyWords.Size = new System.Drawing.Size(250, 27);
            this.KeyWords.TabIndex = 3;
            this.keyWordsTip.SetToolTip(this.KeyWords, "Формат: слово, слово");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(63, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вкажіть шлях до вихідного файлу\r\n";
            // 
            // ResultFile
            // 
            this.ResultFile.Location = new System.Drawing.Point(63, 248);
            this.ResultFile.Name = "ResultFile";
            this.ResultFile.Size = new System.Drawing.Size(250, 27);
            this.ResultFile.TabIndex = 5;
            // 
            // keyWordsTip
            // 
            this.keyWordsTip.ShowAlways = true;
            // 
            // TxtFileDialog
            // 
            this.openTxtFileDialog.FileName = "Текстовий файл";
            // 
            // GetTxtFileButton
            // 
            this.GetTxtFileButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GetTxtFileButton.Location = new System.Drawing.Point(319, 120);
            this.GetTxtFileButton.Name = "GetTxtFileButton";
            this.GetTxtFileButton.Size = new System.Drawing.Size(76, 27);
            this.GetTxtFileButton.TabIndex = 6;
            this.GetTxtFileButton.Text = "Browse\r\n";
            this.GetTxtFileButton.UseVisualStyleBackColor = true;
            this.GetTxtFileButton.Click += new System.EventHandler(GetTXTFile);
            //
            this.txtFileErrorProvider = new System.Windows.Forms.ErrorProvider();
            this.txtFileErrorProvider.SetIconAlignment(this.TextFile, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtFileErrorProvider.SetIconPadding(this.TextFile, 2);
            this.txtFileErrorProvider.BlinkRate = 1000;
            this.txtFileErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(407, 388);
            this.Controls.Add(this.GetTxtFileButton);
            this.Controls.Add(this.ResultFile);
            this.Controls.Add(this.KeyWords);
            this.Controls.Add(this.TextFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "MainForm";
            this.Text = "PresentationMaker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeyWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResultFile;
        private System.Windows.Forms.ToolTip keyWordsTip;
        private System.Windows.Forms.OpenFileDialog openTxtFileDialog;
        private System.Windows.Forms.Button GetTxtFileButton;
        private System.Windows.Forms.ErrorProvider txtFileErrorProvider;
        private System.Windows.Forms.ErrorProvider keywordsErrorProvider;
        private System.Windows.Forms.ErrorProvider resultFileErrorProvider;
        private List<bool> fieldsStatus = new List<bool>();
    }
}

