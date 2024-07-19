using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (BloggingContext context = new BloggingContext())
            {
                var Blogs = context.Blogs.ToList();
                foreach (var Blog in Blogs) 
                    {
                        Console.WriteLine($"{ Blog.BlogName} , {Blog.BlogType} , {Blog.BlogDescription}");
                    }
            }
        }
    }
}
