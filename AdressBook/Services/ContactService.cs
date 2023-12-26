using AdressBook.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Services;


public class ContactService(IFileService fileService) : IContactService

{ 
    private readonly string _filePath = @"C:\Agenda\AdressBook\content.json";

     private readonly IFileService _fileService = new FileService(@"C:\Agenda\AdressBook\content.json");
    private List<IContact> _contacts = [];

    public IFileService FileService { get; } = fileService;

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
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))

        
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
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
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }




}






