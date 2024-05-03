using PetStore.Products;

namespace PetStore.Logic
{
    internal interface IProductLogic
    {
        /// <summary>
        /// Add a new product to the store
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product);

        /// <summary>
        /// Returns all of the current products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Returns a dog leash object by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetProductByName<T>(string name) where T : Product;

        /// <summary>
        /// Returns only in stock products
        /// </summary>
        /// <returns></returns>
        public List<string> GetOnlyInStockProducts();

        /// <summary>
        /// Returns only out of stock products
        /// </summary>
        /// <returns></returns>
        public List<string> GetOutOfStockProducts();

        /// <summary>
        /// Returns the total price of in stock items
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPriceOfInventory();
    }
}
