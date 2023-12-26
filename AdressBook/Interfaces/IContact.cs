

namespace AdressBook.Interfaces;

public interface IContact
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string? PhoneNumber { get; set; }
    string Adress { get; set; }
    Guid PersonNumber { get; set; }
    bool IsActive { get; set; }


}
