using static System.Console;
using dr.ConsolePad;

WriteLine("Hello, World");

Person alice = new Person("Alice", "Petersen"){    
    Age = 29
};

alice.Dump();

record Person 
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }


    public string FirstName {get;init;}
    public string LastName {get; init;}
    public int Age {get;init;}
}