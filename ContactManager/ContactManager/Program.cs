
using ContactManager.Contacts;

/// <summary>
/// The main class is responsible for running the contact application.
/// </summary>
class MainClass
{
    static void Main()
    {
        Console.WriteLine("\t \t Contact Manager App ");

        ContactValidator validator = new ContactValidator();
        ContactManager.Contacts.ContactManager Contacts_manager = new ContactManager.Contacts.ContactManager(validator);
        ConsoleUI Contacts = new ConsoleUI(Contacts_manager, validator);
        bool IsRunning = true;
        while (IsRunning)
        {
            try
            {
                int userChoice = Contacts.ShowMenu();
                switch (userChoice)
                {
                    case (int)Option.Add:
                        Contacts.AddContact();
                        break;
                    case (int)Option.Display:
                        Contacts.DisplayContacts();
                        break;
                    case (int)Option.Delete:
                        Contacts.DeleteContact();
                        break;
                    case (int)Option.Edit:
                        Contacts.EditContact();
                        break;
                    case (int)Option.Search:
                        Contacts.SearchContact();
                        break;
                    case (int)Option.DisplaySorted:
                        Contacts.DisplayInSortedOrder();
                        break;
                    case (int)Option.Exit:
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



