namespace XmlTransformationDemo;

using System.Xml;
using System.Xml.Xsl;

internal class Program
{
    /// <summary>
    /// Transforms an XML file into an HTML file using an XSLT stylesheet.
    /// </summary>
    /// <remarks>This method demonstrates how to use the <see cref="System.Xml.Xsl.XslCompiledTransform"/>
    /// class  to apply an XSLT transformation to an XML file. The transformed output is written to an HTML
    /// file.</remarks>
    static void UsingXslCompiledTransform()
    {
        // Paths to the XML and XSLT files
        string xmlPath = "books.xml";
        string xsltPath = "transformation.xslt";
        string outputPath = "catalog.html";

        // Create the XslCompiledTransform and load the XSLT
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltPath);

        // Transform the XML and output to HTML file
        using (XmlWriter writer = XmlWriter.Create(outputPath, xslt.OutputSettings))
        {
            xslt.Transform(xmlPath, writer);
        }

        Console.WriteLine($"Transformation complete. Output written to {outputPath}");
    }

    static void Main()
    {
        try
        {
            UsingXslCompiledTransform();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
