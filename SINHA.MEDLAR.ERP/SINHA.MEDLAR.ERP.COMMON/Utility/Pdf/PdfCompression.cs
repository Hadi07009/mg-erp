using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.COMMON.Utility.Pdf
{
    public class PdfCompression
    {
        public static byte[] Compress(byte[] inputFile)
        {
            //byte[] inputFile = File.ReadAllBytes("File");

            //Load a existing PDF document
            PdfLoadedDocument ldoc = new PdfLoadedDocument(inputFile);

            //Create a new PDF compression options
            PdfCompressionOptions options = new PdfCompressionOptions();

            //Compress image.
            options.CompressImages = true;
            options.ImageQuality = 10;

            //Compress the font data
            options.OptimizeFont = true;

            //Compress the page contents
            options.OptimizePageContents = true;

            //Remove the metadata information.
            options.RemoveMetadata = true;

            //Set the options to loaded PDF document
            ldoc.CompressionOptions = options;

            //Restructure the document
            ldoc.FileStructure.IncrementalUpdate = false;

            //Remove form fields and its data.
            ldoc = RemoveFormFields(ldoc, false);
            //Remove annotation and its data.
            ldoc = RemoveAnnotations(ldoc, false);

            //Save the document 
            MemoryStream ms = new MemoryStream();
            ldoc.Save(ms);


            
            byte[] bytes = ms.ToArray();
                        
            //byte[] newBytes = Convert.FromBase64String(s);
            return bytes;
        }

        public static string Compress(string pdfData)
        {
            //byte[] inputFile = File.ReadAllBytes("File");

            byte[] newBytes = Convert.FromBase64String(pdfData);

            //Load a existing PDF document
            PdfLoadedDocument ldoc = new PdfLoadedDocument(newBytes);

            //Create a new PDF compression options
            PdfCompressionOptions options = new PdfCompressionOptions();

            //Compress image.
            options.CompressImages = true;
            options.ImageQuality = 10;

            //Compress the font data
            options.OptimizeFont = true;

            //Compress the page contents
            options.OptimizePageContents = true;

            //Remove the metadata information.
            options.RemoveMetadata = true;

            //Set the options to loaded PDF document
            ldoc.CompressionOptions = options;

            //Restructure the document
            ldoc.FileStructure.IncrementalUpdate = false;

            //Remove form fields and its data.
            ldoc = RemoveFormFields(ldoc, false);
            //Remove annotation and its data.
            ldoc = RemoveAnnotations(ldoc, false);

            //Save the document 
            MemoryStream ms = new MemoryStream();
            ldoc.Save(ms);

            byte[] result;
            using (var streamReader = new MemoryStream())
            {
                ms.CopyTo(streamReader);
                result = streamReader.ToArray();
            }
            
            string data = Convert.ToBase64String(result);
            return data;
        }

        #region Helper methods      
        public static PdfLoadedDocument RemoveFormFields(PdfLoadedDocument ldoc, bool flatten)
        {
            if (ldoc.Form != null)
            {
                if (flatten)
                {
                    ldoc.Form.Flatten = true;
                }
                else
                {
                    int count = ldoc.Form.Fields.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        ldoc.Form.Fields.RemoveAt(i);
                    }
                }
            }
            return ldoc;
        }
        public static PdfLoadedDocument RemoveAnnotations(PdfLoadedDocument ldoc, bool flatten)
        {
            foreach (PdfPageBase page in ldoc.Pages)
            {
                if (flatten)
                {
                    int count = page.Annotations.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        page.Annotations[i].Flatten = true;
                    }
                }
                else
                {
                    int count = page.Annotations.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        page.Annotations.RemoveAt(i);
                    }
                }
            }
            return ldoc;
        }
        #endregion
    }
}
