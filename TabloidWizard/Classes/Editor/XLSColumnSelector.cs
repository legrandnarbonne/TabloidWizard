using MetroFramework.Forms;
using System.Windows.Forms;
using ExcelDataReader;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace TabloidWizard.Classes.Editor
{
    public partial class XLSColumnSelector : MetroForm
    {
        public XLSStructure CurrentXLSStructure { get; set; }

        public enum BehaviourTypes { ColumnSelect, SheetSelect };

        BehaviourTypes _behaviour;

        bool initialize;

        public XLSColumnSelector(XLSStructure currentXLSStructure, BehaviourTypes behaviour)
        {
            initialize = true;

            CurrentXLSStructure = currentXLSStructure;
            _behaviour = behaviour;

            InitializeComponent();

            var tmp = CurrentXLSStructure.CurrentWorkBookNum;

            cmbSheet.DataSource = CurrentXLSStructure.WorkBooks;

            CurrentXLSStructure.CurrentWorkBookNum = tmp;

            if (CurrentXLSStructure.CurrentWorkBookNum != 0) cmbSheet.SelectedIndex = CurrentXLSStructure.CurrentWorkBookNum;

            lblPath.Text = CurrentXLSStructure.FileName;

            cmbField.Visible = label1.Visible = _behaviour == BehaviourTypes.ColumnSelect;
            txtIgnore.Text = CurrentXLSStructure.IgnoreLine.ToString();

            initialize = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "fichier xlsx (*.xlsx)|*.xlsx|fichier xls (*.xls)|*.xls|fichier texte (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    CurrentXLSStructure = new XLSStructure();
                    CurrentXLSStructure.FileName = lblPath.Text = openFileDialog.FileName;

                    ReadXLS();

                }
            }
        }

        private void ReadXLS()
        {
            if (CurrentXLSStructure == null||string.IsNullOrEmpty(CurrentXLSStructure.FileName)) return;

            var waitingForm = new WaitingForm(ReadXLS)
            {
                Text = Properties.Resources.FileAnalysis,
                progressBar = { Style = ProgressBarStyle.Marquee }
            };

            waitingForm.Wr.RunWorkerAsync(new object[] { });

            waitingForm.ShowDialog();

            cmbField.Enabled = cmbSheet.Enabled = true;
            cmbSheet.DataSource = CurrentXLSStructure.WorkBooks;
        }


        private void ReadXLS(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var worker = (BackgroundWorker)sender;

            //Read the contents of the file
            using (Stream stream = File.Open(CurrentXLSStructure.FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader =Path.GetExtension(CurrentXLSStructure.FileName).ToLower()==".csv"?
                    ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration() { AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' } }) :
                    ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());


                    var dt = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {

                        // Gets or sets a value indicating whether to set the DataColumn.DataType 
                        // property in a second pass.
                        UseColumnDataType = true,

                        // Gets or sets a callback to obtain configuration options for a DataTable. 
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                            //FilterRow = rowReader => rowReader.Depth > CurrentXLSStructure.IgnoreLine
                            ReadHeaderRow = rowReader =>
                            {
                                for(int i=0;i< CurrentXLSStructure.IgnoreLine;i++)
                                rowReader.Read();
                            }
                        }
                    });

                    CurrentXLSStructure.WorkBooks = new List<XLSStructure.WorkBook>();

                    foreach (DataTable sh in dt.Tables)
                    {
                        var wb = new XLSStructure.WorkBook();

                        wb.Name = sh.ToString();
                        wb.Columns = new List<string>();

                        foreach (var c in sh.Columns)
                        {
                            wb.Columns.Add(c.ToString());
                        }

                        CurrentXLSStructure.WorkBooks.Add(wb);
                    }


                }
            }

        }

        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentXLSStructure.CurrentWorkBookNum = cmbSheet.SelectedIndex;
            cmbField.DataSource = ((XLSStructure.WorkBook)cmbSheet.SelectedItem).Columns.OrderBy(o => o.ToString()).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (initialize) return;
            int line;
            if (int.TryParse(txtIgnore.Text, out line))
            {
                CurrentXLSStructure.IgnoreLine = line;
                ReadXLS();
            }
        }
    }

}
