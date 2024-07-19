using System;
using System.Linq;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        // Define the path where the XML file will be saved
        string filePath = @"C:\Users\Administrator\source\repos\QueryingXMLDatawithLINQtoXML\QueryingXMLDatawithLINQtoXML\bin\Debug\books.xml";

        // Create the XML structure using XDocument and XElement
        XDocument doc = new XDocument(
            new XElement("bookstore",
                new XElement("book",
                    new XElement("title", "Book One"),
                    new XElement("author", "John Doe"),
                    new XElement("price", 29.99)
                ),
                new XElement("book",
                    new XElement("title", "Book Two"),
                    new XElement("author", "Jane Smith"),
                    new XElement("price", 39.99)
                ),
                new XElement("book",
                    new XElement("title", "Book Three"),
                    new XElement("author", "John Doe"),
                    new XElement("price", 19.99)
                ),
                new XElement("book",
                    new XElement("title", "Book Four"),
                    new XElement("author", "John Doe"),
                    new XElement("price", 24.99)
                ),
                new XElement("book",
                    new XElement("title", "Book Five"),
                    new XElement("author", "Jane Smith"),
                    new XElement("price", 34.99)
                )
            )
        );

        // Save the XML document to the specified file path
        doc.Save(filePath);

        Console.WriteLine($"XML file successfully created and saved to {filePath}");

        // Load the XML data into an XDocument
        doc = XDocument.Load(filePath);

        // Use LINQ to select and print titles of all books authored by "John Doe"
        var johnDoeBooks = from book in doc.Descendants("book")
                           where (string)book.Element("author") == "John Doe"
                           select book.Element("title").Value;

        Console.WriteLine("Books authored by John Doe:");
        foreach (var title in johnDoeBooks)
        {
            Console.WriteLine(title);
        }

        // Find and print the average price of all books
        var averagePrice = doc.Descendants("book")
                              .Average(book => (double)book.Element("price"));

        Console.WriteLine($"Average price of all books: {averagePrice:F2}");
    }
}
