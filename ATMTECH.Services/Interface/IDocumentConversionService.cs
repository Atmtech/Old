namespace ATMTECH.Services.Interface
{
    public interface IDocumentConversionService
    {
        void ConvertExcelToPdf(string excelSource, string pdfTarget);
    }
}
