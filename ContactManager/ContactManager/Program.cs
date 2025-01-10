
using SolitonTechnologies.Contacts;

/// <summary>
/// The <see cref="Program"/> class is responsible for running the contact application.
/// </summary>
class Program
{
    static void Main()
    {
        Console.WriteLine("\t \t Contact Manager App ");

        ContactValidator validator = new ContactValidator();
        ContactManager cntactsMnager = new ContactManager(validator);
        ConsoleUI Contacts = new ConsoleUI(cntactsMnager, validator);
        bool IsRunning = true;
        while (IsRunning)
        {
            try
            {
                UserChoice userChoice = (UserChoice)Contacts.ShowMenu();
                switch (userChoice)
                {
                    case UserChoice.Add:
                        Contacts.AddContact();
                        break;
                    case UserChoice.Display:
                        Contacts.DisplayContacts();
                        break;
                    case UserChoice.Delete:
                        Contacts.DeleteContact();
                        break;
                    case UserChoice.Edit:
                        Contacts.EditContact();
                        break;
                    case UserChoice.Search:
                        Contacts.SearchContact();
                        break;
                    case UserChoice.DisplaySorted:
                        Contacts.DisplayInSortedOrder();
                        break;
                    case UserChoice.Exit:
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("[-] That Feature is not available Yet !! ");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[-] Enter a Valid Choice as numbber ");
            }
        }
        Console.WriteLine("Thank You !!");
        Console.ReadKey();
    }
}



