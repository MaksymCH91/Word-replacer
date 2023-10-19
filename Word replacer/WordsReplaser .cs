using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NameCaseLib;
namespace Word_replacer
{
    class WordsReplaser
    {
        public static void Replace(string inputFilePath, string outputFilePath, Beneficiary beneficiaryInput) //string replacement string placeholder, string replacement

        {
            Dictionary<string, string> ReplaceDictionary = new Dictionary<string, string>()
            {
                {"Name_Eng", beneficiaryInput.Name_Eng},
                {"Name_Ukr", beneficiaryInput.Name_Ukr},
                {"Adress_Eng", beneficiaryInput.Adress_Eng},
                {"Adress_Ukr", beneficiaryInput.Adress_Ukr},
                {"Signatory_Eng", beneficiaryInput.Signatory_Eng},
                {"Signatory_Ukr", beneficiaryInput.Signatory_Ukr},
                {"SignatoryTitel_Eng", beneficiaryInput.SignatoryTitel_Eng},
                {"SignatoryTitel_Ukr", beneficiaryInput.SignatoryTitel_Ukr}
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
    }
}
