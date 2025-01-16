using System.Security.Cryptography.X509Certificates;
namespace SolitonTechnologies.Contacts;

/// <summary>
/// This class performs the actual CRUD, search and sorted_display functionalities;
/// </summary>
public class ContactManager
{
    private IList<Contact> _contactList = new List<Contact>();
    private ContactValidator _validator;

    /// <summary>
    /// Constructor of <see cref="ContactManager"/>
    /// </summary>
    /// <param name="validator">Contact_Validator<see cref="ContactValidator"/></param>
    public ContactManager(ContactValidator validator)
    {
        _validator = validator;
    }

    /// <summary>
    /// Creates the contact class instance with the provided data and adds it to the <see cref="_contactList"/>.
    /// </summary>
    /// <param name="name">ContactName</param>
    /// <param name="phoneNumber">contact's_phone_number</param>
    /// <param name="emailId">Contact's EmailID</param>
    /// <param name="notes">Notes</param>
    public void AddContact(string name, string phoneNumber, string emailId, string notes)
    {
        _contactList.Add(new Contact(name, phoneNumber, emailId, notes));
    }

    /// <summary>
    /// Displays all the saved contacts in the <see cref="_contactList"/>.
    /// </summary>
    /// <exception cref="ArgumentException">No Contacts Found</exception>
    public IList<string> DisplayContacts()
    {   
        IList<string> contactListCopy = new List<string>();
        
        if (_contactList.Count != 0)
        {
            int serialNumber = 1;
            foreach (Contact person in _contactList)
            {
                contactListCopy.Add($"{serialNumber}. {person}");
                serialNumber++;
            }
            return contactListCopy;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    /// <summary>
    /// Removes the contact form the <see cref="_contactList"/> based on the name of the contact passed to it.
    /// </summary>
    /// <param name="name">Contact's name</param>
    /// <exception cref="ArgumentException">Contact not found.</exception>
    public void RemoveContact(string name)
    {
        if (_contactList.Any(i => i.Name == name))
        {   Contact contact = _contactList.First(i => i.Name == name);
            _contactList.Remove(contact);   
        }
        else
        {
            throw new ArgumentException();
        }

    }

    /// <summary>
    /// Finds a specified contactact in <see cref="_contactList"/> and update the contact based on the provided params
    /// </summary>
    /// <returns> A List of String Containing the Change report</returns>
    /// <param name="name">Contact's Name</param>
    /// <param name="emailId">Email to be updates</param>
    /// <param name="nameToUpdate">Name to be Updated</param>
    /// <param name="phoneNumber">PhoneNumber to be updated</param>
    public IList<string> UpdateContact(string name,string nameToUpdate, string phoneNumber, string emailId)
    {   
        IList<string> message = new List<string>();
        Contact person = _contactList.FirstOrDefault(i => i.Name == name);
        person.Name = _validator.IsValidName(name) ? person.Name : nameToUpdate;
        if (person.Name != nameToUpdate)
        {
            message.Add("\n[-] Empty Name - No changes Occured");
        }
        person.PhoneNumber = !String.IsNullOrEmpty(phoneNumber)
                           || !String.IsNullOrWhiteSpace(phoneNumber)
                           && _validator.IsValidPhoneNumber(phoneNumber) ? phoneNumber : person.PhoneNumber;
        if (person.PhoneNumber != phoneNumber)
        {
            message.Add("\n[-] Invalid or Empty phone number - No changes Occured");
        }
        person.EmailId = !String.IsNullOrEmpty(emailId) 
                      || !String.IsNullOrWhiteSpace(emailId)
                      && _validator.IsValidEmail(emailId) ? emailId : person.EmailId;
 
        if (emailId != person.EmailId)
        {
            message.Add("\n[-] Empty or Invalid Email_Id - No changes Occured");
        }
        return message;
    }

    /// <summary>
    /// Gets a string[name or phone_number or emailId] as Input and searches for the contact in <see cref="_contactList"/>
    /// </summary>
    /// <param name="stringToSearch">Any PhoneNumber or name or EmailId</param>
    public Contact SearchContact(string stringToSearch)
    {
        Contact person = _contactList.FirstOrDefault(i => i.PhoneNumber == stringToSearch
                        || i.Name.Equals(stringToSearch, StringComparison.OrdinalIgnoreCase) 
                        || i.EmailId.Equals(stringToSearch, StringComparison.OrdinalIgnoreCase));
        if (person != null)
        {
            return(person);
        }
        else
        {
            throw new ArgumentException(stringToSearch);
            
        }
    }

    /// <summary>
    /// Displays the <see cref="_contactList"/> in a sortedby(name) ascending order.
    /// </summary>
    /// <returns>List of All Contacts with Details</returns>
    public IList<string> SortedContacts()
    {
        IList<string> sortedContacts = new List<string>();
        if (_contactList.Count > 0)
        {
            foreach (Contact person in _contactList.OrderBy(p => p.Name))
            {
                sortedContacts.Add($"{person}");
            }
            return sortedContacts;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    /// <summary>
    /// Checks if contact is present in the <see cref="_contactList"/>
    /// </summary>
    /// <param name="name">Contact's Name</param>
    /// <returns>True if Contact is Found and flase if otherwise.</returns>
    public bool IsContactPresent(string name)
    {
        Contact person = _contactList.FirstOrDefault(i => i.Name == name);
        return person != null;
    }
}
