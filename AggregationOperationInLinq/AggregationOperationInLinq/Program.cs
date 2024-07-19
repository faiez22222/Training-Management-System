using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Person> persons = new List<Person>
        {
            new Person("John", "Doe", 25),
            new Person("Jane", "Doe", 35),
            new Person("Alice", "Smith", 40),
            new Person("Bob", "Johnson", 30),
            new Person("Charlie", "Brown", 45)
        };

        double averageAge = persons.Average(person => person.Age);
        Console.WriteLine($"Average age of all persons: {averageAge}");

        var oldestPerson = persons.OrderByDescending(person => person.Age).First();
        var youngestPerson = persons.OrderBy(person => person.Age).First();

        Console.WriteLine($"Oldest person: {oldestPerson.FirstName} {oldestPerson.LastName}");
        Console.WriteLine($"Youngest person: {youngestPerson.FirstName} {youngestPerson.LastName}");
    }
}
