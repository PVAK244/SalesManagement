using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmMemberDetail : Form
    {
        public IMemberRepository? MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; } // False: Insert, True: Update
        public MemberObject? MemberInfo { get; set; }

        public frmMemberDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var member = default(MemberObject);
            try
            {
                if (txtMemberId.Text != "")
                {
                    member = new MemberObject
                    {
                        MemberID = int.Parse(txtMemberId.Text),
                        Email = txtEmail.Text,
                        CompanyName = txtCompanyName.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Text
                    };
                }
                else
                {
                    member = new MemberObject
                    {
                        Email = txtEmail.Text,
                        CompanyName = txtCompanyName.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Text
                    };
                }
                if (InsertOrUpdate == false)
                {
                    MemberRepository?.InsertMember(member);
                }
                else
                {
                    MemberRepository?.UpdateMember(member);
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
            => Close();

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true) // Update mode.
            {
                // Show product to perform updating.
                txtMemberId.Text = MemberInfo?.MemberID.ToString();
                txtEmail.Text = MemberInfo?.Email;
                txtCompanyName.Text = MemberInfo?.CompanyName;
                txtCity.Text = MemberInfo?.City;
                txtCountry.Text = MemberInfo?.Country;
                txtPassword.Text = MemberInfo?.Password;
            }
        }
    }
}
