﻿using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace PetStore
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

            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5});
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 20.99M, Quantity = 0});

        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
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

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<string> GetOnlyInStockProducts()
        {
            List<string> inStockProductNames = new List<string>();

            foreach (var prod in _products)
            {
                if(prod.Quantity > 0)
                {
                    inStockProductNames.Add(prod.Name);
                }
            }

            return inStockProductNames;
        }

        public List<string> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).Select(p => p.Name).ToList();
        }



    }
}