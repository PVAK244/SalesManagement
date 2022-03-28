using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DataAccess.Repository;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SalesWinApp
{
    public partial class frmSearchProduct : Form
    {
        public bool FrmSearchState { get; set; }
        public IProductRepository productRepository = new ProductRepository();
        static BindingSource source = new BindingSource();
        DataTable dataTable = new DataTable("Products");
        public frmSearchProduct()
        {
            InitializeComponent();
        }

        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionStrings:FStoreDB"];
            return connectionString;
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            cbProductProperties.SelectedIndex = 0;
            try
            {
                SqlConnection connection = new SqlConnection(GetConnectionString());
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Product", connection);
                dataAdapter.Fill(dataTable);
                dgvProductSearchList.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load database error");
            }
        }

        private void txtSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = string.Format("CONVERT({0}, System.String) LIKE '{1}%'",
                            cbProductProperties.Text.Trim(), txtSearchProduct.Text.Trim());
            dgvProductSearchList.DataSource = dataView.ToTable();
        }
    }
}
