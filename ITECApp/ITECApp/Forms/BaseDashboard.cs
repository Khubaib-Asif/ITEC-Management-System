using ITECApp.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace ITECApp.Forms
{
    public partial class BaseDashboard : Form
    {
        protected Label lblHeader;
        protected Button btnLogout;
        protected Panel pnlContent;

        public BaseDashboard()
        {
            InitializeComponent();
            ValidateSession();
            InitializeBaseUI();
        }

        private void InitializeBaseUI()
        {
            // Form Settings
            this.Size = new Size(1200, 800);
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Header
            lblHeader = new Label
            {
                Text = "ITEC Dashboard - " + UserSession.CurrentUser.Username,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Logout Button
            btnLogout = new Button
            {
                Text = "Logout",
                BackColor = Color.FromArgb(0, 150, 136),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(100, 35),
                Location = new Point(1050, 20)
            };
            btnLogout.Click += (s, e) => Logout();

            // Content Area
            pnlContent = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(1140, 680),
                BackColor = Color.FromArgb(45, 45, 45)
            };

            this.Controls.Add(lblHeader);
            this.Controls.Add(btnLogout);
            this.Controls.Add(pnlContent);
        }

        private void ValidateSession()
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("Session expired. Please login again.");
                this.Close();
                new SignInForm().Show();
            }
        }

        private void Logout()
        {
            UserSession.CurrentUser = null;
            this.Close();
            new SignInForm().Show();
        }
    }
}