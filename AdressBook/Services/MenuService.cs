
using AdressBook.Interfaces;
using AdressBook.Models;
using System.Diagnostics.Contracts;


namespace AdressBook.Services
{
    public interface IMenuService
    {
        void Show_MenuOptions();
    }

    public class MenuService : IMenuService

    {
        private static readonly IFileService _fileService = new FileService();
        private static readonly IContactService _contactService = new ContactService(_fileService);

        public void Show_MenuOptions()
        {
            while (true)
            {
                DisplayTitleMenu("CONTACT MANAGER MENU");
                Console.WriteLine($"{"1.",-3} Add new contact");
                Console.WriteLine($"{"2.",-3} List all contacts");
                Console.WriteLine($"{"3.",-3} Display detailed information about a contact");
                Console.WriteLine($"{"4.",-3} Delete a contact by email address");
                Console.WriteLine($"{"0.",-3} Exit menu");
                Console.WriteLine();
                Console.Write("Choose an option:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Show_AddContactOption();
                        break;

                    case "2":
                        Show_GetAllContactsFromList();
                        break;

                    case "3":
                        Show_ContactDetailOption();
                        break;

                    case "4":
                        Show_DeleteContactOption();
                        break;

                    case "0":
                        Show_ExitApplicationOption();
                        break;

                    default:
                        Console.WriteLine("\nInvalid option chosen. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Show_GetAllContactsFromList()
        {
            var contacts = _contactService?.GetAllContactsFromList() ?? new List<IContact>();

            DisplayTitleMenu("Contact list");
            if (!contacts.Any())
            {
                Console.WriteLine("No contacts found");
                Console.WriteLine("\n");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Contact information: {contact.Email} {contact.PhoneNumber} {contact.Adress}");
                  
                    Console.WriteLine("\n");
                }
            }


            DisplayPressAnyKey();
        }

        private void Show_AddContactOption()
        {
            IContact contact = new Contact();

            DisplayTitleMenu("Add new contact");

            Console.Write("First name: ");
            contact.FirstName = Console.ReadLine()!;

            Console.Write("Last name: ");
            contact.LastName = Console.ReadLine()!;

            Console.Write("Email adress: ");
            contact.Email = Console.ReadLine()!;

            Console.Write("Phone number: ");
            contact.PhoneNumber = Console.ReadLine()!;

            Console.Write("Adress: ");
            contact.Adress = Console.ReadLine()!;

            
            var res = _contactService.AddContactToList(contact);


            DisplayPressAnyKey();
        }

        private void Show_ContactDetailOption()
        {
            DisplayTitleMenu("---Display Contact Details---");
            Console.WriteLine("Enter email address: ");
            string firstName = Console.ReadLine()!;
            IContact contact = _contactService.ContactDetailOption(firstName);

            if (contact == null)
            {
                Console.WriteLine("Can't find a contact with that name");
            }
            else
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{contact.Email} {contact.PhoneNumber}");
                Console.WriteLine($"{contact.Adress} ");
                Console.WriteLine("\n\n");
            }
            DisplayPressAnyKey();
        }

        private void Show_DeleteContactOption()
        {
            DisplayTitleMenu("---Delete contact---");

            Console.WriteLine("Enter the email of the contact you want to delete");

            string email = Console.ReadLine()!;

            bool isRemoved = _contactService.DeleteContactOption(email);
            if (isRemoved)
            {
                Console.WriteLine("Contact deleted.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

            DisplayPressAnyKey();
        }

        private void Show_ExitApplicationOption()
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit? (y/n)");
            var option = Console.ReadLine() ?? "";
            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

       


        private void DisplayTitleMenu(string title)
        {
            Console.Clear();
            Console.WriteLine($"---{title}---");
            Console.WriteLine();
        }

        private void DisplayPressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

