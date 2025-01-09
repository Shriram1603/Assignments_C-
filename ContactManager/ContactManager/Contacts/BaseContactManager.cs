using System.Security.Cryptography.X509Certificates;

namespace ContactManager.Contacts;

/// <summary>
/// This Class Performs the actual Add, delete, update, Display, validation, search and Sorted Search functionalities;
/// </summary>
public class BaseContactManager
{   
    private EmailId_PhoneNumber_Validator _Validator;
    /// <summary>
    /// Dependency/Object Insertion
    /// </summary>
    /// <param name="validator"></param>
    public BaseContactManager(EmailId_PhoneNumber_Validator validator)
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
    public List<string> Display()
    {   
        List<string> ContactListCopy = new List<string>();
        
        if (ContactList.Count != 0)
        {
            int Serial_no = 1;
            foreach (Contact person in ContactList)
            {
                ContactListCopy.Add($"{Serial_no}. {person}");
                Serial_no++;
            }
            return ContactListCopy;
        }
        else
        {
            throw new ArgumentException();
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
        }
        else
        {
            throw new ArgumentException();
        }

    }

    /// <summary>
    /// Finds a specified contact & prompts users to type in Updated values for each field [Name, Phone Number,EmailID]
    /// </summary>
    /// <param name="name"></param>
    public List<string> Update(string name,string NameToUpdate, string phn_number, string email)
    {   
        List<string> Message = new List<string>();
        Contact person = ContactList.FirstOrDefault(i => i.Name == name);
        
        person.Name = String.IsNullOrEmpty(NameToUpdate) ? person.Name : NameToUpdate;
        if (person.Name != NameToUpdate)
        {
            Message.Add("\n[-] Empty Name - No changes Occured");
        }

        person.Phone_number = !String.IsNullOrEmpty(phn_number)
                           || !String.IsNullOrWhiteSpace(phn_number)
                           && _Validator.IsValidPhoneNumber(phn_number) ? phn_number : person.Phone_number;
        if (person.Phone_number != phn_number)
        {
            Message.Add("\n[-] Invalid or Empty phone number - No changes Occured");
        }
        person.EmailId = !String.IsNullOrEmpty(email) 
                      || !String.IsNullOrWhiteSpace(email)
                      && _Validator.IsValidEmail(email) ? email : person.EmailId;
        
        if (email != person.EmailId)
        {
            Message.Add("\n[-] Empty or Invalid Email_Id - No changes Occured");
        }
        return Message;
        
    }



    /// <summary>
    /// Gets a string[Name or Phone_Number or EmailId] as Input and searches for the Contact
    /// </summary>
    /// <param name="item"></param>
    public string Search(string item)
    {
        Contact Person = ContactList.FirstOrDefault(i => i.Phone_number == item
                        || i.Name.Equals(item, StringComparison.OrdinalIgnoreCase) 
                        || i.EmailId.Equals(item, StringComparison.OrdinalIgnoreCase));

        if (Person != null)
        {
            return($"{Person}");
        }
        else
        {
            throw new ArgumentException(item);
        }


    }
    /// <summary>
    /// Displays the ContactList in a Sortedby(Name) ascending order.
    /// </summary>
    public List<string> SortedDisplay()
    {
        List<string> ContactListCopy = new List<string>();
        if (ContactList.Count > 0)
        {
            foreach (Contact person in ContactList.OrderBy(p => p.Name))
            {
                ContactListCopy.Add($"{person}");
            }
            return ContactListCopy;
        }
        else
        {
            throw new ArgumentException();
        }
        
    }

    public bool IsContactPresent(string name)
    {
        Contact person = ContactList.FirstOrDefault(i => i.Name == name);
        if (person != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
