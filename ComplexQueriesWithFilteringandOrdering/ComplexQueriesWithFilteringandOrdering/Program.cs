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

        var personsOver30 = from person in persons
                            where person.Age > 30
                            select person;

        Console.WriteLine("Persons over 30:");
        foreach (var person in personsOver30)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }

        var sortedPersons = from person in persons
                            orderby person.LastName, person.FirstName
                            select person;

        Console.WriteLine("\nSorted list of persons:");
        foreach (var person in sortedPersons)
        {
            Console.WriteLine(person);
        }
    }
}
