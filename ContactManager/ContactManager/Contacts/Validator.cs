namespace ContactManager.Contacts;

/// <summary>
/// Validator Class to Validate Phone Number and EmailId
/// </summary>
public class Validator
{
    /// <summary>
    /// Validates EmailId by checking if .com is present at the end to the string and if it contains @
    /// </summary>
    /// <param name="email"></param>
    /// <returns>True if Valid. False if Invalid.</returns>
    public bool IsValidEmail(string email) => email.Contains("@") && email.Substring(email.Length - 4) == ".com";

    /// <summary>
    /// Validates PhoneNumber by checking if the length of the the phone number is exactly 10 and contains only digits
    /// </summary>
    /// <param name="phone_number"></param>
    /// <returns>True if Valid. False if Invalid.</returns>
    public bool IsValidPhoneNumber(string phone_number) => phone_number.Length == 10 && phone_number.All(Char.IsDigit);
}
