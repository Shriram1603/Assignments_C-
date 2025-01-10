using System;
using System.Xml.Linq;

namespace ContactManager.Contacts;

/// <summary>
/// The ConsoleUI class is with wich the user interacts in console.
/// </summary>
public class ConsoleUI
{   
    private ContactManager _contactManager;
    private ContactValidator _validator;

    /// <summary>
    /// Dependency injection through contructor of <see cref="ConsoleUI"/>.
    /// </summary>
    /// <param name="manager">Object of type BaseContactManager </param>
    /// <param name="validator">Object of type EmailId_PhoneNumber_Validator</param>
    public ConsoleUI(ContactManager manager, ContactValidator validator)
    {
        _contactManager = manager;
        _validator = validator;
    }

    /// <summary>
    /// Displays a menu with list of operations available and promts user for a choice
    /// </summary>
    /// <returns> Input of user as integer value</returns>
    public int ShowMenu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: " +
                          "\n [1] - Add Contact " +
                          "\n [2] - Display Contacts " +
                          "\n [3] - Delete " +
                          "\n [4] - Update " +
                          "\n [5] - Search " +
                          "\n [6] - Sorted View " +
                          "\n [7] - exit\n");
        var userInput = Console.ReadLine();
        int userChoice;
        if (int.TryParse(userInput, out userChoice))
        {
            return userChoice;
        }
        else
        {
            Console.WriteLine("Cannot Convert to Integer");
            return 0;
        }
    }

    /// <summary>
    /// Gets the required data from the user to add/save a contact
    /// </summary>
    public void AddContact()
    {
        string name = GetName();
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
        {
            Console.WriteLine("[-] Name Cannot be Empty");
            return;
        }
        string phoneNumber = GetPhoneNumber();
        if (!_validator.IsValidPhoneNumber(phoneNumber))
        {
            Console.WriteLine("[-] Invalid Number");
            return;
        }
        string emailId = GetEmailId();
        if (!_validator.IsValidEmail(emailId))
        {
            Console.WriteLine("\n[-] Invalid Email");
            return;
        }
        string notes = GetNotes();
        _contactManager.AddContact(name, phoneNumber, emailId, notes);
    }

    /// <summary>
    /// Gets the name from the user to delete a contact
    /// </summary>
    public void DeleteContact()
    {
        try
        {
            Console.Write("Enter the Contact's name that you want to Delete :");
            string name = Console.ReadLine();
            _contactManager.RemoveContact(name);
            Console.WriteLine("\n[+] Contact Deleted Successfully");
        }
        catch 
        {
            Console.WriteLine("\n[-] Contact Not Found");
        }
    }

    /// <summary>
    /// Gets the name from the user to update a contact
    /// </summary>
    public void EditContact()
    {
        Console.Write("Enter the name of the contact You want to update :");
        string name = Console.ReadLine();
        if (_contactManager.IsContactPresent(name))
        {
            Console.WriteLine($"\n[+] Updating Contact of {name}");
            Console.WriteLine("\nif you don't want to update a particular field leave it blank (just press enter) \n");

            Console.Write($"\nEnter the name to update : ");
            string nameToUpdate = Console.ReadLine();

            Console.Write("\nEnter the number to update : ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter the email to be updated :");
            string emailId = Console.ReadLine();
            IList<string> Message = _contactManager.UpdateContact(name,nameToUpdate,phoneNumber,emailId);
            foreach (string message in Message)
            {
                Console.WriteLine(message);
            }
        }
        else
        {
            Console.WriteLine("\n[-] Person not found");
        }
    }

    /// <summary>
    /// Gets one of the types [name, phone_number, email_id ] to search for that contact
    /// </summary>
    public void SearchContact()
    {
        try
        {
            Console.Write("Type [Name or phoneNumber or EmailId] to Search Contact :");
            var stringToSearch = Console.ReadLine();
            Contact searchedContact = _contactManager.SearchContact(stringToSearch);
            Console.WriteLine($" name = {searchedContact.Name} ; " +
                $"number = {searchedContact.PhoneNumber} ; " +
                $"EmailId = {searchedContact.EmailId}; " +
                $"Notes : {searchedContact.Notes}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Contact with details {ex.Message} Not Found.");
        }
    }

    /// <summary>
    /// Displays Contacts held by <see cref="ContactManager"/>
    /// </summary>
    public void DisplayContacts()
    {
        try
        {
            Console.WriteLine("Your saved Contacts :");
            IList<string> contactList =  _contactManager.DisplayContacts();
            foreach (string contact in contactList)
            {
                Console.WriteLine($"\t {contact}");
            }
        }
        catch (Exception ) 
        {
            Console.WriteLine("\n[-] You Don't Have any saved contacts :(");
        }
     }
    /// <summary>
    /// Displays the list of contacts held by <see cref="ContactManager"/> in sorted order [sorted by name]
    /// </summary>
    public void DisplayInSortedOrder()
    {
        try
        {
            List<string> contactList = _contactManager.ShowInSortedDisplay();
            foreach(string contact in contactList)
            {
                Console.WriteLine(contact);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[-] No Contacts Found!!");
        }
    }

    private string GetName()
    {
        Console.Write("Enter Name :");
        string name = Console.ReadLine();
        return name;
    }

    private string GetPhoneNumber()
    {
        Console.Write("Enter PhoneNumber :");
        string phoneNumber = Console.ReadLine();
        return phoneNumber;
    }

    private string GetEmailId()
    {
        Console.Write("Enter EmailId :");
        string emailId = Console.ReadLine();
        return emailId;
    }

    private string GetNotes()
    {
        Console.Write("Enter Notes :");
        string notes = Console.ReadLine();
        return notes;
    }
}
