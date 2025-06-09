namespace XmlTransformationDemo;

using System;
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
        String xmlPath = "books.xml";
        String xsltPath = "transformation.xslt";
        String outputPath = "catalog.html";

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

    /// <summary>
    /// Transforms an XML file into an HTML file using the legacy XslTransform class.
    /// </summary>
    /// <remarks>
    /// XslTransform is obsolete and only available in .NET Framework, not .NET Core or .NET 5+.
    /// This sample is for legacy reference only.
    /// </remarks>
    static void UsingXslTransform()
    {
#pragma warning disable SYSLIB0016 // Type or member is obsolete
        string xmlPath = "books.xml";
        string xsltPath = "transformation.xslt";
        string outputPath = "catalog_xsltransform.html";

        XslTransform xslt = new XslTransform();
        xslt.Load(xsltPath);

        using (XmlReader reader = XmlReader.Create(xmlPath))
        using (XmlWriter writer = XmlWriter.Create(outputPath))
        {
#if !DEBUG
            xslt.Transform(reader, null, writer);
#endif
        }

        Console.WriteLine($"Transformation complete. Output written to {outputPath}");
#pragma warning restore SYSLIB0016
    }

    static void Main()
    {
        try
        {
            UsingXslCompiledTransform();
            UsingXslTransform();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
