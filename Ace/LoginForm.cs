using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }


    // Opens the account registration form for new users to create an account
    private void linktxtSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        using (var rf = new RegistrationForm())
        {
            rf.ShowDialog();
        }
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckIfAccountTypeSelected() is true)
        {
            // Run verification process with details provided by current user
            VerifyUser(new Account(boxUsername.Text, boxPassword.Text, GetSelectedAccountType()));
        }
        else
        {
            // An account type must be selected for the account to be a valid account
            MessageBox.Show("All details must be inputted!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void checkboxTeacher_CheckedChanged(object sender, EventArgs e)
    {
        // Prevents the user from selecting both account types
        if (checkboxTeacher.Checked is true)
        {
            checkboxStudent.Checked = false;
        }
    }

    private void checkboxStudent_CheckedChanged(object sender, EventArgs e)
    {
        // Prevents the user from selecting both account types
        if (checkboxStudent.Checked is true)
        {
            checkboxTeacher.Checked = false;
        }
    }

    private bool CheckIfAccountTypeSelected()
    {
        // returns true if the Student or Teacher checkbox is checked, otherwise false
        return (checkboxStudent.Checked || checkboxTeacher.Checked) ?
            true : false;   
    }

    private accountType GetSelectedAccountType()
    {
        // returns Student account type if Student checkbox is checked, otherwise Teacher account type
        return (checkboxStudent.Checked) ? accountType.Student : accountType.Teacher;
    }

    private void VerifyUser(Account user)
    {
        var (validId, errorMessage) = new AccountService().VerifyUser(user);

        if (validId.HasValue)
        {
            // If valid, the user's id is given to them.
            // This allows them to properly utilise all forms deriving from this form.
            user.Id = validId.Value;

            using (var mf = new MainForm(user))
            {
                mf.ShowDialog();
            }
        }
        else
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
