namespace Blazor_WEB_UI.Data.TypeOfData
{
    public class Item
    {
        public Item(int id, string itemName, string unit, uint quantity, double price, bool vat)
        {
            Id = id;
            this.ItemName = itemName;
            this.Unit = unit;
            this.Quantity = quantity;
            this.Price = price;
            this.VAT = vat;
            if (vat == true)
            {
                TotalCost = price * quantity * 1.2;
            }
            else
            {
                TotalCost = price * quantity;
            }
        }

        public int Id { get; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public bool VAT { get; set; }
    }
}
