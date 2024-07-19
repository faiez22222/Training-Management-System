using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Alice", Age = 20, Grade = 88.5 },
            new Student { StudentId = 2, Name = "Bob", Age = 17, Grade = 90.0 },
            new Student { StudentId = 3, Name = "Charlie", Age = 19, Grade = 85.0 },
            new Student { StudentId = 4, Name = "David", Age = 21, Grade = 95.0 },
            new Student { StudentId = 5, Name = "Eve", Age = 18, Grade = 92.5 },
        };

        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "John", Department = "HR", Salary = 50000 },
            new Employee { EmployeeId = 2, Name = "Jane", Department = "Finance", Salary = 60000 },
            new Employee { EmployeeId = 3, Name = "Joe", Department = "HR", Salary = 55000 },
            new Employee { EmployeeId = 4, Name = "Jill", Department = "IT", Salary = 70000 },
            new Employee { EmployeeId = 5, Name = "Jack", Department = "Finance", Salary = 65000 },
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Parse("2021-01-01"), Amount = 100 },
            new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Parse("2021-02-01"), Amount = 200 },
            new Order { OrderId = 3, CustomerId = 1, OrderDate = DateTime.Parse("2021-03-01"), Amount = 150 },
            new Order { OrderId = 4, CustomerId = 3, OrderDate = DateTime.Parse("2021-04-01"), Amount = 250 },
            new Order { OrderId = 5, CustomerId = 2, OrderDate = DateTime.Parse("2021-05-01"), Amount = 300 },
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Tom", City = "New York" },
            new Customer { CustomerId = 2, Name = "Jerry", City = "Los Angeles" },
            new Customer { CustomerId = 3, Name = "Spike", City = "Chicago" },
        };

        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Category = "Electronics", Price = 1200.99, Stock = 10 },
            new Product { ProductId = 2, ProductName = "Smartphone", Category = "Electronics", Price = 799.99, Stock = 5 },
            new Product { ProductId = 3, ProductName = "Tablet", Category = "Electronics", Price = 499.99, Stock = 3 },
            new Product { ProductId = 4, ProductName = "Headphones", Category = "Accessories", Price = 199.99, Stock = 15 },
            new Product { ProductId = 5, ProductName = "Monitor", Category = "Electronics", Price = 299.99, Stock = 7 },
            new Product { ProductId = 6, ProductName = "Mouse", Category = "Accessories", Price = 49.99, Stock = 25 },
            new Product { ProductId = 7, ProductName = "Keyboard", Category = "Accessories", Price = 79.99, Stock = 18 },
            new Product { ProductId = 8, ProductName = "Chair", Category = "Furniture", Price = 149.99, Stock = 20 },
            new Product { ProductId = 9, ProductName = "Desk", Category = "Furniture", Price = 249.99, Stock = 5 },
            new Product { ProductId = 10, ProductName = "USB Cable", Category = "Accessories", Price = 9.99, Stock = 50 }
        };

        // Use the sample data to practice your LINQ queries
        var studentOlderThan18 = students.Where(s => s.Age > 18).Select(s=>s.Name);
        foreach (string str in studentOlderThan18)
        {
            Console.WriteLine(str); 
        }

        var sortedStudent = students.OrderByDescending(s => s.Grade).ThenBy(s=>s.Name);
        foreach (var student in sortedStudent)
        {
            Console.WriteLine($"{student.Name}: {student.Grade}");
        }
        var topThreeStudent = sortedStudent.Take(3).Select(s=> new {s.Name , s.Grade });
        foreach (var student in topThreeStudent)
        {
            Console.WriteLine($"{student.Name}: {student.Grade}");
        }

        var employeeGroupByDepartment = employees.GroupBy(s=>s.Department).Select(g=> new {Department = g.Key , Count = g.Count() } );
        foreach (var student in employeeGroupByDepartment)
        {
            Console.WriteLine($"{student.Department}: {student.Count}");
        }

        var averageSalaryByDepartment = employees.GroupBy(s=>s.Department).Select(g=>new {Department = g.Key , AverageSalary = g.Average(s=>s.Salary) });
        foreach (var student in averageSalaryByDepartment)
        {
            Console.WriteLine($"{student.Department}: {student.AverageSalary}");
        }

        var highestSalaryInDepartment = employees.GroupBy(s=>s.Department).Select(g=>new {Department = g.Key , HighestSalary = g.Max(k=>k.Salary) });
        foreach (var student in highestSalaryInDepartment)
        {
            Console.WriteLine($"{student.Department}: {student.HighestSalary}");
        }

        var orderDetails = orders.Join(customers , o=>o.CustomerId ,c=>c.CustomerId , (o,c)=>new {o.OrderId ,CustomerName = c.Name , o.OrderDate });
        foreach (var student in orderDetails)
        {
            Console.WriteLine($"{student.OrderId }  ,{student.CustomerName } , {student.OrderDate}");
        }

        var totalOrderAmount = orders.GroupBy(o => o.CustomerId).Join(customers, g => g.Key, c => c.CustomerId, (g, c) => new { c.Name, TotalAmount = g.Sum(k => k.Amount) });
        foreach (var student in totalOrderAmount)
        {
            Console.WriteLine($"{student.Name}  ,{student.TotalAmount} ");
        }
        var moreThanFiveOrders = orders.GroupBy(o => o.CustomerId).Where(g=>g.Count() > 1).Join(customers , g=>g.Key , c=>c.CustomerId,(g,c)=> new {c.Name } );
        foreach (var student in moreThanFiveOrders)
        {
            Console.WriteLine($"{student.Name}  ");
        }
    }   
}
