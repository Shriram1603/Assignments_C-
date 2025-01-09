using System;

namespace ContactManager.Contacts;

/// <summary>
/// The ConsoleInterface Class is with wich the user interacts
/// </summary>
public class ConsoleInterface
{   
    
    private BaseContactManager _ContactManager;
    private EmailId_PhoneNumber_Validator _Validator;

    /// <summary>
    /// Dependency Injection Through Contructor of ConsoleInterface Class.
    /// </summary>
    /// <param name="Manager"></param>
    /// <param name="validator"></param>
    public ConsoleInterface(BaseContactManager Manager, EmailId_PhoneNumber_Validator validator)
    {
        _ContactManager = Manager;
        _Validator = validator;
    }

    /// <summary>
    /// Displays a Menu With List of operations available and promts user for a Choice
    /// </summary>
    /// <returns> Input of User as integer value</returns>
    public int Menu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: \n [1] - Add Contact \n [2] - Display Contacts \n [3] - Delete \n [4] - Update \n [5] - exit \n [6] - Search \n [7] - Sorted View\n");
        var UserInput = Console.ReadLine();
        int userChoice;
        if (int.TryParse(UserInput, out userChoice))
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
    /// Gets the required data from the user to ADD/SAVE a Contact
    /// </summary>
    public void AddUser()
    {
        Console.WriteLine("Enter Name :");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Phone number :");
        string phone_number = Console.ReadLine();
        if (!_Validator.IsValidPhoneNumber(phone_number))
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

        _ContactManager.AddItem(name, phone_number, emailId, notes);

    }

    /// <summary>
    /// Gets the name from the user to DELETE a Contact
    /// </summary>
    public void Delete()
    {
        try
        {
            Console.WriteLine("Enter the Contacts name that you want to Delete");
            string item = Console.ReadLine();
            _ContactManager.Remove(item);
            Console.WriteLine("\n[+] Contact Deleted Successfully");
        }
        catch 
        {
            Console.WriteLine("\n[-] Contact Not Found");
        }
        

    }
    /// <summary>
    /// Gets the name from the user to UPDATE a Contact
    /// </summary>
    public void Edit()
    {
        Console.WriteLine("Enter the name of the contact You want to update :");
        string name = Console.ReadLine();
        if (_ContactManager.IsContactPresent(name))
        {
            Console.WriteLine($"\n[+] Updating Contact of {name}");
            Console.WriteLine("\nif you don't want to update a particular field leave it blank (just press enter) \n");
            Console.WriteLine("\nEnter the name to update: ");
            string NameToUpdate = Console.ReadLine();
            Console.WriteLine("\nEnter the number to update : ");
            string phn_number = Console.ReadLine();
            Console.WriteLine("Enter the email to be updated :");
            string email = Console.ReadLine();
            _ContactManager.Update(name,NameToUpdate,phn_number,email);

        }
        else
        {
            Console.WriteLine("\n[-] Person not found");
        }
    }
    /// <summary>
    /// Gets one of the types [Name, Phone_number, Email_Id ] to search for that contact
    /// </summary>
    public void Search()
    {
        try
        {
            Console.WriteLine("Type to Search Contact :");
            var item = Console.ReadLine();
            string SearchedItem = _ContactManager.Search(item);
            Console.WriteLine(SearchedItem);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Contact with details {ex.Message} Not Found.");
        }
        
    }
    /// <summary>
    /// Displays The List of Contacts
    /// </summary>
    public void Display()
    {
        try
        {
            Console.WriteLine("Your saved Contacts :");
            List<string> ContactList =  _ContactManager.Display();
            foreach (string contact in ContactList)
            {
                Console.WriteLine($"\t {contact}");
            }
        }
        catch (Exception) 
        {
            Console.WriteLine("\n[-] You Don't Have any saved contacts :(");
        }
     }
    /// <summary>
    /// Displays The List of Contacts in Sorted order [Sorted By Name]
    /// </summary>
    public void SortedSearch()
    {
        try
        {
            List<string> ContactList = _ContactManager.SortedDisplay();
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
