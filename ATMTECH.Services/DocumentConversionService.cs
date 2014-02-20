//using ATMTECH.Services.Interface;
//using uno.util;
//using unoidl.com.sun.star.lang;
//using unoidl.com.sun.star.uno;
//using unoidl.com.sun.star.frame;
//using unoidl.com.sun.star.beans;
//using unoidl.com.sun.star.util;

//namespace ATMTECH.Services
//{
//    public class DocumentConversionService : IDocumentConversionService

//    {
//        public void ConvertExcelToPdf(string excelSource, string pdfTarget)
//        {
//            string excelFile = excelSource;
//            string pdfFile = pdfTarget;

//            // Start OpenOffce or get a reference to an existing session
//            XComponentContext localContext = Bootstrap.bootstrap();
//            XMultiServiceFactory multiServiceFactory = (XMultiServiceFactory)localContext.getServiceManager();
//            XComponentLoader componentLoader = (XComponentLoader)multiServiceFactory.createInstance("com.sun.star.frame.Desktop");

//            // Open file hidden in read-only mode
//            PropertyValue[] loadProps = new PropertyValue[2];
//            loadProps[0] = new PropertyValue();
//            loadProps[0].Name = "ReadOnly";
//            loadProps[0].Value = new uno.Any(true);
//            loadProps[1] = new PropertyValue();
//            loadProps[1].Name = "Hidden";
//            loadProps[1].Value = new uno.Any(true);

//            // Open the file
//            XComponent sourceDoc = componentLoader.loadComponentFromURL(excelFile, "_blank", 0, loadProps);

//            // Conversion parameters - overwrite existing file, use PDF exporter
//            PropertyValue[] conversionProperties = new PropertyValue[3];
//            conversionProperties[0] = new PropertyValue();
//            conversionProperties[0].Name = "Overwrite";
//            conversionProperties[0].Value = new uno.Any(true);
//            conversionProperties[1] = new PropertyValue();
//            conversionProperties[1].Name = "FilterName";
//            conversionProperties[1].Value = new uno.Any("calc_pdf_Export");

//            // Set PDF export parameters
//            PropertyValue[] filterData = new PropertyValue[3];

//            // JPEG compression quality 70
//            filterData[0] = new PropertyValue();
//            filterData[0].Name = "Quality";
//            filterData[0].Value = new uno.Any(70);
//            filterData[0].State = PropertyState.DIRECT_VALUE;

//            // Max image resolution 300dpi
//            filterData[1] = new PropertyValue();
//            filterData[1].Name = "ReduceImageResolution";
//            filterData[1].Value = new uno.Any(true);
//            filterData[1].State = PropertyState.DIRECT_VALUE;
//            filterData[2] = new PropertyValue();
//            filterData[2].Name = "MaxImageResolution";
//            filterData[2].Value = new uno.Any(300);
//            filterData[2].State = PropertyState.DIRECT_VALUE;

//            conversionProperties[2] = new PropertyValue();
//            conversionProperties[2].Name = "FilterData";
//            conversionProperties[2].Value = new uno.Any(filterData.GetType(), filterData);

//            // Save as PDF
//            XStorable xstorable = (XStorable)sourceDoc;
//            xstorable.storeToURL(pdfFile, conversionProperties);

//            // Close document
//            ((XCloseable)sourceDoc).close(false);
//            ((XCloseable)xstorable).close(false);
//        }
//    }
//}
