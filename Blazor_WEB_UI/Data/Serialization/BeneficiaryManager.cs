namespace Blazor_WEB_UI.Data
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BeneficiaryManager
    {
        private List<Beneficiary> Beneficiaries; // Declare the list here

        private string fileName;

        public BeneficiaryManager(string fileName)
        {
            this.fileName = fileName;
            Beneficiaries = new List<Beneficiary>(); // Initialize the list in the constructor
        }

        public void AddBeneficiary(Beneficiary beneficiary)
        {
            Beneficiaries.Add(beneficiary);
        }

        public void RemoveBeneficiary(int beneficiaryId)
        {
            Beneficiary beneficiaryToRemove = Beneficiaries.Find(b => b.Id == beneficiaryId);
            if (beneficiaryToRemove != null)
            {
                Beneficiaries.Remove(beneficiaryToRemove);
            }
        }

        public Beneficiary GetBeneficiary(int beneficiaryId)
        {
            return Beneficiaries.Find(b => b.Id == beneficiaryId);
        }

        public List<Beneficiary> GetAllBeneficiaries()
        {
            return Beneficiaries;
        }

        public void SaveBeneficiariesToFile()
        {
            string json = JsonConvert.SerializeObject(Beneficiaries, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void LoadBeneficiariesFromFile()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                Beneficiaries = JsonConvert.DeserializeObject<List<Beneficiary>>(json);
            }
        }
    }
}
