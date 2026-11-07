using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public partial class RegistrationForm : Form
{
    public RegistrationForm()
    {
        InitializeComponent();
    }

    private void btnSignUp_Click(object sender, EventArgs e)
    {
        if (CheckIfAccountTypeSelected() is true)
        {
            ValidateAccount(new Account(boxUsername.Text, boxPassword.Text, GetSelectedAccountType()));
        }
        else
        {
            MessageBox.Show("Must confirm whether you are a student or a teacher!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void boxUsername_TextChanged(object sender, EventArgs e)
    {
        UpdateCounter(txtUsernameLength, boxUsername);
    }

    private void boxPassword_TextChanged(object sender, EventArgs e)
    {
        UpdateCounter(txtPasswordLength, boxPassword);
    }

    private void checkboxTeacher_CheckedChanged(object sender, EventArgs e)
    {
        if (checkboxTeacher.Checked is true)
        {
            checkboxStudent.Checked = false;
        }
    }

    private void checkboxStudent_CheckedChanged(object sender, EventArgs e)
    {
        if (checkboxStudent.Checked is true)
        {
            checkboxTeacher.Checked = false;
        }
    }

    private void ValidateAccount(Account account)
    {
        var (isValidAccount, errorMessage) = new AccountService().ValidateUser(account);

        if (isValidAccount)
        {
            // Ensures that the user cannot exit the system while the new account is being added
            this.Enabled = false;
            var isAccountAdded = new AccountService().StoreAccount(account);
            this.Enabled = true;


            // If the account is successfully added
            if (isAccountAdded)
            {
                MessageBox.Show("Account successfully registered!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("System failed to add new account. Please try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool CheckIfAccountTypeSelected()
    {
        return (checkboxStudent.Checked || checkboxTeacher.Checked) ? true : false;
    }
    private accountType GetSelectedAccountType()
    {
        return (checkboxStudent.Checked) ? accountType.Student : accountType.Teacher;
    }


    // Increments a text counter on the GUI to reflect the number of characters in a specific textbox
    private void UpdateCounter(Label counter, TextBox target)
    {
        counter.Text = $"{target.Text.Length.ToString()} / 30";

        if (target.Text.Length > 30 || target.Text.Length is 0)
        {
            counter.ForeColor = Color.Red;
        }
        else if (counter.ForeColor == Color.Red)
        {
            counter.ForeColor = Color.Black;
        }
    }
}
