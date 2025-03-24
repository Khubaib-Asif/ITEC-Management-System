using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class ManageCommitteesForm : Form
    {
        public ManageCommitteesForm()
        {
            InitializeComponent();
            LoadCommittees();
        }

        private void LoadCommittees()
        {
            var committees = new CommitteeDAL().GetAllCommittees();
            dgvCommittees.DataSource = committees;
        }

        private void btnAddCommittee_Click(object sender, EventArgs e)
        {
            // Add new committee
        }

        private void btnEditCommittee_Click(object sender, EventArgs e)
        {
            // Edit selected committee
        }

        private void btnDeleteCommittee_Click(object sender, EventArgs e)
        {
            // Delete selected committee
        }
    }
}



