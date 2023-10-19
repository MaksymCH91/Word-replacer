using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameCaseLib;
namespace Word_replacer
{
    public class Beneficiary
    {
        public Beneficiary(int id, string name_Eng, string name_Ukr, string adress_Eng, string adress_Ukr, string signatory_Eng, string signatory_Ukr, string signatoryTitel_Eng, string signatoryTitel_Ukr)
        {
            Id = id;
            Name_Eng = name_Eng ?? throw new ArgumentNullException(nameof(name_Eng));
            Name_Ukr = name_Ukr ?? throw new ArgumentNullException(nameof(name_Ukr));
            Adress_Eng = adress_Eng ?? throw new ArgumentNullException(nameof(adress_Eng));
            Adress_Ukr = adress_Ukr ?? throw new ArgumentNullException(nameof(adress_Ukr));
            Signatory_Eng = signatory_Eng ?? throw new ArgumentNullException(nameof(signatory_Eng));
            Signatory_Ukr = signatory_Ukr ?? throw new ArgumentNullException(nameof(signatory_Ukr));
            SignatoryTitel_Eng = signatoryTitel_Eng ?? throw new ArgumentNullException(nameof(signatoryTitel_Eng));
            SignatoryTitel_Ukr = signatoryTitel_Ukr ?? throw new ArgumentNullException(nameof(signatoryTitel_Ukr));
        }

        public int Id { get; }
        public string Name_Eng { get; set; }
        public string Name_Ukr { get; set; }
        public string Adress_Eng { get; set; }
        public string Adress_Ukr { get; set; }
        public string Signatory_Eng { get; set; }
        public string Signatory_Ukr { get; set; }
        public string SignatoryTitel_Eng { get; set; }
        public string SignatoryTitel_Ukr { get; set; }

    }
    public class Item
    {
        public Item(int id, string itemName,string unit, uint quantity, double price, bool vat)
        {
            Id = id;
            this.ItemName = itemName;
            this.Unit = unit;
            this.Quantity = quantity;
            this.Price = price;
            this.VAT = vat;
            if (vat == true)
            {
                TotalCost = price * quantity*1.2;
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



