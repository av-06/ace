using System.Data;
using Microsoft.Data.SqlClient;
using Main_System.DataAccess.Repositories;
using Main_System.Objects;
using Main_System.DataAccess.Operators;
namespace Main_System.DataAccess.Services;

public class AccountService
{
    // Gets from the database the username of an account from its id
    public string GetUsernameByUserId(int userId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetUsernameByUserId(userId);
        }
    }

    // Gets all teacher accounts within the database
    public Account[] GetAllTeacherAccounts()
    {
        using (var repo = GetRepo())
        {
            return repo.GetIdAndUsernameByAccountType(accountType.Teacher).ToArray();
        }
    }

    // Gets all student accounts within the database
    public Account[] GetAllStudentAccounts()
    {
        using (var repo = GetRepo())
        {
            return repo.GetIdAndUsernameByAccountType(accountType.Student).ToArray();
        }
    }

    // Gets all student accounts of a specific teacher
    public Account[] GetAllStudentsOfTeacher(Account teacher)
    {
        using (var repo = GetRepo())
        {
            return repo.GetIdAndUsernameByTeacherId(teacher.Id).ToArray();
        }
    }


    // This concerns the LOGIN validation.
    // This verifies the credentials inputted by a user to ensure that they are valid and exist in the database
    public (int?, string) VerifyUser(Account account)
    {
        // If no credentials have been provided
        if (account.Username.Length is 0 || account.Password.Length is 0)
        {
            return (null, "All details must be inputted!");
        }

        using (var repo = GetRepo())
        {
            var passwordHash = repo.GetPasswordByUsername(account.Type, account.Username);


            // If the username provided cannot be found - i.e. is not an existing account
            if (string.IsNullOrEmpty(passwordHash))
            {
                return (null, $"'{account.Username}' is not an existing {account.Type}!");
            }

            if (BCrypt.Net.BCrypt.EnhancedVerify(account.Password + "8rM06", passwordHash))
            {
                // If the password provided is valid
                return (repo.GetUserIdByUsername(account.Username), string.Empty);
            }
            else
            {
                // If the password provided is invalid
                return (null, $"Invalid password for '{account.Username}'!");
            }
        }
    }

    // This concerns the REGISTRATION validation.
    // This validates the user credentials based on requirements specified in the validator class
    public (bool, string) ValidateUser(Account account)
    {
        return GetValidator().Validate(account);
    }

    // Adds a new account to the database
    public bool StoreAccount(Account account)
    {
        // password is 'peppered' to further improve security
        const string pepper = "8rM06";

        // hash of the 'peppered' password is generated 
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(account.Password + pepper, 10);

        using (var repo = GetRepo())
        {
            var isUserAdded = repo.AddUser(account, passwordHash);
            return isUserAdded;
        }
    }

    // Returns the account repository for database access concerning accounts
    private AccountRepository GetRepo()
    {
        return new AccountRepository(GetConnection());
    }

    // Returns an sql connection to provide to the repository
    private IDbConnection GetConnection()
    {
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        return new SqlConnection(connectionString);
    }

    // Returns a validator object for registration validation
    private AccountValidator GetValidator()
    {
        return new AccountValidator(GetRepo());
    }
}
