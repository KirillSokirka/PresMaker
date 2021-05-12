using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void GetTXTFile(object sender, EventArgs e)
        {
            openTxtFileDialog.Filter = "Текстові файли(*.txt)|*.txt|Всі файли(*.*)|*.*";
            if (openTxtFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            TextFile.Text = openTxtFileDialog.FileName;
        }
        private void GetResultFile(object sender, EventArgs e)
        {
            openResultFileDialog.Filter = "Файли презентацій(*.pptx)|*.pptx|Всі файли(*.*)|*.*";
            if (openResultFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ResultFile.Text = openResultFileDialog.FileName;
        }
        private void keyWordsValidation(object sender, EventArgs e)
        {
            fieldsStatus[0] = false;
            if (String.IsNullOrEmpty(this.KeyWords.Text))
            {
                keywordsErrorProvider.SetError(this.KeyWords, "Поле пусте");
                return;
            }
            keywordsErrorProvider.SetError(this.KeyWords, String.Empty);
            keyWords = KeyWords.Text;
            fieldsStatus[0] = true;
        }
        private void txtFileValidation(object sender, EventArgs e)
        {
            fieldsStatus[1] = false;
            if (String.IsNullOrEmpty(this.TextFile.Text))
            {
                txtFileErrorProvider.SetError(this.TextFile, "Поле пусте");
                return;
            }
            if (!CheckFiles(this.TextFile.Text))
            {
                txtFileErrorProvider.SetError(this.TextFile, "Такого файла не існує");
                return;
            }
            txtFileErrorProvider.SetError(this.TextFile, String.Empty);
            textFile = TextFile.Text;
            fieldsStatus[1] = true;
        }
        private void resultFileValidation(object sender, EventArgs e)
        {
            fieldsStatus[2] = false;
            if (String.IsNullOrEmpty(this.ResultFile.Text))
            {
                resultFileErrorProvider.SetError(this.ResultFile, "Поле пусте");
                return;
            }
            if (!CheckFiles(this.ResultFile.Text))
            {
                resultFileErrorProvider.SetError(this.ResultFile, "Такого файла не існує");
                return;
            }
            fieldsStatus[2] = true;
            resultFileErrorProvider.SetError(this.ResultFile, String.Empty);
            resultFile = ResultFile.Text;
        }
        private bool CheckFiles(string file)
        {
            FileInfo tester = new FileInfo(file);
            if (tester.Exists)
                return true;
            return false;
        }
        private bool CheckAllFields()
        {
            foreach (var item in fieldsStatus)
            {
                if (item == false)
                    return false;
            }
            return true;
        }
        private void MakePresButton(object sender, EventArgs e)
        {
            if (!CheckAllFields())
            {
                MessageBox.Show("Перевірте всі поля");
                return;
            }
            TextAnalyser textAnalyser = new TextAnalyser();
            var sentances = textAnalyser.Analyse(this.textFile, this.keyWords);
            if(sentances.Count == 0)
            {
                MessageBox.Show("Презентацію не було створено\n" +
                    "оскільки відповідні речення не було знайдено");
                return;
            }
            MessageBox.Show("Презентацію створено");
        }
    }
}
