

namespace AdressBook.Interfaces;

public interface IContactService

{
    /// <summary>
    /// Add a new contact to the list
    /// </summary>
    /// <param name="contact">The contact to be added to the list</param>
    /// <returns>True if the contact was added successfully, false if it failed</returns>
    bool AddContactToList(IContact contact);

    /// <summary>
    /// Get one specific contact from the contact list 
    /// </summary>
    /// <param name="email">Find a contact after the email address</param>
    /// <returns>Shows the name and contact information, null if contact not found</returns>

    IContact ContactDetailOption(string email);

    /// <summary>
    /// Delete a contact from the contact list
    /// </summary>
    /// <param name="email">Deletes a contact by the email address</param>
    /// <returns>If the contact is found,returns the contact, else returns null</returns>
    bool DeleteContactOption(string email);


    /// <summary>
    /// Get all contacts from the contact list.
    /// </summary>
    /// <returns>Shows all contacts, else null.</returns>

    IEnumerable<IContact> GetAllContactsFromList();

}
