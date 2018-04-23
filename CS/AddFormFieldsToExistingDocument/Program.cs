using DevExpress.Pdf;

namespace AddFormFieldsToExistingDocument {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Load a document.
                processor.LoadDocument("..\\..\\Document.pdf");

                // Create a text box field specifying the field name, page number, and field location on the page.
                PdfAcroFormTextBoxField textBox = new PdfAcroFormTextBoxField("text box", 1, new PdfRectangle(230, 690, 280, 710));

                // Specify text box text, and appearance.
                textBox.Text = "Text Box";
                textBox.Appearance.BackgroundColor = new PdfRGBColor(0.8, 0.5, 0.3);
                textBox.Appearance.FontSize = 12;

                // Create a radio group field specifying its name and the page number.
                PdfAcroFormRadioGroupField radioGroup = new PdfAcroFormRadioGroupField("Gender Group", 1);

                // Add the first radio button to the group and specify its location using a PdfRectangle object.
                radioGroup.AddButton("button1", new PdfRectangle(230, 635, 250, 655));

                // Add the second radio button to the group.
                radioGroup.AddButton("button2", new PdfRectangle(310, 635, 330, 655));

                // Specify radio group selected index, and appearance. 
                radioGroup.SelectedIndex = 0;               
                radioGroup.Appearance.BorderAppearance = new PdfAcroFormBorderAppearance() { Color = new PdfRGBColor(0.8, 0.5, 0.3), Width = 3 };

                // Add form fields to the page.
                processor.AddFormFields(textBox, radioGroup);

                // Save the result document.
                processor.SaveDocument("..\\..\\Result.pdf");
            }
        }
    }
}
