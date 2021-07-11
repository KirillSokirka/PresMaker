using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PresentationMaker.Parser;

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
            {
                return;
            }
            TextFile.Text = openTxtFileDialog.FileName;
        }
        private void GetResultFile(object sender, EventArgs e)
        {
            openResultFileDialog.Filter = "Файли презентацій(*.pptx)|*.pptx|Всі файли(*.*)|*.*";
            if (openResultFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }            
            ResultFile.Text = openResultFileDialog.FileName;
        }
        private void keyWordsValidation(object sender, EventArgs e)
        {
            fieldsStatus[0] = false;
            if (string.IsNullOrEmpty(KeyWords.Text))
            {
                keywordsErrorProvider.SetError(KeyWords, "Поле пусте");
                return;
            }
            keywordsErrorProvider.SetError(KeyWords, string.Empty);
            keyWords = KeyWords.Text;
            fieldsStatus[0] = true;
        }
        private void txtFileValidation(object sender, EventArgs e)
        {
            fieldsStatus[1] = false;
            if (string.IsNullOrEmpty(TextFile.Text))
            {
                txtFileErrorProvider.SetError(TextFile, "Поле пусте");
                return;
            }
            if (!CheckFiles(TextFile.Text))
            {
                txtFileErrorProvider.SetError(TextFile, "Такого файла не існує");
                return;
            }
            txtFileErrorProvider.SetError(TextFile, string.Empty);
            textFile = TextFile.Text;
            fieldsStatus[1] = true;
        }
        private void resultFileValidation(object sender, EventArgs e)
        {
            fieldsStatus[2] = false;
            if (string.IsNullOrEmpty(ResultFile.Text))
            {
                resultFileErrorProvider.SetError(ResultFile, "Поле пусте");
                return;
            }
            if (!CheckFiles(ResultFile.Text))
            {
                resultFileErrorProvider.SetError(ResultFile, "Такого файла не існує");
                return;
            }
            fieldsStatus[2] = true;
            resultFileErrorProvider.SetError(ResultFile, string.Empty);
            resultFile = ResultFile.Text;
        }
        private bool CheckFiles(string file)
        {
            FileInfo tester = new FileInfo(file);
            if (tester.Exists)
            {
                return true;
            }
            return false;
        }
        private bool CheckAllFields()
        {
            foreach (bool item in fieldsStatus)
            {
                if (item == false)
                {
                    return false;
                }
            }
            return true;
        }
        private async void MakePresButton(object sender, EventArgs e)
        {
            if (!CheckAllFields())
            {
                MessageBox.Show("Перевірте всі поля");
                return;
            }
            SlovnykParser parser = new SlovnykParser();
            IParserSettings settings = new SlovnykSettings();
            var textAnalyser = new TextAnalyser<List<string>>(parser, settings);
            var sentances = await textAnalyser.Analyse(textFile, keyWords);
            if (sentances.Length == 0)
            {
                MessageBox.Show("Презентацію не було створено\n" +
                    "оскільки відповідні речення не було знайдено");
                return;
            }
            try
            {
                PresMaker presMaker = new PresMaker();
                presMaker.Create(resultFile, sentances);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }           
            MessageBox.Show("Презентацію створено");
        }
    }
}
