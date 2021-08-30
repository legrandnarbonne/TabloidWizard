using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    public partial class ExcludeTableForm : MetroForm
    {
        public string ExcludedCommand;
        public string[] ExcludedView;
        TabloidConfig _config;
        string _savePath;
        bool _initializing = false;

        public ExcludeTableForm(TabloidConfig config, string savePath)
        {
            InitializeComponent();
            _config = config;
            _savePath = savePath;

            string lastError;

            var dt = DataTools.Data(SqlCommands.SqlGetTable(Program.AppSet.Schema), Program.AppSet.ConnectionString, out lastError);

            var defaultExcludedTable = LoadSelection();
            _initializing = true;

            foreach (DataRow item in dt.Rows)
            {
                var itemName = item[dt.Columns[0].ColumnName].ToString();
                var isChecked = !defaultExcludedTable.Contains(itemName.ToLower());

                checkedListBox1.Items.Add(itemName, isChecked);
            }

            _initializing = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var patern = " --exclude-table-data=";
            var tempExcludedView = new List<string>();//store list of view using excluding table to remove corresponding upload files
            var tempExcludedTable = new List<string>();//store list of excluding table to store in file

            ExcludedCommand = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    ExcludedCommand += patern + $"\"{Program.AppSet.Schema}.{checkedListBox1.Items[i]}\"";

                    var views = _config.Views.GetViewsFromTableNAme(checkedListBox1.Items[i].ToString());

                    tempExcludedTable.Add(checkedListBox1.Items[i].ToString());
                    tempExcludedView.AddRange(views.Select(v => v.Nom));
                }
            }

            ExcludedView = tempExcludedView.ToArray();

            SaveSelection(tempExcludedTable);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveSelection(List<string> tempExcludedTable)
        {
            if (string.IsNullOrEmpty(_savePath)) return;

            var serializer = new XmlSerializer(tempExcludedTable.GetType());

            using (var stream = File.OpenWrite(_savePath + @"\exportExcludedTable.mem"))
            {
                serializer.Serialize(stream, tempExcludedTable);
            }
        }

        private string[] LoadSelection()
        {
            var defaultValue = new[] { "utilisateurs", "lst_roles", "tabchat", "tracesenvois","cart" };

            if (string.IsNullOrEmpty(_savePath)) return defaultValue;

            var fi = new FileInfo(_savePath + @"\exportExcludedTable.mem");

            if (!fi.Exists) return defaultValue;

            var list = new List<string>();

            var serializer = new XmlSerializer(typeof(List<string>));

            using (var stream = File.OpenRead(_savePath + @"\exportExcludedTable.mem"))
                list = (List<string>)(serializer.Deserialize(stream));

            return list.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lookFor1NJoin(string tableName)
        {                        
            var newList=get1NList(tableName);

            if (newList.Count > 0)
            {
                string pucePatern = "\r\n  - ";

                if (
                    MetroMessageBox.Show(this, 
                        $"D'autre table sont liées à la table '{tableName}' :{pucePatern}{string.Join("," + pucePatern, newList)}.\r\n\r\n Souhaitez vous les déselectionner automatiquement.", 
                        "Table Liées",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                        350)
                    == DialogResult.OK)
                {
                    _initializing = true;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked && newList.Contains(checkedListBox1.Items[i].ToString()))
                        {
                            checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                    _initializing = false;
                }
            }
        }

        private List<string> get1NList(string tableName,List<string> newList=null,List<string> treatedTable=null)
        {
            var lastError = "";

            if (newList == null) newList = new List<string>();
            if (treatedTable == null) treatedTable = new List<string>();

            treatedTable.Add(tableName);

            var sql = SqlCommands.SqlGet1NFromConstraint(tableName, Program.AppSet.Schema);

            var dt = DataTools.Data(sql, Program.AppSet.ConnectionString, out lastError);

            var currentList=dt
                    .AsEnumerable()
                    .Select(row => row.Field<string>("table_name"))
                    .ToList();

            foreach (var table in currentList.ToArray())
                if (!treatedTable.Contains(table,StringComparer.InvariantCultureIgnoreCase)) get1NList(table, currentList);

            newList.AddRange(currentList);

            return newList;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_initializing && e.NewValue == CheckState.Unchecked)
                lookFor1NJoin(((CheckedListBox)sender).SelectedItem.ToString());

        }
    }
}
