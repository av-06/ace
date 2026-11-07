using System.Data;
using Dapper;
using Main_System.Objects;
namespace Main_System.DataAccess.Repositories;

public class AccountRepository : IDisposable
{
    private readonly IDbConnection _db;

    public AccountRepository(IDbConnection db)
    {
        _db = db;
    }

    // Used to notify the GC (garbage collector) when an object of this class should be disposed
    // This, in theory, optimises memory usage and thus improves performance
    public void Dispose()
    {
        _db.Close();
        GC.SuppressFinalize(this);
    }

    // Retrieves the id and username of an account based on whether it is a Student or Teacher account
    public IEnumerable<Account> GetIdAndUsernameByAccountType(accountType type)
    {
        try
        {
            return _db.Query<Account>(@$"
SELECT Account.Account_Id AS Id, Account.Account_Name AS Username
FROM Account
JOIN {type}
ON {type}.Account_Id = Account.Account_Id",
            new { @accountType = type });
        }
        catch
        {
            // If the query fails
            return Enumerable.Empty<Account>();
        }
    }

    // Retrieves the id and username of an account based on a provided Teacher id
    public IEnumerable<Account> GetIdAndUsernameByTeacherId(int teacherId)
    {
        try
        {
            return _db.Query<Account>(@$"
SELECT Account.Account_Id AS Id, Account.Account_Name AS Username
FROM Account
JOIN Student
ON Account.Account_Id = Student.Student_Id
JOIN Teacher_Has_Student
ON Student.Student_Id = Teacher_Has_Student.Student_Id
JOIN Teacher
ON Teacher.Teacher_Id = Teacher_Has_Student.Teacher_Id
WHERE Teacher.Account_Id = @teacher_Id",
            new { @teacher_Id = teacherId });
        }
        catch
        {
            // If the query fails
            return Enumerable.Empty<Account>();
        }
    }

    // Retrieves the password of an account from its username
    public string GetPasswordByUsername(accountType type, ReadOnlySpan<char> username)
    {
        try
        {
            return _db.Query<string>(@$"
SELECT DISTINCT Password_Hash
FROM Account
JOIN {type}
ON {type}.Account_Id = Account.Account_Id
WHERE Account_Name = @name", 
            new { @name = username.ToString() }).Single();
        }
        catch
        {
            // If the username is invalid or the query fails
            return string.Empty;
        }
    }

    // Retrives the id of an account from its username
    public int? GetUserIdByUsername(ReadOnlySpan<char> username)
    {
        try
        {
            return _db.QuerySingle<int>(@$"
SELECT Account_Id
FROM Account
WHERE Account_Name = @name",
            new { @name = username.ToString() });
        }
        catch
        {
            // If the query fails
            return null;
        }
    }

    // Retrives the username of an account from its account id
    public string GetUsernameByUserId(int userId)
    {
        try
        {
            return _db.QuerySingle<string>(@$"
SELECT Account_Name
FROM Account
WHERE Account_Id = @userId",
            new { @userId = userId });
        }
        catch
        {
            // If the query fails
            return string.Empty;
        }
    }

    // Stores account credentials in the database
    public bool AddUser(Account account, ReadOnlySpan<char> passwordHash)
    {
        try
        {
            var insertedUserId = _db.QuerySingle<int>(@"
INSERT INTO Account(Account_Name, Password_Hash) 
VALUES (@name, @password)
SELECT CAST(SCOPE_IDENTITY() as int)",
        new { @name = account.Username, @password = passwordHash.ToString() });

            _db.Execute($@"
INSERT INTO {account.Type}(Account_Id) VALUES (@accountId)",
            new { @accountId = insertedUserId });

            return true;
        }
        catch
        {
            // If the query fails
            return false;
        }
    }

    // Checks to see if the database contains a record with a username provided by the user
    public bool? CheckIfUsernameTaken(Account account)
    {
        try
        {
            return _db.ExecuteScalar<bool>($@"
SELECT COUNT(DISTINCT 1)
FROM Account
JOIN {account.Type}
ON {account.Type}.{account.Type}_Id = Account.Account_Id
WHERE Account_Name = @username",
        new { @username = account.Username });
        }
        catch
        {
            // If the query fails
            return null;
        }
        
    }
}