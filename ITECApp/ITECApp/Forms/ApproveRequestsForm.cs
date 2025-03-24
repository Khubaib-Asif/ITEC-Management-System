using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class ApproveRequestsForm : Form
    {
        private DataGridView dgvRequests;

        public ApproveRequestsForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadRequests();
        }

        private void InitializeCustomComponents()
        {
            dgvRequests = new DataGridView();
            // Add dgvRequests to the form's controls
            this.Controls.Add(dgvRequests);
        }

        private void LoadRequests()
        {
            var requests = new RequestDAL().GetAllRequests();
            dgvRequests.DataSource = requests;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            // Approve selected request
            var selectedRequest = (ITECApp.Entities.Request)dgvRequests.SelectedRows[0].DataBoundItem;
            new RequestDAL().ApproveRequest(selectedRequest.RequestId);
            LoadRequests();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            // Reject selected request
            var selectedRequest = (ITECApp.Entities.Request)dgvRequests.SelectedRows[0].DataBoundItem;
            new RequestDAL().RejectRequest(selectedRequest.RequestId);
            LoadRequests();
        }
    }
}



