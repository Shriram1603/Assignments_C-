using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Contacts;

/// <summary>
/// The Contact type/object holds Name , phone number and email ID of an individual.
/// Pass (Name, Phone Number, EmailId, Notes) as Parameter to Contructor
/// </summary>
public class Contact
{
    public String Name { get; set; }
    public String Phone_number { get; set; }
    public String EmailId { get; set; }
    public String Notes { get; set; }
    
    /// <summary>
    /// Constructor of Contact class
    /// </summary>
    /// <param name="name">Contact Name</param>
    /// <param name="ph_number">Contact's Phone Number</param>
    /// <param name="email">Vontact's EmailId</param>
    /// <param name="notes">Additional notes about the Contact Person</param>
    public Contact(string name, string ph_number, string email, string notes)
    {
        Name = name;
        Phone_number = ph_number;
        EmailId = email;
        Notes = notes;

    }

    /// <summary>
    /// The String description of Contact Object
    /// </summary>
    /// <returns>" name = {Name} ; number = {Phone_number} ; EmailId = {EmailId}</returns>
    public override string ToString()
    {
        return $" name = {Name} ; number = {Phone_number} ; EmailId = {EmailId}";
    }
}
