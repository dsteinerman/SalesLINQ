using System.Linq;
using System.Net;



    public class Sale
    {
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping
        {
            get; set;
        }
    }

class Program
{
    static void Main()
    {

        List<Sale> sales = new List<Sale>
        {
            new Sale{
            Item = "Apple",
            Customer = "Bob",
            PricePerItem = 11,
            Quantity = 5,
            Address = "709 Birch Hill Ave.\r\nFredericksburg, VA 22405",
            ExpeditedShipping = bool.Parse("true")
            },
             new Sale{
            Item = "ORANGE",
            Customer = "Steve",
            PricePerItem = 12,
            Quantity = 5,
            Address = "8357 Marvon Ave.\r\nOak Forest, IL 60452",
            ExpeditedShipping = bool.Parse("true")
            },

            new Sale{
            Item = "TEA",
            Customer = "Bob",
            PricePerItem = 7,
            Quantity = 1,
            Address = "168 Birchwood Street\r\nParkersburg, WV 26101",
            ExpeditedShipping = bool.Parse("true")
            },

            new Sale{
            Item = "Milk",
            Customer = "Joe",
            PricePerItem =5,
            Quantity = 1,
            Address = "9630 Bridge St.\r\nSoddy Daisy, TN 37379",
            ExpeditedShipping = bool.Parse("true")
            },

            new Sale{
            Item = "TEA",
            Customer = "Sam",
            PricePerItem = 8,
            Quantity = 1,
            Address = "74 Gulf Court\r\nCapitol Heights, MD 20743",
            ExpeditedShipping = bool.Parse("false")
            },

            new Sale{
            Item = "Pam",
            Customer = "Tommy LLC",
            PricePerItem = 110,
            Quantity = 116,
            Address = "17 East Acacia Drive\r\nNorth Wales, PA 19454",
            ExpeditedShipping = bool.Parse("true")
            },

            new Sale{
            Item = "Butter",
            Customer = "Tom LLC",
            PricePerItem = 10,
            Quantity = 16,
            Address = "40 Heritage Rd.\r\nKings Mountain, NC 28086",
            ExpeditedShipping = bool.Parse("true")
            }
        };




        IEnumerable<Sale> pricePerItem =
        from n in sales
        where n.PricePerItem > 10.0
        select n;

        foreach (Sale price in pricePerItem)
            Console.WriteLine(price.Customer + " " + price.Item + " $" + price.Quantity);

        IEnumerable<Sale> Quantity =
        from n in sales
        where n.Quantity == 1
        orderby n.PricePerItem descending
        select n;

        foreach (Sale price in Quantity)
            Console.WriteLine(price.Customer + " " + price.Item + " $" + price.Quantity);

        IEnumerable<Sale> NoShipTea =
        from n in sales
        where n.Item == "TEA"
        where n.ExpeditedShipping == false
        select n;

        foreach (Sale price in NoShipTea)
            Console.WriteLine(price.Customer + " " + price.Item + " $" + price.Quantity);

        IEnumerable<Sale> BigOrder =
        from n in sales
        where (n.PricePerItem * n.Quantity >100.0)
        select n;

        foreach (Sale price in BigOrder)
            Console.WriteLine(price.Address);

       IEnumerable<object> CommercialOrder =
       from n in sales
       where n.Customer.ToLower().Contains("llc")
       orderby (n.PricePerItem* n.Quantity) descending
       select new
       {
           Item = n.Item,
           TotalPrice = n.PricePerItem * n.Quantity,
           Shipping = n.ExpeditedShipping ? n.Address + " EXPEDITE " : n.Address
       };
        

        foreach (Object price in CommercialOrder)
            Console.WriteLine(price.ToString());



    }
}
