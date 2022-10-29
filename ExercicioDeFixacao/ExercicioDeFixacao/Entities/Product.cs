namespace ExercicioDeFixacao.Entities
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public Product()
        {
        }
        public Product(string name, double price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public double Total()
        {
            return Price * Amount;
        }
    }
}
