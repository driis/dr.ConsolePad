using static System.Console;
using dr.ConsolePad;
using System.Collections.Generic;

Person alice = new Person("Alice", "Petersen"){ Age = 29 };
Person bob = new Person("Bob", "Johnson"){ Age = 42};
var persons = new [] {alice,bob};
persons.Dump();
alice.Dump();

42.Dump("The answer to everything");

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