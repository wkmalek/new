using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Administration;



namespace SolutionManagerWF
{
    public partial class Form1 : Form
    {
        private string FilePath;
        private string FileName;
        private string WebUrl;
        SPHandler spHandler = new SPHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FilePath = openFileDialog1.FileName;
            FileName = openFileDialog1.SafeFileName;
            PathTextBox.Text = FilePath;
            SPFarm farm = SPFarm.Local;

            var output = spHandler.GetListOfSolutions();
            // OutputTextBox.Text += output;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {

        }

        private void InstallButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
