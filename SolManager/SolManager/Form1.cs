using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SolManager
{
    public partial class Form1 : Form
    {
        private string FilePath;
        private string FileName;
        private string WebUrl;
        SPHandler spHandler = new SPHandler();
        SPFarm farm = SPFarm.Local;

        public Form1()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            SolutionsList.Items.Clear();
            farm = SPFarm.Local;

            SPSolutionCollection output = (SPSolutionCollection)spHandler.GetListOfSolutions();
            foreach (var item in output)
            {
                ListViewItem lvItem = new ListViewItem(new string[]
                {
                    item.Name,
                    item.Id.ToString(),
                    item.Deployed.ToString(),
                });
                SolutionsList.Items.Add(lvItem);
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FilePath = openFileDialog1.FileName;
            FileName = openFileDialog1.SafeFileName;
            PathTextBox.Text = FilePath;

            // OutputTextBox.Text += output;
            FillList();
        }


        private SPSolution GetSolutionById(string ID)
        {
            SPSolutionCollection output = (SPSolutionCollection)spHandler.GetListOfSolutions();
            return output.Where(x => x.Id == new Guid(ID)).Single();
            
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            string id = SolutionsList.SelectedItems[0].Name;
            farm.Solutions.Remove(SolutionsList.SelectedItems[0].Text);
            FillList();
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {

            Guid id = new Guid(SolutionsList.SelectedItems[0].SubItems[1].Text);
            farm.Solutions[id].RetractLocal(GetAllSPWebApp());
            FillList();
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            
            Guid id = new Guid(SolutionsList.SelectedItems[0].SubItems[1].Text);
            farm.Solutions[id].DeployLocal(true, GetAllSPWebApp(), true);
            FillList();
        }

        private Collection<SPWebApplication> GetAllSPWebApp()
        {
            var serv = farm.Services.GetValue<SPWebService>(string.Empty);
            Collection<SPWebApplication> web = new Collection<SPWebApplication>();
            foreach (var item in serv.WebApplications)
            {
                web.Add(item);
            }

            return web;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            farm.Solutions.Add(FilePath);
            FillList();
        }
    }
}
