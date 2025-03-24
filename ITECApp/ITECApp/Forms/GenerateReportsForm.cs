using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

namespace ITECApp.Forms
{
    public partial class GenerateReportsForm : Form
    {
        private ComboBox cmbReportType;
        private DataGridView dgvReport;

        public GenerateReportsForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            cmbReportType = new ComboBox();
            dgvReport = new DataGridView();
            // Add cmbReportType and dgvReport to the form's controls
            this.Controls.Add(cmbReportType);
            this.Controls.Add(dgvReport);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate report based on selected criteria
            var reportData = new ReportDAL().GenerateReport(cmbReportType.SelectedItem?.ToString() ?? string.Empty);
            dgvReport.DataSource = reportData;
            GeneratePDFReport(reportData);
        }

        private void GeneratePDFReport(DataTable reportData)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Report as PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        PdfPTable pdfTable = new PdfPTable(reportData.Columns.Count);
                        foreach (DataColumn column in reportData.Columns)
                        {
                            pdfTable.AddCell(new Phrase(column.ColumnName));
                        }

                        foreach (DataRow row in reportData.Rows)
                        {
                            foreach (var cell in row.ItemArray)
                            {
                                pdfTable.AddCell(new Phrase(cell?.ToString() ?? string.Empty));
                            }
                        }

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
            }
        }
    }
}
