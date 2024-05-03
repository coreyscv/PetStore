using Microsoft.Extensions.DependencyInjection;
using PetStore.Logic;
using PetStore.Products;
using System.Text.Json;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();

            string userInput = RequestInput();

            while (userInput.ToLower() != "exit")
            {
                if (userInput == "1")
                {
                    Console.WriteLine("Please add a Dog Leash in JSON format");
                    var userInputAsJson = Console.ReadLine();
                    var dogLeash = JsonSerializer.Deserialize<DogLeash>(userInputAsJson);
                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Added a Dog Leash");
                }

                if (userInput == "2")
                {
                    Console.WriteLine("What is the name of the dog leash you would like to view?");
                    var dogLeashName = Console.ReadLine();
                    var dogLeash = productLogic.GetProductByName<DogLeash>(dogLeashName);

                    if (dogLeash == null)
                    {
                        Console.WriteLine("Product not found");
                    }
                    else
                    {
                        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                        Console.WriteLine();
                    }
                }

                if (userInput == "3") 
                {
                    Console.WriteLine("The following products are in stock: ");
                    var inStock = productLogic.GetOnlyInStockProducts();
                    foreach (var item in inStock)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }

                if (userInput == "4") 
                {
                    Console.WriteLine("The following products are out of stock: ");
                    var outOfStock = productLogic.GetOutOfStockProducts();
                    foreach (var item in outOfStock)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }

                if (userInput == "5") 
                {
                    Console.WriteLine("The following is a list of all products: ");
                    var allProducts = productLogic.GetAllProducts();
                    foreach (var item in allProducts)
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.WriteLine();
                }

                if (userInput == "6") 
                {
                    Console.WriteLine($"Current inventory value: ${productLogic.GetTotalPriceOfInventory()}");
                    Console.WriteLine();
                }

                userInput = RequestInput();

            }
        }


        static string RequestInput()
        {
            Console.WriteLine("Press 1 to add a Dog Leash Product");
            Console.WriteLine("Press 2 to view a Dog Leash Product");
            Console.WriteLine("Press 3 to view all in stock products");
            Console.WriteLine("Press 4 to view all out of stock products");
            Console.WriteLine("Press 5 to view all products");
            Console.WriteLine("Press 6 to view the total price of current inventory");
            Console.WriteLine("Type 'exit' to quit");

            return Console.ReadLine();
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }

    }
}