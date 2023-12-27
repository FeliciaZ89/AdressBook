using AdressBook.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Services;


public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    //private readonly IFileService _fileService = new FileService(@"C:\Agenda\AdressBook\content.json");

    public List<IContact> _contacts = [];
    private readonly string _filePath = @"C:\Agenda\AdressBook\content.json";

   


    public bool AddContactToList(IContact contact)
    {

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                _fileService.SaveContentToFile(_filePath, json);
                return true;

            }
            else
            {
                Console.WriteLine("Contact already exists!");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

        }
        return false;

    }

    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {
            var content1 = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content1))


            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content1, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;

            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IContact ContactDetailOption(string email)
    {
        try
        {
            GetAllContactsFromList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteContactOption(string email)
    {
        try
        {
            var contactToDelete = _contacts.FirstOrDefault(c => c.Email == email);
            if (contactToDelete != null)
            {
                _contacts.Remove(contactToDelete);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                _fileService.SaveContentToFile(_filePath, json);
                Debug.WriteLine($"Contact {email} deleted successfully. Updated contact list: {_contacts.Count} contacts.");
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Contact {email} not found in the list. No deletion performed.");
        }
        return false;
    }
}











