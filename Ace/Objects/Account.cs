using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Main_System.Objects;

public enum accountType
{
    Teacher,
    Student
}

public class Account
{
    [Key]
    [Column("Account_Id")]
    public int Id { get; set; }

    [Column("Account_Name")]
    public string Username { get; private set; }

    [Column("Password_Hash")]
    public string Password { get; private set; }
    public accountType Type { get; private set; }

    public Account(ReadOnlySpan<char> username, ReadOnlySpan<char> password, 
        accountType type, int id = 0)
    {
        this.Id = id;
        this.Username = username.ToString();
        this.Password = password.ToString();
        this.Type = type;
    }

    public Account() { } // needed for Dapper to work
}
