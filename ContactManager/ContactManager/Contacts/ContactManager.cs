using System.Security.Cryptography.X509Certificates;

namespace ContactManager.Contacts;

/// <summary>
/// This Class Performs the actual Add, delete, update, Display, validation, search and Sorted Search functionalities;
/// </summary>
public class ContactManager
{   
    private ContactValidator _Validator;
    /// <summary>
    /// Dependency/Object Insertion
    /// </summary>
    /// <param name="validator">EmailId_PhoneNumber_Validator</param>
    public ContactManager(ContactValidator validator)
    {
        _Validator = validator;
    }

    /// <summary>
    /// Make list private to expose only methods (Abstraction & Encapsulation)
    /// </summary>
    private IList<Contact> contactList = new List<Contact>();

    /// <summary>
    /// Creates the Contact Class Instance with the provided data and adds it to the ContactList.
    /// </summary>
    /// <param name="name">ContactName</param>
    /// <param name="phone_number">contact's_phone_number</param>
    /// <param name="emailId">Contact's EmailID</param>
    /// <param name="notes">Notes</param>
    public void AddItem(string name, string phone_number, string emailId, string notes)
    {
        contactList.Add(new Contact(name, phone_number, emailId, notes));
    }

    /// <summary>
    /// Displays all the Saved Contacts in the ContactList.
    /// </summary>
    /// <exception cref="ArgumentException">No Contacts Found</exception>
    public IList<string> Display()
    {   
        IList<string> ContactListCopy = new List<string>();
        
        if (contactList.Count != 0)
        {
            int Serial_no = 1;
            foreach (Contact person in contactList)
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
    /// <param name="Name">Contact's Name</param>
    /// <exception cref="ArgumentException">Contact Not Found.</exception>
    public void Remove(string Name)
    {
        if (contactList.Any(i => i.Name == Name))
        {   Contact contact = contactList.First(i => i.Name == Name);
            contactList.Remove(contact);   
        }
        else
        {
            throw new ArgumentException();
        }

    }

    /// <summary>
    /// Finds a specified contact & prompts users to type in Updated values for each field [Name, Phone Number,EmailID]
    /// </summary>
    /// <returns> A List of String Containing the Change report</returns>
    /// <param name="name">Contact's Name</param>
    /// <param name="email">Email to be updates</param>
    /// <param name="NameToUpdate">Name to be Updated</param>
    /// <param name="phn_number">PhoneNumber to be updated</param>
    public IList<string> Update(string name,string NameToUpdate, string phn_number, string email)
    {   
        IList<string> Message = new List<string>();
        Contact person = contactList.FirstOrDefault(i => i.Name == name);
        
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
    /// <param name="item">Any PhoneNumber or name or EmailId</param>
    public string Search(string item)
    {
        Contact Person = contactList.FirstOrDefault(i => i.Phone_number == item
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
    /// <returns>List of All Contacts with Details</returns>
    public List<string> SortedDisplay()
    {
        List<string> ContactListCopy = new List<string>();
        if (contactList.Count > 0)
        {
            foreach (Contact person in contactList.OrderBy(p => p.Name))
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">Contact's Name</param>
    /// <returns>True if Contact is Found and flase if otherwise.</returns>
    public bool IsContactPresent(string name)
    {
        Contact person = contactList.FirstOrDefault(i => i.Name == name);
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
