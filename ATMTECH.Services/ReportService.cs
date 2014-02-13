using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ATMTECH.Common.Context;
using ATMTECH.Services.Interface;
using ATMTECH.Utils.Web;
using Microsoft.Reporting.WebForms;
using System.Linq;

namespace ATMTECH.Services
{
    public class ReportService : IReportService
    {
        public byte[] GetReport(ReportParameter reportParameter)
        {
            byte[] retour;

            ReportViewer rvDocument = new ReportViewer();
            try
            {
                rvDocument.ProcessingMode = ProcessingMode.Local;
                LocalReport report = rvDocument.LocalReport;

                Assembly presenterAssembly = Assembly.Load(reportParameter.Assembly);
                Stream rdlcStream =
                    presenterAssembly.GetManifestResourceStream(reportParameter.PathToReportAssembly);
                rvDocument.LocalReport.LoadReportDefinition(rdlcStream);

                IList<Microsoft.Reporting.WebForms.ReportParameter> parametresRapport =
                    new List<Microsoft.Reporting.WebForms.ReportParameter>();
                if (reportParameter.Parameters != null)
                {
                    foreach (KeyValuePair<string, string> pair in reportParameter.Parameters)
                    {
                        Microsoft.Reporting.WebForms.ReportParameter parametreRapport =
                            new Microsoft.Reporting.WebForms.ReportParameter {Name = pair.Key};
                        parametreRapport.Values.Add(pair.Value);
                        parametresRapport.Add(parametreRapport);
                    }
                    report.SetParameters(parametresRapport);
                }

                IList<ReportDataSource> listeSourceDonneesRapport = new List<ReportDataSource>();
                foreach (ReportInnerDataSource sourceDonnees in reportParameter.DataSources)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = sourceDonnees.Nom;
                    rds.Value = sourceDonnees.Valeurs;
                    listeSourceDonneesRapport.Add(rds);
                }

                foreach (ReportDataSource sourceDonneesRapport in listeSourceDonneesRapport)
                    report.DataSources.Add(sourceDonneesRapport);

                rvDocument.LocalReport.Refresh();

                retour = rvDocument.LocalReport.Render("PDF");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            return retour;
        }

        public Stream SaveReportToStream(string reportName, byte[] file)
        {
            return new MemoryStream(file);
        }


        public void SaveReport(string reportName, byte[] file)
        {
            ContextSessionManager.Context.Response.BinaryWrite(file);
            ContextSessionManager.Context.Response.ContentType = Mimes.GetMime(".pdf");
            ContextSessionManager.Context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0};", reportName));
            ContextSessionManager.Context.ApplicationInstance.CompleteRequest();
        }
    }

    public class ReportParameter
    {
        public string Assembly { get; set; }
        public IList<ReportInnerDataSource> DataSources { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string PathToReportAssembly { get; set; }

        public ReportFormat ReportFormat { get; set; }

        public void AddDatasource(string nom, IEnumerable valeur)
        {
            int i = 0;
            foreach (var t in valeur)
            {
                i += 1;
            }
            if (i == 0)
            {
                throw new Exception("Aucune donnée pour les critères demandés.");
            }
            
            ReportInnerDataSource sourcesDonnees = new ReportInnerDataSource {Nom = nom, Valeurs = valeur};
            if (this.DataSources == null)
                this.DataSources = new List<ReportInnerDataSource>();
            this.DataSources.Add(sourcesDonnees);
        }
    }

    public class ReportInnerDataSource
    {
        public string Nom { get; set; }
        public IEnumerable Valeurs { get; set; }
    }

    public enum ReportFormat
    {
        PDF,
        Excel,
        Image,
        CSV,
        XML,
        Natif
    }

}
