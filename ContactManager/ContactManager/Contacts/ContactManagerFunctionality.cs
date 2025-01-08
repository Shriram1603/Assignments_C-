namespace ContactManager.Contacts;

/// <summary>
/// This Class Performs the actual Add, delete, update, Display, validation, search and Sorted Search functionalities;
/// </summary>
public class ContactManagerFunctionality
{   
    private Validator _Validator;
    /// <summary>
    /// Dependency/Object Insertion
    /// </summary>
    /// <param name="validator"></param>
    public ContactManagerFunctionality(Validator validator)
    {
        _Validator = validator;
    }

    /// <summary>
    /// Make list private to expose only methods (Abstraction & Encapsulation)
    /// </summary>
    private List<Contact> ContactList = new List<Contact>();
   
    /// <summary>
    /// Creates the Contact Class Instance with the provided data and adds it to the ContactList.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phone_number"></param>
    /// <param name="emailId"></param>
    /// <param name="notes"></param>
    public void AddItem(string name, string phone_number, string emailId, string notes)
    {
        ContactList.Add(new Contact(name, phone_number, emailId, notes));
    }

    /// <summary>
    /// Displays all the Saved Contacts in the ContactList.
    /// </summary>
    public void Display()
    {
        Console.WriteLine("Your saved Contacts :");
        if (ContactList.Count != 0)
        {
            //y doesnt the for loop work ??
            //for (int i = 0; i > ContactList.Count(); i++)
            //    {
            //        Console.WriteLine($"{i+1}. {ContactList[i]}");
            //    }
            int Serial_no = 1;
            foreach (Contact person in ContactList)
            {
                Console.WriteLine($"\t {Serial_no}. {person}");
                Serial_no++;
            }

        }
        else
        {
            Console.WriteLine("\n[-] You Don't Have any saved contacts :(");

        }
    }

    /// <summary>
    /// Removes the Contact form the ContactList base on the Name of the contact passed to it.
    /// </summary>
    /// <param name="Name"></param>
    public void Remove(string Name)
    {
        if (ContactList.Any(i => i.Name == Name))
        {
            ContactList.RemoveAll(i => i.Name == Name);
            Console.WriteLine("\n[+] Contact Deleted Successfully");
        }
        else
        {
            Console.WriteLine("\n[-] Contact Not Found");
        }

    }

    /// <summary>
    /// Finds a specified contact & prompts users to type in Updated values for each field [Name, Phone Number,EmailID]
    /// </summary>
    /// <param name="name"></param>
    public void Update(string name)
    {
        Console.WriteLine("if you dont want to update a particular field leave it blank (just press enter) \n");
        Contact person = ContactList.FirstOrDefault(i => i.Name == name);
        Console.WriteLine($"\n[+] Updating Contact of {person.Name}");
        Console.WriteLine();
        if (person != null)
        {
            Console.WriteLine("Enter the name to update: ");
            string Name = Console.ReadLine();

            person.Name = String.IsNullOrEmpty(Name) ? person.Name : Name;

            Console.WriteLine("Enter the number to update : ");
            string phn_number = Console.ReadLine();
            if (String.IsNullOrEmpty(phn_number))
            {
                person.Phone_number = person.Phone_number;
            }
            else if (!_Validator.IsValidPhoneNumber(phn_number))
            {
                Console.WriteLine("\n[-] Invalid phone number");

            }
            else
            {
                person.Phone_number = phn_number;
            }
            Console.WriteLine("Enter the email to be updated :");
            string email = Console.ReadLine();
            if (String.IsNullOrEmpty(email))
            {
                person.EmailId = person.EmailId;
            }
            else if (!_Validator.IsValidEmail(email))
            {
                Console.WriteLine("\n[-] Invalid Email_Id");
            }
            else
            {

                person.EmailId = email;

            }

        }
        else
        {
            Console.WriteLine("\n[-] Person not found");
        }
    }
    /// <summary>
    /// Gets a string[Name or Phone_Number or EmailId] as Input and searches for the Contact
    /// </summary>
    /// <param name="item"></param>
    public void Search(string item)
    {
        Contact Person = ContactList.FirstOrDefault(i => i.Phone_number == item || i.Name.Equals(item, StringComparison.OrdinalIgnoreCase) || i.EmailId.Equals(item, StringComparison.OrdinalIgnoreCase));
        if (Person != null)
        {
            Console.WriteLine(Person);
        }
        else
        {
            Console.WriteLine($"\n[-] No Contact with the detail : {item}");
        }


    }
    /// <summary>
    /// Displays the ContactList in a Sortedby(Name) ascending order.
    /// </summary>
    public void SortedDisplay()
    {
        foreach (Contact person in ContactList.OrderBy(p => p.Name))
        {
            Console.WriteLine(person);
        }
    }
    

}
