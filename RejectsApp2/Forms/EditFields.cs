using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2.Forms
{
    public partial class EditFields : Form
    {
        public EditFields()
        {
            InitializeComponent();
        }

        private void FieldTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clears original box of items, preparing it to be filled again
            OriginalBox.Items.Clear();
            //gets the selected field type
            var fieldType = FieldTypeBox.SelectedItem.ToString();
            //sets query to get the contents of the field
            var q = "SELECT * FROM " + fieldType;
            var dt = GetValuesForForm(q);
            //adds the contents to the listbox
            foreach (DataRow datarow in dt.Rows) OriginalBox.Items.Add(datarow.ItemArray[0].ToString());
        }

        //used to update listbox after submission
        private void FieldTypeBox_Refresh()
        {
            OriginalBox.Items.Clear();
            var fieldType = FieldTypeBox.SelectedItem.ToString();
            var q = "SELECT * FROM " + fieldType;
            var dt = GetValuesForForm(q);

            foreach (DataRow datarow in dt.Rows) OriginalBox.Items.Add(datarow.ItemArray[0].ToString());
        }

        private void SubmitChangeButton_Click(object sender, EventArgs e)
        {
            //operation being performed
            var operation = revisionTypeBox.Text;
            //the field table type i.e Product_Lines
            var fieldType = FieldTypeBox.Text;
            //the user input(only used for adding)
            var input = InputBox.Text;

            //switches based off of operation type

            try
            {
                switch (operation)
                {
                    case "Add":
                        if (!string.IsNullOrEmpty(fieldType) && !string.IsNullOrEmpty(input))
                        {
                            //set query
                            var query = "INSERT INTO " + fieldType + " VALUES ('" + input + "')";
                            ModifyField(query);
                            //refresh box w results of query
                            FieldTypeBox_Refresh();
                            MessageBox.Show("Field successfully input.");
                        }
                        else
                        {
                            MessageBox.Show("Make sure all applicable fields are filled.");
                        }

                        break;

                    case "Delete":
                        var selectedItems = OriginalBox.SelectedItems;
                        var correspondingColumn = getCorrespondingColumn(fieldType);
                        if (!string.IsNullOrEmpty(fieldType) && !string.IsNullOrEmpty(correspondingColumn) &&
                            selectedItems.Count > 0)
                        {
                            //for each item selected, delete
                            foreach (var item in selectedItems)
                            {
                                var query = "DELETE FROM " + fieldType + " WHERE [" + correspondingColumn + "] = '" +
                                            item + "'";
                                ModifyField(query);
                            }

                            //refresh box w results of query
                            FieldTypeBox_Refresh();
                            MessageBox.Show("Field successfully deleted.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "Make sure all applicable fields are filled and an item is selected from the list to be deleted.");
                        }

                        break;
                    case "":
                        MessageBox.Show("Make sure all applicable fields are filled.");
                        break;
                    case null:
                        MessageBox.Show("Make sure all applicable fields are filled.");
                        break;
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == 19)
                    MessageBox.Show(
                        "This field must be unique but it is already present within the table. Try changing the name.");
                else
                    throw;
            }
        }

        private void EditFields_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}