using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class AssignDutiesForm : Form
    {
        public AssignDutiesForm()
        {
            InitializeComponent();
            LoadDuties();
            LoadAssignees();
        }

        private void LoadDuties()
        {
            var duties = new DutyDAL().GetAllDuties();
            dgvDuties.DataSource = duties;
        }

        private void LoadAssignees()
        {
            var assignees = new UserDAL().GetAllUsers();
            cmbAssignee.DataSource = assignees;
            cmbAssignee.DisplayMember = "Username";
            cmbAssignee.ValueMember = "UserId";
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Assign selected duty
            if (dgvDuties.SelectedRows.Count > 0)
            {
                var selectedDuty = (Duty)dgvDuties.SelectedRows[0].DataBoundItem;
                new DutyDAL().AssignDuty(selectedDuty.DutyId, (int)cmbAssignee.SelectedValue);
                LoadDuties();
            }
            else
            {
                MessageBox.Show("Please select a duty to assign.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


