using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameCaseLib;
namespace Word_replacer;

public class Beneficiary
{
    public Beneficiary(int id, string nameEng, string nameUkr, string adressEng, string adressUkr, string signatoryEng, string signatoryUkr, string signatoryTitelEng, string signatoryTitelUkr)
    {
        Id = id;
        Name_Eng = nameEng;
        Name_Ukr = nameUkr ;
        Adress_Eng = adressEng;
        Adress_Ukr = adressUkr;
        Signatory_Eng = signatoryEng;
        Signatory_Ukr = signatoryUkr;
        SignatoryTitel_Eng = signatoryTitelEng ;
        SignatoryTitel_Ukr = signatoryTitelUkr ;
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
public class ItemInfo
{
    public ItemInfo(int id, string itemName,string unit, uint quantity, double price, bool vat)
    {
        Id = id;
        this.ItemName = itemName;
        this.Unit = unit;
        this.Quantity = quantity;
        this.Price = price;
        this.Vat = vat;
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
    public bool Vat { get; set; }
}