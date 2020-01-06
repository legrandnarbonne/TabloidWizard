using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class QGen : Form
    {
        DataTable _tbContainer = new DataTable();


        public QGen()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory
                _tbContainer.Clear();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    string pathName = openFileDialog1.FileName;
                    var fileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                    string strConn = string.Empty;
                    string sheetName;

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Mode=Read;Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Mode=Read;Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Mode=Read;Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                            break;
                    }
                    OleDbConnection cnnxls = new OleDbConnection(strConn);

                    cnnxls.Open();
                    DataTable dtSheet = cnnxls.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    cnnxls.Close();


                    sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();

                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}]", sheetName), cnnxls);
                    oda.Fill(_tbContainer);

                    if (_tbContainer.Columns.Count < 3)
                        _tbContainer.Columns.Add("Info", typeof(string));

                    if (_tbContainer.Columns.Count < 4)
                        _tbContainer.Columns.Add("Groupe", typeof(string));

                    _tbContainer.Columns[0].ColumnName = "Questions";
                    _tbContainer.Columns[1].ColumnName = "Réponses";
                    _tbContainer.Columns[2].ColumnName = "Info";
                    _tbContainer.Columns[3].ColumnName = "Groupe";

                    dataGridView1.DataSource = _tbContainer;

                    btnGen.Enabled = true; 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.Message);
            }
        }

        string sqlFilter(string s)
        {
            return s;
        }

        private void btnGen_Click(object sender, EventArgs e)
        {

            bool result;
            var createdList = new List<string>();

            var startViewCount = TabloidConfig.Config.Views.Count;

            //clean response list
            foreach (DataRow dr in _tbContainer.Rows)
            {
                if (dr.RowState!=DataRowState.Deleted&&dr["Réponses"].ToString() != "")
                {
                    var r = dr["Réponses"].ToString().Trim();
                    r = r.Replace('-', ';');
                    dr["Réponses"] = r;
                }
            }

            _tbContainer.AcceptChanges();

            //search duplicate response list for combo box
            _tbContainer.Columns.Add("Liste");
            var list = 0;

            foreach (DataRow dr in _tbContainer.Rows)
            {
                if (dr.RowState != DataRowState.Deleted && dr["Réponses"].ToString() != "" && dr["Liste"] == DBNull.Value)
                {
                    var currentListName = "lr" + list.ToString();

                    dr["Liste"] = currentListName;

                    var dv = new DataView(_tbContainer, string.Format("Réponses like '{0}'", DataTools.ExtendedStringToSql(dr["Réponses"].ToString())), "", DataViewRowState.Unchanged);
                    foreach (DataRowView drv in dv)
                        drv["Liste"] = currentListName;

                    list++;
                }
            }

            //add new View
            var param = new string[] { Program.AppSet.Schema, txtVue.Text, "id_" + txtVue.Text };
            var t = new TabloidConfigView
            {
                Schema = param[0],
                Nom = txtVue.Text,
                Titre = txtVue.Text,
                NomTable = txtVue.Text,
                DbKey = param[2],
                Detail = true,
                DisplayOnTowRow=true
            };

            result = WizardSQLHelper.ExecuteFromFile("table.sql", param, Program.AppSet.ConnectionString);
            if (!result) return;

            var i = 1;
            param = new string[] { txtVue.Text, "", "", Program.AppSet.Schema };
            foreach (DataRow dr in _tbContainer.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    param[1] = "R" + i;
                    var info = dr["Info"].ToString();

                    var Tc = new TabloidConfigColonne
                    {
                        Nom = "C" + i,
                        Champ = "r" + i,
                        Groupe = "!!!" + dr["Groupe"],
                        Titre = dr["Questions"].ToString(),
                        VisibleListe = false,
                        Information= info
                    };

                    if (dr["Réponses"].ToString() == "")
                    { //TextBox
                        Tc.Editeur = Tabloid.Classes.Controls.TemplateType.Defaut;
                        Tc.Type = DbType.String;
                        param[2] = dataHelper.DbTypeConverter.ConvertFromGenericDbType(DbType.String, Classes.WizardTools.Tools.ConvertProviderType(Program.AppSet.ProviderType));
                        result = WizardSQLHelper.ExecuteFromFile("addField.sql", param, Program.AppSet.ConnectionString);

                        t.Colonnes.Add(Tc);
                    }
                    else
                    {//ComboBox
                        var tableCreationNeeded = !createdList.Contains(dr["Liste"].ToString());

                        result = WizardSQLHelper.SetDataBaseForList(false, Program.AppSet.Schema, dr["Liste"].ToString(), dr["Liste"].ToString(), "id_" + dr["Liste"].ToString(), false, t, Tc.Champ, Program.AppSet.ConnectionString, Program.AppSet.ProviderType, true, false, tableCreationNeeded ? "" : "alr" + i, !tableCreationNeeded);

                        var c = t.Colonnes[t.Colonnes.Count - 1];//last added column
                        c.Groupe = "!!!" + dr["Groupe"];
                        c.Editeur = Tabloid.Classes.Controls.TemplateType.ComboBox;//replace comboboxplus by combobox
                        c.Titre = dr["Questions"].ToString();
                        c.VisibleListe = false;
                        c.Obligatoire = true;
                        c.Information = info;
                        createdList.Add(dr["Liste"].ToString());
                    }

                    i++;
                }
            }

            t.Index = TabloidConfig.Config.Views.Count - startViewCount;
            TabloidConfig.Config.Views.Add(t);
            
            // fill possible response table (lrx)
            DataView view = new DataView(_tbContainer);
            DataTable distinctValues = view.ToTable(true, "Liste", "Réponses");

            foreach (DataRow dr in distinctValues.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    var sols = dr["Réponses"].ToString().Split(';');
                    var values = "";

                    foreach (string sol in sols)
                        values += $"('{DataTools.StringToSql(sol.Trim())}'),";


                    values = values.TrimEnd(',');

                    var sql = $"INSERT INTO {Program.AppSet.Schema}.{ dr["Liste"]} (nom_{ dr["Liste"]}) VALUES {values}";

                    string error;
                    DataTools.Command(sql, null, Program.AppSet.ConnectionString, out error);
                }
            }


            //add default url field in user table
            var sqlType = dataHelper.DbTypeConverter.ConvertFromGenericDbType(DbType.String, Classes.WizardTools.Tools.ConvertProviderType(Program.AppSet.ProviderType));
            var requestParam = new string[] { "roles", "default_url", sqlType+$"(300)", Program.AppSet.Schema };
            WizardSQLHelper.ExecuteFromFile("addField.sql", requestParam, Program.AppSet.ConnectionString);

            //add role "sonde"
            var detailURL=AppSetting.GetDefaultPageURL(t.Nom,TabloidPages.Type.Detail)+ "&mode=questionnaire";
            var profileRight = (ulong)Math.Pow(2, t.Index);
            //var profileRight2 = ~profileRight;

            var sql2 = $"insert into roles (titre_role,datemaj_roles,droits_lecture,droits_ecriture,droits_limite,droits_limiteecr,droits_suppression,default_url) values ('Sondé',now(),{profileRight},{profileRight},{profileRight},{profileRight},0,'{detailURL}')";

            sql2+= string.Format(
                          SqlConverter.GetSql(SqlConverter.SqlType.InsertCommandKeyOut),
                          "id_role");

            string error2;

            var roleId=DataTools.ScalarCommand(sql2, null, Program.AppSet.ConnectionString, out error2);

            //set config
            Program.AppSet.TabloidType = TabloidTypes.Questionnaire;
            AppSetting.setDefaultPage(t.Nom);
            Program.AppSet.champPageDefaut = "default_url";
            Program.AppSet.AutoenrollmentRole = roleId.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
