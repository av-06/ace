using System.Text.RegularExpressions;
using Main_System.DataAccess.Repositories;
using Main_System.Objects;
namespace Main_System.DataAccess.Operators;

public class AccountValidator
{
    private readonly AccountRepository _repo;
    public AccountValidator(AccountRepository repo)
    {
        _repo = repo;
    }

    // Validates users credentials, returning error messages when the credentials are found to be invalid
    public (bool, string) Validate(Account account)
    {
        // Simple pattern matching is used to enforce password requirements
        var passwordRegex = new Regex(@"^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[~`'!@#$%^&*()\-_+={}\[\]\\/:;""<>,.?]).*$", RegexOptions.ExplicitCapture);

        // If the username is left blank
        if (string.IsNullOrWhiteSpace(account.Username) is true)
        {
            return (false, "Username can't be left blank!");
        }

        // If the username is 30 or more characters
        if (account.Username.Length > 30)
        {
            return (false, "Username must be 30 characters or less!");
        }

        var isUsernameTaken = _repo.CheckIfUsernameTaken(account);

        // If the username has already been taken by another account
        if (isUsernameTaken.HasValue)
        {
            if (isUsernameTaken.Value is true)
            {
                return (false, $"{account.Username} is already taken!");
            }
        }
        
        // If the password is 30 or more characters
        if (account.Password.Length > 30)
        {
            return (false, "Password must be 30 characters or less!");
        }

        // If the password is left blank or does not fulfil the password requirements
        if (passwordRegex.IsMatch(account.Password) is false)
        {
            return (false,
                @"Password must contain at least:
- 1 uppercase character (A-Z)
- 1 lowercase character (a-z)
- 1 digit (1-9)
- 1 special character ($, £, %, etc.)");
        }

        // A new account is valid, until proven otherwise
        return (true, string.Empty);
    }
}
