using System.Text.Json;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productLogic = new ProductLogic();

            Console.WriteLine("Press 1 to add a Dog Leash Product");
            Console.WriteLine("Press 2 to view a Dog Leash Product");
            Console.WriteLine("Press 3 to view all in stock products");
            Console.WriteLine("Press 4 to view all out of stock products");
            Console.WriteLine("Press 5 to view all products");
            Console.WriteLine("Type 'exit' to quit");
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "exit") // changes input to lower case, if not equal to "exit" then enter if loop
            {
                if (userInput == "1")
                {
                    var dogLeash = new DogLeash();

                    Console.Write("Enter the name of the leash: ");
                    dogLeash.Name = Console.ReadLine();

                    Console.Write("Enter Quantity: ");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());

                    Console.Write("Enter a price for the product: ");
                    dogLeash.Price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Product Description: ");
                    dogLeash.Description = Console.ReadLine();

                    Console.Write("Confirm the length in inches: ");
                    dogLeash.LengthInches = int.Parse(Console.ReadLine());

                    Console.Write("What material is the leash made out of: ");
                    dogLeash.Material = Console.ReadLine();

                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Added a Dog Leash");
                }

                if (userInput == "2")
                {
                    Console.WriteLine("What is the name of the dog leash you would like to view?");
                    var dogLeashName = Console.ReadLine();
                    var dogLeash = productLogic.GetDogLeashByName(dogLeashName);

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

                Console.WriteLine("Press 1 to add a Dog Leash Product");
                Console.WriteLine("Press 2 to view a Dog Leash Product");
                Console.WriteLine("Press 3 to view all in stock products");
                Console.WriteLine("Press 4 to view all out of stock products");
                Console.WriteLine("Press 5 to view all products");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();
            }
        }
    }
}