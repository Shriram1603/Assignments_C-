using OOPs.EmployeeHierarchy;
using OOPs.ShapeHierarchy;
using OOPs.BankingSystem;

//Shows the Working of ShapeHierarchy
Console.WriteLine("\n[1] - task1 : ShapeHierarchy :");
Rectangle rectangle = new Rectangle("Blue", 4, 7);
Circle circle = new Circle("Yellow", 5.3);
rectangle.PrintDetails();
circle.PrintDetails();

//Shows the Working of EmployeeHierarchy
Console.WriteLine("\n[2] - task2 : EmployeeHierarchy :");
Random rand = new Random();
Developer developer = new Developer("Shriram",100000.123m,rand);
Manager manager = new Manager("Bala",200000.345m,rand);
developer.PrintDisplay();
manager.PrintDisplay();

//Shows the Working of BankingSystem
Console.WriteLine("\n[3] - task3 : Banking System :");
BankAccount savingsAccount = new SavingsAccount("12345", 20000);
Console.WriteLine("\nSaving Account :");
savingsAccount.WithDraw(10000);
savingsAccount.WithDraw(10000);
savingsAccount.Deposit(5000);

Console.WriteLine("\nChecking Account :");
BankAccount checkingAccount = new CheckingAccount("123456", 20000);
checkingAccount.WithDraw(25000);
checkingAccount.Deposit(4000);


