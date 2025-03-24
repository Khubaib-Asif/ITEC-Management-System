using ITECApp.BusinessLayer;
using ITECApp.DataAccess;
using ITECApp.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITECApp.Forms
{
    public partial class SignInForm : Form
    {
        private TextBox txtUsername = new TextBox();
        private TextBox txtPassword = new TextBox();
        private Button btnSignIn = new Button();
        private LinkLabel lnkSignUp = new LinkLabel();
        private Label lblError = new Label();

        public SignInForm()
        {
            InitializeComponent();
            ApplyStyling();
            InitializePlaceholders();
            AttachEventHandlers();
        }

        private void ApplyStyling()
        {
            // Form Styling
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.ClientSize = new Size(400, 400);
            this.Text = "ITEC Sign In";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Control Styling
            txtUsername.Location = new Point(50, 100);
            txtUsername.Size = new Size(300, 25);

            txtPassword.Location = new Point(50, 150);
            txtPassword.Size = new Size(300, 25);

            btnSignIn.Location = new Point(50, 200);
            btnSignIn.Size = new Size(300, 35);
            btnSignIn.Text = "Sign In";
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.BackColor = Color.FromArgb(0, 150, 136);
            btnSignIn.ForeColor = Color.White;

            lnkSignUp.Location = new Point(50, 250);
            lnkSignUp.Size = new Size(200, 20);
            lnkSignUp.Text = "Don't have an account? Sign Up";
            lnkSignUp.LinkColor = Color.FromArgb(0, 150, 136);

            lblError.Location = new Point(50, 300);
            lblError.Size = new Size(300, 20);
            lblError.ForeColor = Color.OrangeRed;

            this.Controls.AddRange(new Control[] {
                txtUsername, txtPassword, btnSignIn, lnkSignUp, lblError
            });
        }

        private void InitializePlaceholders()
        {
            AddPlaceholder(txtUsername, "Username/Email");
            AddPlaceholder(txtPassword, "Password", true);
        }

        private void AddPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            if (isPassword) textBox.PasswordChar = '\0';

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.White;
                    if (isPassword) textBox.PasswordChar = '*';
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                    if (isPassword) textBox.PasswordChar = '\0';
                }
            };
        }

        private void AttachEventHandlers()
        {
            btnSignIn.Click += btnSignIn_Click;
            lnkSignUp.LinkClicked += lnkSignUp_LinkClicked;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;

                string username = txtUsername.Text == "Username/Email" ? "" : txtUsername.Text.Trim();
                string password = txtPassword.Text == "Password" ? "" : txtPassword.Text;

                var response = new UserBLL().AuthenticateUser(username, password);
                if (response.IsSuccess)
                {
                    if (UserSession.CurrentUser != null)
                    {
                        Form dashboard = GetDashboardForm(UserSession.CurrentUser.RoleId);
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        ShowError("User session is not initialized.");
                    }
                }
                else
                {
                    ShowError(response.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Sign In Error: {ex.Message}");
            }
        }

        private Form GetDashboardForm(int roleId)
        {
            var role = new RoleDAL().GetRoleById(roleId);
            return role.RoleName switch
            {
                "Admin" => new AdminDashboard(),
                "Faculty" => new FacultyDashboard(),
                "Student" => new StudentDashboard(),
                "Sponsor" => new SponsorDashboard(),
                _ => throw new System.Security.SecurityException("Invalid role: Access denied.")
            };
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new SignUpForm().Show();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
