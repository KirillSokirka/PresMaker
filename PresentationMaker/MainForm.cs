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
            this.TextFile.Text = openTxtFileDialog.FileName;
        }
        private void txtFileValidate(object sender, EventArgs e)
        {
            fieldsStatus.Add(false);
            if (String.IsNullOrEmpty(this.TextFile.Text))
            {
                txtFileErrorProvider.SetError(this.TextFile, "Поле пусте");
            }
            else if (!IsFileValid())
            {
                txtFileErrorProvider.SetError(this.TextFile, "Такого файла не існує");
            }
            else
            {
                txtFileErrorProvider.SetError(this.TextFile, String.Empty);
                fieldsStatus[0] = true;
            }
        }
        private bool IsFileValid()
        {
            if (!CheckFiles(this.TextFile.Text))
                return false;
            return true;
        }
        private bool CheckFiles(string file)
        {
            FileInfo tester = new FileInfo(file);
            if (tester.Exists)
                return true;
            return false;
        }
    }
}
