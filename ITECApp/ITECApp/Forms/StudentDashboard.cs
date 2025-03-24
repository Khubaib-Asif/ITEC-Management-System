using ITECApp.DataAccess;
using System.Windows.Forms;
using System.Drawing;
using ITECApp.Utilities;

namespace ITECApp.Forms
{
    public partial class StudentDashboard : BaseDashboard
    {
        private DataGridView dgvEvents;
        private DataGridView dgvResults;
        private Button btnParticipateEvent;
        private Button btnViewDetails;
        private Button btnViewResults;

        public StudentDashboard()
        {
            InitializeStudentComponents();
            LoadData();
        }

        private void InitializeStudentComponents()
        {
            // Events Grid
            dgvEvents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 400,
                BackgroundColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White
            };

            // Results Grid
            dgvResults = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White
            };

            // Buttons
            btnParticipateEvent = new Button
            {
                Text = "Participate in Event",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnParticipateEvent.Click += (s, e) => new ParticipateEventForm().ShowDialog();

            btnViewDetails = new Button
            {
                Text = "View Details",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnViewDetails.Click += (s, e) => new ViewDetailsForm().ShowDialog();

            btnViewResults = new Button
            {
                Text = "View Results",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnViewResults.Click += (s, e) => new ViewResultsForm().ShowDialog();

            pnlContent.Controls.Add(dgvResults);
            pnlContent.Controls.Add(dgvEvents);
            pnlContent.Controls.Add(btnParticipateEvent);
            pnlContent.Controls.Add(btnViewDetails);
            pnlContent.Controls.Add(btnViewResults);
        }

        private void LoadData()
        {
            var studentId = UserSession.CurrentUser?.UserId ?? throw new InvalidOperationException("User is not logged in.");
            var dal = new EventDAL();

            dgvEvents.DataSource = dal.GetRegisteredEvents(studentId); // Corrected method name
            dgvResults.DataSource = dal.GetEventResults(studentId); // Corrected method name
        }
    }
}
