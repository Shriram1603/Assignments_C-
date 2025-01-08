
using ContactManager.Contacts;

Console.WriteLine("\t \t Contact Manager App ");

Validator obj3 = new Validator();
ContactManagerFunctionality obj2 = new ContactManagerFunctionality(obj3);
ConsoleInterface obj1 = new ConsoleInterface(obj2,obj3);
bool IsRunning = true;
while (IsRunning) 
{
    try
    {
        int userChoice = obj1.Menu();
        switch (userChoice)
        {
            case 1:
                obj1.AddUser();
                break;
            case 2:
                obj1.Display();
                break;

            case 3:
                obj1.Delete();
                break;

            case 4:
                obj1.Edit();
                break;
            case 5:
                IsRunning = false;
                break;
            case 6:
                obj1.Search();
                break;
            case 7:
                obj1.SortedSearch();
                break;
            default:
                Console.WriteLine("[-] That Feature is not available Yet !! ");
                break;

        }
    }
    catch(Exception e)
    {
        Console.WriteLine("[-] Enter a Valid Choice as numbber ");
    }

}
Console.WriteLine("Thank You !!");
Console.ReadKey();

