Imports DevExpress.Pdf

Namespace AddFormFieldsToExistingDocument
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            Using processor As New PdfDocumentProcessor()

                ' Load a document.
                processor.LoadDocument("..\..\Document.pdf")

                ' Create a text box field specifying the field name, page number, and field location on the page.
                Dim textBox As New PdfAcroFormTextBoxField("text box", 1, New PdfRectangle(230, 690, 280, 710))

                ' Specify text box text, and appearance.
                textBox.Text = "Text Box"
                textBox.Appearance.BackgroundColor = New PdfRGBColor(0.8, 0.5, 0.3)
                textBox.Appearance.FontSize = 12

                ' Create a radio group field specifying its name and the page number.
                Dim radioGroup As New PdfAcroFormRadioGroupField("Gender Group", 1)

                ' Add the first radio button to the group and specify its location using a PdfRectangle object.
                radioGroup.AddButton("button1", New PdfRectangle(230, 635, 250, 655))

                ' Add the second radio button to the group.
                radioGroup.AddButton("button2", New PdfRectangle(310, 635, 330, 655))

                ' Specify radio group selected index, and appearance. 
                radioGroup.SelectedIndex = 0
                radioGroup.Appearance.BorderAppearance = New PdfAcroFormBorderAppearance() With {.Color = New PdfRGBColor(0.8, 0.5, 0.3), .Width = 3}

                ' Add form fields to the page.
                processor.AddFormFields(textBox, radioGroup)

                ' Save the result document.
                processor.SaveDocument("..\..\Result.pdf")
            End Using
        End Sub
    End Class
End Namespace
