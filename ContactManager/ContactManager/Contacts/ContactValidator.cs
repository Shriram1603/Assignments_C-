namespace ContactManager.Contacts;

/// <summary>
/// Validator class to validate phone number and emailId
/// </summary>
public class ContactValidator
{
    /// <summary>
    /// Validates emailId by checking if .com is present at the end to the string and if it contains @
    /// </summary>
    /// <param name="email">Contacts emailId</param>
    /// <returns>True if Valid. False if Invalid.</returns>
    public bool IsValidEmail(string email) => email.Contains("@") && email.Substring(email.Length - 4) == ".com";

    /// <summary>
    /// Validates PhoneNumber by checking if the length of the the phone number is exactly 10 and contains only digits
    /// </summary>
    /// <param name="phoneNumber">Contacts phone number</param>
    /// <returns>True if Valid. False if Invalid.</returns>
    public bool IsValidPhoneNumber(string phoneNumber) => phoneNumber.Length == 10 && phoneNumber.All(Char.IsDigit);
}
