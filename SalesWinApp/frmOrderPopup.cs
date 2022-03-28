using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmOrderPopup : Form
    {
        public IOrderRepository? OrderRepository { get; set; }
        public bool InsertOrUpdate { get; set; } // False: Insert, True: Update
        public OrderObject? OrderInfo { get; set; }

        public frmOrderPopup()
        {
            InitializeComponent();
        }

        private void frmOrderPopup_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true) // Update mode.
            {
                // Show product to perform updating.
                txtOrderId.Text = OrderInfo?.OrderID.ToString();
                txtMemberId.Text = OrderInfo?.MemberID.ToString();
                dtpOrderDate.Text = OrderInfo?.OrderDate.ToString();
                dtpRequiredDate.Text = OrderInfo?.RequiredDate.ToString();
                dtpShippedDate.Text = OrderInfo?.ShippedDate.ToString();
                txtFreight.Text = OrderInfo?.Freight.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var order = default(OrderObject);
            try
            {
                if (txtOrderId.Text != "")
                {
                    order = new OrderObject
                    {
                        OrderID = int.Parse(txtOrderId.Text),
                        MemberID = int.Parse(txtMemberId.Text),
                        OrderDate = DateTime.Parse(dtpOrderDate.Text),
                        RequiredDate = DateTime.Parse(dtpRequiredDate.Text),
                        ShippedDate = DateTime.Parse(dtpShippedDate.Text),
                        Freight = decimal.Parse(txtFreight.Text),
                    };
                }
                else
                {
                    order = new OrderObject
                    {
                        MemberID = int.Parse(txtMemberId.Text),
                        OrderDate = DateTime.Parse(dtpOrderDate.Text),
                        RequiredDate = DateTime.Parse(dtpRequiredDate.Text),
                        ShippedDate = DateTime.Parse(dtpShippedDate.Text),
                        Freight = decimal.Parse(txtFreight.Text),
                    };
                }
                if (InsertOrUpdate == false)
                {
                    OrderRepository?.InsertOrder(order);
                }
                else
                {
                    OrderRepository?.UpdateOrder(order);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ?
                    "Add a new a Member" : "Update a Member");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
