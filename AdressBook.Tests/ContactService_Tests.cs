

using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Services;
using Moq;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AdressBook.Tests;

public class ContactService_Tests
{
    [Fact]

    public void AddContactToList_ShouldAddOneContactToContactList_ThenReturnTrue()
    {
        //Arrange

        IContact contact = new Contact { FirstName = "Felicia", LastName = "Zidaru", Email = "fely@domain.com", PhoneNumber = "0736478972", Adress = "Bjuv, Storgatan 2b" };
        var mockFileService = new Mock<IFileService>();
        IContactService contactService = new ContactService(mockFileService.Object);

        //Act

        bool result = contactService.AddContactToList(contact);
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void GetAllContactsFromListShould_GetAllContactFromContactsList_ThenReturnTheListOfContacts()
    {
        // Arrange

        var json = "[{\"$type\":\"AdressBook.Models.Contact, AdressBook\",\"Id\":0,\"FirstName\":\"Felicia\",\"LastName\":\"Zidaru\",\"Email\":\"fely@domain.com\",\"PhoneNumber\":\"0736478572\",\"Adress\":\"Bjuv, Storgatan 2b\"}]";
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContentFromFile(It.IsAny<string>())).Returns(json);
        IContactService contactService = new ContactService(mockFileService.Object);


        // Act
        IEnumerable<IContact> result = contactService.GetAllContactsFromList();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        IContact returnedContact = result.FirstOrDefault()!;
        Assert.Equal(0, returnedContact.Id);
    }


    [Fact]
public void ContactDetailOption_GetASingleContactFromContactList_ThenReturnContactList()
{
    // Arrange
    var contacts = new List<IContact>
    {
        new Contact { Id = 0, FirstName = "Felicia", LastName = "Zidaru", Email = "fely@domain.com", PhoneNumber = "0736478972", Adress = "Bjuv, Storgatan 2b" }
    };

    var json = JsonConvert.SerializeObject(contacts, Formatting.None,
          new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

    var mockFileService = new Mock<IFileService>();
    mockFileService.Setup(x => x.GetContentFromFile(It.IsAny<string>())).Returns(json);

    IContactService contactService = new ContactService(mockFileService.Object);

    // Act
    var result = contactService.ContactDetailOption("fely@domain.com");

    // Assert
    Assert.NotNull(result);
    Assert.Equal("fely@domain.com", result.Email);
}

   
 
}


