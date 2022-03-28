using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmProductDetail : Form
    {
        public frmProductDetail()
        {
            InitializeComponent();
        }

        public IProductRepository? ProductRepository { get; set; }
        public ICategoryRepository categoryRepository = new CategoryRepository();
        BindingSource? source;

        public bool InsertOrUpdate { get; set; } // False: Insert, True: Update
        public ProductObject? ProductInfo { get; set; }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true) // Update mode.
            {
                // Show product to perform updating.
                txtProductId.Text = ProductInfo?.ProductID.ToString();
                txtCategoryId.Text = ProductInfo?.CategoryID.ToString();
                txtProductName.Text = ProductInfo?.ProductName.ToString();
                txtWeight.Text = ProductInfo?.Weight.ToString();
                txtUnitPrice.Text = ProductInfo?.UnitPrice.ToString();
                txtUnitInStock.Text = ProductInfo?.UnitInStock.ToString();
            }
            LoadCategoryList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = default(ProductObject);
            try
            {
                if (txtProductId.Text != "")
                {
                    product = new ProductObject
                    {
                        ProductID = int.Parse(txtProductId.Text),
                        CategoryID = int.Parse(txtCategoryId.Text),
                        ProductName = txtProductName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = decimal.Parse(txtUnitPrice.Text),
                        UnitInStock = int.Parse(txtUnitInStock.Text)
                    };
                }
                else
                {
                    product = new ProductObject
                    {
                        CategoryID = int.Parse(txtCategoryId.Text),
                        ProductName = txtProductName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = decimal.Parse(txtUnitPrice.Text),
                        UnitInStock = int.Parse(txtUnitInStock.Text)
                    };
                }
                if (InsertOrUpdate == false)
                {
                    ProductRepository?.InsertProduct(product);
                }
                else
                {
                    ProductRepository?.UpdateProduct(product);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ?
                    "Add a new Product" : "Update a product");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => Close();

        private void dgvCategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCategoryList();
        }

        public void LoadCategoryList()
        {
            var categories = categoryRepository.GetCategories();
            try
            {
                // The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source.
                source = new BindingSource();
                source.DataSource = categories;

                dgvCategoryList.DataSource = null;
                dgvCategoryList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load category list");
            }
        }
    }
}
