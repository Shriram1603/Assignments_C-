
using ContactManager.Contacts;

/// <summary>
/// Switched to Main() rather than Top Level Statements.
/// </summary>
class MainContactManager
{
    static void Main()
    {
        Console.WriteLine("\t \t Contact Manager App ");

        ContactValidator validator = new ContactValidator();
        ContactManager.Contacts.ContactManager Contacts_manager = new ContactManager.Contacts.ContactManager(validator);
        ConsoleUI UserCommunication = new ConsoleUI(Contacts_manager, validator);
        bool IsRunning = true;
        while (IsRunning)
        {
            try
            {
                int userChoice = UserCommunication.Menu();
                switch (userChoice)
                {
                    case 1:
                        UserCommunication.AddUser();
                        break;
                    case 2:
                        UserCommunication.DisplayContacts();
                        break;

                    case 3:
                        UserCommunication.Delete();
                        break;

                    case 4:
                        UserCommunication.Edit();
                        break;
                    case 5:
                        IsRunning = false;
                        break;
                    case 6:
                        UserCommunication.Search();
                        break;
                    case 7:
                        UserCommunication.SortedSearch();
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



