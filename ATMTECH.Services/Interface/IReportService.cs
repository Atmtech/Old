using System.Collections.Generic;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace ATMTECH.Services.Interface
{
    public interface IReportService
    {
        byte[] GetReport(ReportParameter reportParameter);
        Stream SaveReportToStream(string reportName, byte[] file);
        void SaveReport(string reportName, byte[] file);
    }
}
