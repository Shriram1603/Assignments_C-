namespace ContactManager.Contacts;

/// <summary>
/// The ConsoleInterface Class is with wich the user interacts
/// </summary>
public class ConsoleInterface
{   
    
    private ContactManagerFunctionality _ContactManager;
    private Validator _Validator;

    /// <summary>
    /// Dependency Injection Through Contructor of ConsoleInterface Class
    /// </summary>
    public ConsoleInterface(ContactManagerFunctionality i, Validator validator)
    {
        _ContactManager = i;
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
        Console.WriteLine("Enter the Contacts name that you want to Delete");
        string item = Console.ReadLine();
        _ContactManager.Remove(item);

    }
    /// <summary>
    /// Gets the name from the user to UPDATE a Contact
    /// </summary>
    public void Edit()
    {
        Console.WriteLine("Enter the name of the contact You want to update :");
        var name = Console.ReadLine();
        _ContactManager.Update(name);
    }
    /// <summary>
    /// Gets one of the types [Name, Phone_number, Email_Id ] to search for that contact
    /// </summary>
    public void Search()
    {
        Console.WriteLine("Type to Search Contact :");
        var item = Console.ReadLine();
        _ContactManager.Search(item);
    }
    /// <summary>
    /// Displays The List of Contacts
    /// </summary>
    public void Display()
    {
        _ContactManager.Display();
    }
    /// <summary>
    /// Displays The List of Contacts in Sorted order [Sorted By Name]
    /// </summary>
    public void SortedSearch()
    {
        _ContactManager.SortedDisplay();
    }



}
