using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitonTechnologies.Contacts;

/// <summary>
/// The Contact class holds an individual's name, phone number, and email ID.
/// </summary>
public class Contact
{
    public String Name { get; set; }
    public String PhoneNumber { get; set; }
    public String EmailId { get; set; }
    public String Notes { get; set; }
    
    /// <summary>
    /// Constructor of contact class
    /// </summary>
    /// <param name="name">Contact Name</param>
    /// <param name="phoneNumber">Contact's Phone Number</param>
    /// <param name="email">Vontact's EmailId</param>
    /// <param name="notes">Additional notes about the Contact Person</param>
    public Contact(string name, string phoneNumber, string email, string notes)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        EmailId = email;
        Notes = notes;

    }

    /// <summary>
    /// The String description of <see cref="Contact"/>
    /// </summary>
    /// <returns>" name = {Name} ; number = {Phone_number} ; EmailId = {EmailId}</returns>
    public override string ToString()
    {
        return $" name = {Name} ; number = {PhoneNumber} ; EmailId = {EmailId}";
    }
}
