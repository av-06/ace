using System.Data;
using Main_System.DataAccess.Services;
using Main_System.Objects;
namespace Main_System;

public partial class DeckSharerForm : Form
{
	private readonly Account _currentUser;
	private readonly Account[] _studentChoices, _teacherChoices; // Selection of Students and Teachers that the user can choose from
	private readonly Deck[] _deckChoices; // Selection of decks that the user can choose from

	public DeckSharerForm(Account currentUser, Deck[] deckChoices)
	{
		InitializeComponent();
		_currentUser = currentUser;
		_deckChoices = deckChoices;
		_studentChoices = new AccountService().GetAllStudentAccounts().Where(account => account.Id != _currentUser.Id).ToArray();
		_teacherChoices = new AccountService().GetAllTeacherAccounts().Where(account => account.Id != _currentUser.Id).ToArray();
	}

	private void DeckSharerForm_Load(object sender, EventArgs e)
	{
		listBoxDecks.DataSource = _deckChoices.Select(deck => deck.Name).ToArray();
		listBoxStudents.DataSource = _studentChoices.Select(student => student.Username).ToArray();
		listBoxTeachers.DataSource = _teacherChoices.Select(teacher => teacher.Username).ToArray();
	}

	private void btnShare_Click(object sender, EventArgs e)
	{
		var (isValid, errorMessage) = ValidateDetails();

		if (isValid)
		{
			// 1. Get the decks to share
			var selectedDecks = listBoxDecks.SelectedIndices.Cast<int>();
			var decksToShare = selectedDecks.Select(i => _deckChoices[i].Id).ToArray();

			// 2. Get the receiverIds
			var selectedStudents = listBoxStudents.SelectedIndices.Cast<int>();
			var studentsToShare = selectedStudents.Select(i => _studentChoices[i].Id).ToArray();

			var selectedTeachers = listBoxTeachers.SelectedIndices.Cast<int>();
			var teachersToShare = selectedTeachers.Select(i => _teacherChoices[i].Id).ToArray();


			// 3. Share decks with Students if necessary
			if (studentsToShare.Length is not 0)
			{
				new DeckService().ShareDecks(decksToShare, _currentUser.Id, studentsToShare.ToArray());
			}

			// 4. Share decks with Teachers if necessary
			if (teachersToShare.Length is not 0)
			{
				new DeckService().ShareDecks(decksToShare, _currentUser.Id, teachersToShare.ToArray());
			}

			MessageBox.Show(@"Decks have been successfully shared!
(Note: Any decks that have already been shared with a user will not have been sent to that user)",
			"Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else
		{
			MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}


	private (bool, string) ValidateDetails()
	{
		// If no decks have been selected
		if (listBoxDecks.SelectedItems.Count is 0)
		{
			return (false, "No decks have been selected!");
		}

		// If no users have been selected
		if (listBoxTeachers.SelectedItems.Count is 0 && listBoxStudents.SelectedItems.Count is 0)
		{
			return (false, "No users have been selected!");
		}

		// If all of the above is false, then all the details provided by the user is valid
		return (true, string.Empty);
	}
}