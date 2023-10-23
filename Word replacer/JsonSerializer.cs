using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Word_replacer;

public class JsonSerializer
{
    // Change the type to Beneficiary
    private Beneficiary beneficiary;
  

    // Modify the constructor parameter
    public JsonSerializer(Beneficiary beneficiary)
    {
        this.beneficiary = beneficiary;
    }

    

    public void Save(string filePath)
    {
        string jsonData = JsonConvert.SerializeObject(beneficiary);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine("Data saved in JSON format.");
       
    }

    public Beneficiary Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                var loadedData = JsonConvert.DeserializeObject<Beneficiary>(jsonData);
                Beneficiary beneficiary = new Beneficiary(
                    loadedData.Id,
                    loadedData.Name_Eng,
                    loadedData.Name_Ukr,
                    loadedData.Adress_Eng,
                    loadedData.Adress_Ukr,
                    loadedData.Signatory_Eng,
                    loadedData.Signatory_Ukr,
                    loadedData.SignatoryTitel_Eng,
                    loadedData.SignatoryTitel_Ukr
                );
                return beneficiary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading JSON data: " + ex.Message);
                return null;
            }
        }
        else
        {
            Console.WriteLine("JSON file not found.");
            return null;
        }
    }



}