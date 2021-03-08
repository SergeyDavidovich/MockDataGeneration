
// https://jackhiston.com/2017/10/1/how-to-create-bogus-data-in-c/
// https://entityframeworkcore.com/providers-inmemory

using System;
using System.Collections.Generic;
using Bogus;
using Newtonsoft.Json;
using MockDataGeneration.Model;
using Microsoft.EntityFrameworkCore;

namespace MockDataGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fakeProvider = new FakeDataGenerator();

            var categories = fakeProvider.Categories;
            var products = fakeProvider.Products;

            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "Test")
                    .Options;
            
            string json;
            
            using (var context = new AppDbContext(options))
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();

                json = JsonConvert.SerializeObject(context.Categories, Formatting.Indented);
            }
                Console.WriteLine(json);
        }
    }
}
