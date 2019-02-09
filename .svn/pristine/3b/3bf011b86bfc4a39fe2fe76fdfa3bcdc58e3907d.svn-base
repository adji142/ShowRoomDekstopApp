using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace ISA.Showroom
{
    public partial class frmReportViewer : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        
        bool _Print = false;

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param)
        {
            InitializeComponent();
            this.rptViewer.LocalReport.EnableExternalImages = true;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "ISA.Showroom." + reportPath;
            this.rptViewer.LocalReport.SetParameters(param);
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param, DataTable data, string datasetName)
        {
            InitializeComponent();
            this.rptViewer.LocalReport.EnableExternalImages = true;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "ISA.Showroom." + reportPath;
            this.rptViewer.LocalReport.SetParameters(param);
            this.rptViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetName, data.DefaultView));
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param, List<DataTable> data, List<string> datasetName)
        {
            InitializeComponent();
            this.rptViewer.LocalReport.EnableExternalImages = true;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "ISA.Showroom." + reportPath;
            this.rptViewer.LocalReport.SetParameters(param);
            for (int i = 0; i < data.Count; i++)
            {
                this.rptViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetName[i], data[i].DefaultView));
            }
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param, DataTable data, string datasetName, bool readOnly)
        {
            InitializeComponent();
            this.rptViewer.LocalReport.EnableExternalImages = true;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "ISA.Showroom." + reportPath;
            this.rptViewer.LocalReport.SetParameters(param);
            this.rptViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetName, data.DefaultView));
            if (readOnly)
            {
                rptViewer.ShowExportButton = false;
                rptViewer.ShowPrintButton = false;
            }
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }

        public void Print()
        {
            this.rptViewer.RefreshReport();
            _Print = true;
        }

        private void rptViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (_Print)
            {
                //this.rptViewer.PrintDialog();
                Export(this.rptViewer.LocalReport);
                m_currentPageIndex = 0;
                PrintDirectly();
            }
        }

        private void Export(LocalReport report)
        {
            Random rnd = new Random();
            report.DisplayName = report.DisplayName + rnd.Next(0, 100).ToString();

            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.0000001in</MarginTop>" +
              "  <MarginLeft>0.0000001in</MarginLeft>" +
              "  <MarginRight>0.0000001in</MarginRight>" +
              "  <MarginBottom>0.0000001in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            this.DeleteStream(name, fileNameExtension);
            Random rnd = new Random();
            Stream stream = new FileStream(@"c:\Temp\" + name +
               "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void DeleteStream(string name, string fileNameExtension)
        {
            Object fileName = @"c:\Temp\" + name + "." + fileNameExtension;
            if (File.Exists((string) fileName)) File.Delete((string) fileName);
        }

        public void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void PrintDirectly()
        {
            const string printerName = "Microsoft Office Document Image Writer";
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = GetPrinterName();
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                   "Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg, "Print Error");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();

            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)                    
                    stream.Close();
                m_streams = null;

            }
        }

        public string GetPrinterName()
        {
            PrintDocument doc = new PrintDocument();

            return doc.PrinterSettings.PrinterName;
        }
    }
}
