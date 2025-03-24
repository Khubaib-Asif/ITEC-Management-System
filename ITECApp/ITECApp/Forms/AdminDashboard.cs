using ITECApp.DataAccess;
using System.Windows.Forms;
using ITECApp.Entities;
using System.Drawing;

namespace ITECApp.Forms
{
    public partial class AdminDashboard : BaseDashboard
    {
        private DataGridView dgvUsers;
        private DataGridView dgvTransactions;
        private Button btnManageEvents;
        private Button btnManageCommittees;
        private Button btnManageVendors;
        private Button btnManageSponsors;
        private Button btnGenerateReports;
        private Button btnApproveRequests;
        private Button btnAssignDuties;

        public AdminDashboard()
        {
            InitializeAdminComponents();
            LoadData();
        }

        private void InitializeAdminComponents()
        {
            // Initialize fields
            dgvUsers = new DataGridView();
            dgvTransactions = new DataGridView();
            btnManageEvents = new Button();
            btnManageCommittees = new Button();
            btnManageVendors = new Button();
            btnManageSponsors = new Button();
            btnGenerateReports = new Button();
            btnApproveRequests = new Button();
            btnAssignDuties = new Button();

            // Tab Control
            var tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Appearance = TabAppearance.FlatButtons
            };

            // Users Tab
            var tabUsers = new TabPage("Users");
            dgvUsers = CreateDataGrid();
            tabUsers.Controls.Add(dgvUsers);

            // Transactions Tab
            var tabFinances = new TabPage("Finances");
            dgvTransactions = CreateDataGrid();
            tabFinances.Controls.Add(dgvTransactions);

            // Buttons
            btnManageEvents = new Button
            {
                Text = "Manage Events",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnManageEvents.Click += (s, e) => new ManageEventsForm().ShowDialog();

            btnManageCommittees = new Button
            {
                Text = "Manage Committees",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnManageCommittees.Click += (s, e) => new ManageCommitteesForm().ShowDialog();

            btnManageVendors = new Button
            {
                Text = "Manage Vendors",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnManageVendors.Click += (s, e) => new ManageVendorsForm().ShowDialog();

            btnManageSponsors = new Button
            {
                Text = "Manage Sponsors",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnManageSponsors.Click += (s, e) => new ManageSponsorsForm().ShowDialog();

            btnGenerateReports = new Button
            {
                Text = "Generate Reports",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnGenerateReports.Click += (s, e) => new GenerateReportsForm().ShowDialog();

            btnApproveRequests = new Button
            {
                Text = "Approve Requests",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnApproveRequests.Click += (s, e) => new ApproveRequestsForm().ShowDialog();

            btnAssignDuties = new Button
            {
                Text = "Assign Duties",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnAssignDuties.Click += (s, e) => new AssignDutiesForm().ShowDialog();

            tabControl.TabPages.Add(tabUsers);
            tabControl.TabPages.Add(tabFinances);
            pnlContent.Controls.Add(tabControl);
            pnlContent.Controls.Add(btnManageEvents);
            pnlContent.Controls.Add(btnManageCommittees);
            pnlContent.Controls.Add(btnManageVendors);
            pnlContent.Controls.Add(btnManageSponsors);
            pnlContent.Controls.Add(btnGenerateReports);
            pnlContent.Controls.Add(btnApproveRequests);
            pnlContent.Controls.Add(btnAssignDuties);
        }

        private DataGridView CreateDataGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 150, 136),
                    ForeColor = Color.White
                }
            };
        }

        private void LoadData()
        {
            // Load Users
            dgvUsers.DataSource = new UserDAL().GetAllUsers();

            // Load Financial Transactions
            dgvTransactions.DataSource = new FinanceDAL().GetAllTransactions();
        }
    }
}
