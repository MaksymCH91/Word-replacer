using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Word_replacer;

class TableInserter
{
    public static void InsertRows(string outputFilePath, List<ItemInfo> ListOfItems)
    {
        using var doc = WordprocessingDocument.Open(outputFilePath, true);
        // Search for the specific table with "№" in the first cell
        Table targetTable = null;
        foreach (var table in doc.MainDocumentPart.Document.Body.Descendants<Table>())
        {
            // Check if the first cell in the table contains "№"
            var firstCell = table.Elements<TableRow>().FirstOrDefault()?.Elements<TableCell>().FirstOrDefault();
            if (firstCell != null && firstCell.Descendants<Text>().Any(text => text.Text == "№"))
            {
                targetTable = table;
                break; // Found the target table, exit the loop
            }
        }
        double Total_UA = 0;
        if (targetTable != null)
        {
            var headerRow = targetTable.Elements<TableRow>().First();

            // Reverse the order of ListOfItems
            ListOfItems.Reverse();

            foreach (var item in ListOfItems)
            {
                Total_UA += item.TotalCost;
                var newRow = new TableRow();
                // There are 6 columns

                for (var i = 0; i < 6; i++)
                {
                    // Create and format a new cell
                    var newCell = new TableCell();

                    // Set cell properties and formatting as needed
                    var cellProperties = new TableCellProperties();
                    var cellWidth = new TableCellWidth();

                    var paragraph = new Paragraph();

                    // Set the paragraph properties for justification
                    var paragraphProperties = new ParagraphProperties();
                    if (i == 1)
                    {
                        paragraphProperties.Append(new Justification() { Val = JustificationValues.Both });
                    }
                    else
                    {
                        paragraphProperties.Append(new Justification() { Val = JustificationValues.Center });
                    }

                    paragraph.Append(paragraphProperties);

                    var run = new Run();
                    Text text;
                    var customCulture = new CultureInfo("en-US");
                    if (i == 0) // Column 1
                        text = new Text(item.Id.ToString());
                    else if (i == 1) // Column 2
                        text = new Text(item.ItemName);
                    else if (i == 2) // Column 3
                        text = new Text(item.Unit);
                    else if (i == 3) // Column 4
                        text = new Text(item.Quantity.ToString());
                    else if (i == 4) // Column 5
                        text = new Text(item.Price.ToString("#,0.00", CultureInfo.InvariantCulture));
                    else // Column 6
                        text = new Text(item.TotalCost.ToString("#,0.00", CultureInfo.InvariantCulture));

                    // Set font and font size
                    var runProperties = new RunProperties();
                    var runFonts = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", ComplexScript = "Calibri" };
                    var fontSize = new FontSize() { Val = "20" };

                    runProperties.Append(runFonts);
                    runProperties.Append(fontSize);

                    run.Append(runProperties);
                    run.Append(text);
                    paragraph.Append(run);
                    newCell.Append(paragraph);

                    // Set vertical centering for columns 1, 3, 4, 5, and 6
                    if (i != 1)
                    {
                        cellProperties.Append(new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center });
                    }

                    newCell.Append(cellProperties);

                    // Append the cell to the new row
                    newRow.Append(newCell);
                }

                // Insert the new row after the header row in the target table
                headerRow.InsertAfterSelf(newRow);
            }
            // Find and replace "Total_UA" in the document with the calculated value
            foreach (var textElement in doc.MainDocumentPart.Document.Body.Descendants<Text>())
            {
                if (textElement.Text == "Total_UA")
                {
                    // Assuming you only want to replace the first occurrence
                    textElement.Text = Total_UA.ToString("#,0.00", CultureInfo.InvariantCulture);
                    break;
                }
            }
            doc.MainDocumentPart.Document.Save();
        }
    }
}