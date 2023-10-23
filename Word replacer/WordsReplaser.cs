using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NameCaseLib;
namespace Word_replacer;

internal class WordsReplaser
{

    public static void Replace(string inputFilePath, string outputFilePath,string jsonFilePath)

    {
        
    
        // Initialize with a Beneficiary object
        JsonSerializer BeneficiarySerializern = new JsonSerializer(Beneficiary);
        // Load Beneficiary data from JSON
        Beneficiary beneficiary=BeneficiarySerializern.Load(jsonFilePath);

        Dictionary<string, string> ReplaceDictionary = new Dictionary<string, string>()
        {
            {"Name_Eng", beneficiary.Name_Eng},
            {"Name_Ukr", beneficiary.Name_Ukr},
            {"Address_Eng", beneficiary.Adress_Eng},
            {"Address_Ukr", beneficiary.Adress_Ukr},
            {"Signatory_Eng", beneficiary.Signatory_Eng},
            {"Signatory_Ukr", beneficiary.Signatory_Ukr},
            {"SignatoryTitle_Eng", beneficiary.SignatoryTitel_Eng},
            {"SignatoryTitle_Ukr", beneficiary.SignatoryTitel_Ukr}
        };

        File.Copy(inputFilePath, outputFilePath, true);

        using (WordprocessingDocument doc = WordprocessingDocument.Open(outputFilePath, true))
        {
            var body = doc.MainDocumentPart.Document.Body;

            // Iterate through all text elements in the document.
            foreach (var textElement in body.Descendants<Text>())
            {
                string text = textElement.Text;

                // Check if the text contains any of the dictionary keys.
                foreach (var key in ReplaceDictionary.Keys)
                {
                    if (text.Contains(key))
                    {
                        // Replace the key with the corresponding value from the dictionary.
                        text = text.Replace(key, ReplaceDictionary[key]);
                        textElement.Text = text;
                    }
                }

            }
        }
    }

    public static Beneficiary Beneficiary { get; set; }
}