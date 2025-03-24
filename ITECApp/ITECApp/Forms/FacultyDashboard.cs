using ITECApp.DataAccess;
using System.Windows.Forms;
using System.Drawing;
using ITECApp.Utilities;

namespace ITECApp.Forms
{
    public partial class FacultyDashboard : BaseDashboard
    {
        private DataGridView dgvCommittees;
        private DataGridView dgvDuties;

        public FacultyDashboard()
        {
            InitializeFacultyComponents();
            LoadData();
        }

        private void InitializeFacultyComponents()
        {
            // Split View
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 300
            };

            // Committees Grid
            dgvCommittees = CreateDataGrid();
            dgvCommittees.Columns.Add("CommitteeId", "ID");
            dgvCommittees.Columns.Add("CommitteeName", "Committee Name");

            // Duties Grid
            dgvDuties = CreateDataGrid();
            dgvDuties.Columns.Add("DutyId", "Task ID");
            dgvDuties.Columns.Add("TaskDescription", "Description");
            dgvDuties.Columns.Add("Status", "Status");

            splitContainer.Panel1.Controls.Add(dgvCommittees);
            splitContainer.Panel2.Controls.Add(dgvDuties);
            pnlContent.Controls.Add(splitContainer);
        }

        private DataGridView CreateDataGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White
            };
        }

        private void LoadData()
        {
            var facultyId = UserSession.CurrentUser.UserId;
            var dal = new CommitteeDAL();

            dgvCommittees.DataSource = dal.GetCommitteesByFaculty(facultyId);
            dgvDuties.DataSource = dal.GetDutiesByFaculty(facultyId);
        }
    }
}
