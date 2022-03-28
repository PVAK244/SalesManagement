using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmOrders : Form
    {
        public bool FrmOrderState { get; set; }
        public bool isPermit { get; set; }
        IOrderRepository? orderRepository = new OrderRepository();
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource? source;
        public frmOrders()
        {
            InitializeComponent();
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {
            if (!isPermit)
            {
                btnAdd.Enabled = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrderPopup frmOrderPopup = new frmOrderPopup
            {
                Text = "Add Order",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmOrderPopup.ShowDialog() == DialogResult.OK)
            {
                if (source != null) source.Position = source.Position - 1;
            }
            LoadOrderList();
        }

        public void LoadOrderList()
        {
            var orders = orderRepository?.GetOrders();
            try
            {
                //The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source.
                source = new BindingSource();
                source.DataSource = orders;

                txtOrderId.DataBindings.Clear();
                txtMemberId.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderId.DataBindings.Add("Text", source, "OrderID");
                txtMemberId.DataBindings.Add("Text", source, "MemberID");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;

                if (orders?.Count() == 0)
                {
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }

        private OrderObject GetOrderObject()
        {
            OrderObject? order = null;
            try
            {
                order = new OrderObject
                {
                    OrderID = int.Parse(txtOrderId.Text),
                    MemberID = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get an order");
            }
            return order;
        }

        private void ClearText()
        {
            txtOrderId.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
            txtFreight.Text = string.Empty;
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderPopup frmOrderPopup = new frmOrderPopup
            {
                Text = "Update Order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository
            };
            if (frmOrderPopup.ShowDialog() == DialogResult.OK)
            {
                if (source != null) source.Position = source.Position - 1;
            }
            LoadOrderList();
        }
    }
}
