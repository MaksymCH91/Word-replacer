namespace Word_replacer;

class Program
{

    static void Main(string[] args)
    {
        string inputFilePath = "input.docx";
        string outputFilePath = "output.docx";
        string jsonBeneficiary = "Beneficiary_data.json"; // path to jsong file
       

        List<ItemInfo> listOfItems = new List<ItemInfo>
        {
            new(1,
                "Dry air thermostat, thermostat temperature range +0.5…+70oC TC-80 MICROmed / Термостат сухоповітряний, інтервал температури термостату +0.5…+70oC TC-80 MICROmed",
                "Pcs / Шт", 1, 77074.62, false),
            new(2, "TOC-Analyzer multi N/C 3100 / TOC-аналізатор multi N/C 3100", "Pcs / Шт", 1, 1274893.04, false),
            new(3,
                "Spectrometer (320-1100 nm) Hach (LPV440.98.00001) / Спектрометр (320-1100 нм) Hach (LPV440.98.00001)",
                "Pcs / Шт", 2, 270762.73, false)

        };
       


        //WordsReplaser.Replace(inputFilePath, outputFilePath, jsonBeneficiary);
        //TableInserter.InsertRows(outputFilePath, listOfItems);



        Console.WriteLine("Replacement completed.");

        //var nameCase = new NameCase();
        //var name = "Иванов Иван Иванович";
        //var inflectedName = nameCase.InflectName(name, Case.Genitive);
        //Console.WriteLine(inflectedName); // Иванова Ивана Ивановича

        //Beneficiary beneficiary = new Beneficiary
        //(1,
        //    "Bila Tserkva City Counci",
        //    "Білоцерківська міська рада",
        //    "15, Yaroslav Mudryi St., Bila Tserkva, Kyiv oblast, 09100, Ukraine",
        //    "вул. Ярослава Мудрого 15, м. Біла Церква, Київська обл., 09100, Україна",
        //    "Hennadii DYKYI",
        //    "Геннадій ДИКИЙ",
        //    "City Head",
        //    "Міський голова"
        //);
        //JsonSerializer BeneficiarySerializern = new JsonSerializer(beneficiary);
        //BeneficiarySerializern.Save(jsonFilePath);
    }
}

  