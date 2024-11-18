namespace CSR2026_Exploratory.Models.EntityModel
{
    public class Shop
    {
        public int ShopID { get; set; }

        public string? Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public byte StateID { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public string? Fax { get; set; } 

        public string? Address2 { get; set; }
    }
}
