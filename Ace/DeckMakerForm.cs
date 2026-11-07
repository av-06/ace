using Main_System.DataAccess.Services;
using Main_System.Objects;
namespace Main_System;

public partial class DeckMakerForm : Form
{
    private readonly Account _currentUser;
    public DeckMakerForm(Account currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;
    }

    private void btnCreateDeck_Click(object sender, EventArgs e)
    {
        var (isValidDeck, errorMessage) = VerifyDeckDetails();

        if (isValidDeck)
        {
            // If a description is not provided, then the value stored in the database for the description should be null
            if (string.IsNullOrWhiteSpace(boxDescription.Text) || boxDescription.Text.Length is 0)
            {
                new DeckService().AddNewDeck(boxName.Text, null, _currentUser.Id);
            }
            else
            {
                new DeckService().AddNewDeck(boxName.Text, boxDescription.Text, _currentUser.Id);
            }

            MessageBox.Show($"'{boxName.Text}' has been successfully added!");
            
            // This informs the main form that a deck has been added, and thus the deck selection should be updated
            MainForm.hasDeckBeenAdded = true;
            this.Close();
        }
        else
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private (bool, string) VerifyDeckDetails()
    {
        // If the deck name is left blank
        if (string.IsNullOrWhiteSpace(boxName.Text) || boxName.Text.Length is 0)
        {
            return (false, "Name of the deck must not be left blank!");
        }

        // If the deck name is 50 or more characters
        if (boxName.Text.Length > 50)
        {
            return (false, "Name of the deck must be 50 characters or less!");
        }

        // If the description is 100 or more characters
        if (boxDescription.Text.Length > 100)
        {
            return (false, "Description of the deck must be 100 characters or less");
        }

        // If the deck is not an existing deck
        if (new DeckService().CheckIfDeckNameTaken(boxName.Text, _currentUser.Id))
        {
            return (false, $"'{boxName.Text}' is already a deck that has been created!");
        }

        // If all of the above is not true, then the deck must be valid
        return (true, string.Empty);
    }
}
