using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using MockDataGeneration.Model;


namespace MockDataGeneration
{
    public partial class FakeDataProvider
    {
        public FakeDataProvider()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
            var random = new Random();

            var FakerCategory = new Faker<Category>()
                .RuleFor(c => c.Id, f =>1 + f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Random.Word())
                ;
            var FakerProduct = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Name, f => f.Random.Word())
                ;

            Categories.AddRange(FakerCategory.Generate(3));

            foreach (var category in Categories)
            {
                FakerProduct.RuleFor(p => p.CategoryId, f => category.Id).Generate();
                category.Products = FakerProduct.Generate(random.Next(1, 6));

                Products.AddRange(category.Products);
            }
        }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
