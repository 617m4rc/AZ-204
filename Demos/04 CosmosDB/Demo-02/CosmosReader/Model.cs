namespace CosmosReader
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
    }
}