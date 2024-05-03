using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using PetStore.Products;
using PetStore.Validators;
using PetStore.Logic;
using FluentValidation;

namespace PetStore.Logic
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>();
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();

            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 });
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 20.99M, Quantity = 0 });

        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                var validator = new DogLeashValidator();
                if (validator.Validate(product as DogLeash).IsValid)
                {
                    _dogLeash.Add(product.Name, product as DogLeash);
                }
                else
                {
                    throw new ValidationException("The dog leash product entered is not valid");
                }

            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public T GetProductByName<T>(string name) where T : Product
        {
            try
            {
                if (typeof(T) == typeof(DogLeash))
                {
                    return _dogLeash[name] as T;
                }
                else if (typeof(T) == typeof(CatFood))
                {
                    return _catFood[name] as T;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products.InStock().Select(x => x.Name).ToList();
        }

        public List<string> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).Select(p => p.Name).ToList();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(x => x.Price).Sum();
        }


    }
}