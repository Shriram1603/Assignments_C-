using System;

namespace ContactManager.Contacts;

/// <summary>
/// The ConsoleUI class is with wich the user interacts.
/// </summary>
public class ConsoleUI
{   
    private ContactManager _ContactManager;
    private ContactValidator _Validator;

    /// <summary>
    /// Dependency injection through contructor of <see cref="ConsoleUI"/>.
    /// </summary>
    /// <param name="Manager">Object of type BaseContactManager </param>
    /// <param name="validator">Object of type EmailId_PhoneNumber_Validator</param>
    public ConsoleUI(ContactManager Manager, ContactValidator validator)
    {
        _ContactManager = Manager;
        _Validator = validator;
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
        Console.WriteLine("Enter Name :");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Phone number :");
        string phoneNumber = Console.ReadLine();
        if (!_Validator.IsValidPhoneNumber(phoneNumber))
        {
            Console.WriteLine("[-] Invalid Number");
            return;
        }
        Console.WriteLine("Enter Email ID :");
        string emailId = Console.ReadLine();
        if (!_Validator.IsValidEmail(emailId))
        {
            Console.WriteLine("\n[-] Invalid Email");
            return;
        }
        Console.WriteLine("Enter the notes you want to add :");
        string notes = Console.ReadLine();

        _ContactManager.AddContact(name, phoneNumber, emailId, notes);

    }

    /// <summary>
    /// Gets the name from the user to delete a contact
    /// </summary>
    public void DeleteContact()
    {
        try
        {
            Console.WriteLine("Enter the Contacts name that you want to Delete");
            string name = Console.ReadLine();
            _ContactManager.RemoveContact(name);
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
        Console.WriteLine("Enter the name of the contact You want to update :");
        string name = Console.ReadLine();
        if (_ContactManager.IsContactPresent(name))
        {
            Console.WriteLine($"\n[+] Updating Contact of {name}");
            Console.WriteLine("\nif you don't want to update a particular field leave it blank (just press enter) \n");
            Console.WriteLine("\nEnter the name to update: ");
            string nameToUpdate = Console.ReadLine();
            Console.WriteLine("\nEnter the number to update : ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the email to be updated :");
            string emailId = Console.ReadLine();
            IList<string> Message = _ContactManager.UpdateContact(name,nameToUpdate,phoneNumber,emailId);
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
            Console.WriteLine("Type to Search Contact :");
            var stringToSearch = Console.ReadLine();
            string searchedItem = _ContactManager.SearchContact(stringToSearch);
            Console.WriteLine(searchedItem);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Contact with details {ex.Message} Not Found.");
        }
        
    }
    /// <summary>
    /// Displays The List of Contacts
    /// </summary>
    public void DisplayContacts()
    {
        try
        {
            Console.WriteLine("Your saved Contacts :");
            IList<string> ContactList =  _ContactManager.DisplayContacts();
            foreach (string contact in ContactList)
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
    /// Displays the list of contacts in sorted order [sorted by name]
    /// </summary>
    public void DisplayInSortedOrder()
    {
        try
        {
            List<string> ContactList = _ContactManager.ShowInSortedDisplay();
            foreach(string contact in ContactList)
            {
                Console.WriteLine(contact);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[-] No Contacts Found!!");
        }
    }



}
