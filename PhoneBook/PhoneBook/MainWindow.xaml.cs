using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Bind();
        }

        public void Bind() 
        {
            string CONNECTION_STRING = @"Server=THOMAS-HOME;Database=phone_book;Trusted_Connection=True;";
            string QUERY = @"SELECT * FROM contacts";
            DataSet dataSet = new();

            try
            {
                using (SqlConnection sqlConnection = new(CONNECTION_STRING))
                {
                    SqlCommand sqlCommand = new(QUERY, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                    sqlDataAdapter.Fill(dataSet, "contacts");
                }

                DataTable contactsTable = dataSet.Tables["contacts"];
                contactsTable.Columns.Remove("id");
                contactsTable.Columns.Remove("middle_names");
                contactsTable.Columns.Remove("prefix");
                contactsTable.Columns.Remove("notes");

                contactsTable.Columns["last_name"].ColumnName = "Last name";
                contactsTable.Columns["first_name"].ColumnName = "First name";
                contactsTable.Columns["mobile_number"].ColumnName = "Mobile number";
                contactsTable.Columns["landline_number"].ColumnName = "Landline number";

                DataView dataView = new(contactsTable, string.Empty, "Last name", DataViewRowState.CurrentRows);

                grdContacts.ItemsSource = dataView;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        public void Unbind() { }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
