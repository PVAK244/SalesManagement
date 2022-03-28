using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        public bool FrmProuductState { get; set; }
        public bool isPermit { get; set; }
        public frmProducts()
        {
            InitializeComponent();
        }

        IProductRepository? productRepository = new ProductRepository();
        BindingSource? source;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isPermit)
            {
                frmProductDetail frmProductDetail = new frmProductDetail
                {
                    Text = "Add Product",
                    InsertOrUpdate = false,
                    ProductRepository = productRepository
                };
                if (frmProductDetail.ShowDialog() == DialogResult.OK)
                {
                    if (source != null) source.Position = source.Position - 1;
                }
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isPermit)
            {
                try
                {
                    var product = GetProductObject();
                    productRepository?.DeleteProduct(product.ProductID);
                    LoadProductList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a product");
                }
            }
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isPermit)
            {
                frmProductDetail frmProductDetail = new frmProductDetail
                {
                    Text = "Update product",
                    InsertOrUpdate = true,
                    ProductInfo = GetProductObject(),
                    ProductRepository = productRepository
                };
                if (frmProductDetail.ShowDialog() == DialogResult.OK)
                {
                    if (source != null) source.Position = source.Count - 1;
                }
                LoadProductList();
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            if (!isPermit)
            {
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        public void LoadProductList()
        {
            var products = productRepository?.GetProducts();
            try
            {
                //The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source.
                source = new BindingSource();
                source.DataSource = products;

                txtProductId.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();
                
                txtProductId.DataBindings.Add("Text", source, "ProductID");
                txtCategoryId.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitInStock.DataBindings.Add("Text", source, "UnitInStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;

                if (products?.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (!isPermit) btnDelete.Enabled = false;
                    else btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private ProductObject GetProductObject()
        {
            ProductObject? product = null;
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Product");
            }
            return product;
        }

        private void ClearText()
        {
            txtProductId.Text = string.Empty;
            txtCategoryId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitInStock.Text = string.Empty;
        }

    }
}
