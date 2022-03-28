using System;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Linq;

namespace SalesWinApp
{
    public partial class frmMembers : Form
    {
        public bool FrmMemberState { get; set; }
        public bool isPermit { get; set; }
        public int AccountID { get; set; }
        public frmMembers()
        {
            InitializeComponent();
        }
        IMemberRepository? memberRepository = new MemberRepository();
        BindingSource? source;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!isPermit)
            {
                LoadMemberList(AccountID);
            }
            else LoadMemberList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                if (source != null) source.Position = source.Position - 1;
            }
            LoadMemberList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                memberRepository?.DeleteMember(member.MemberID);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail
            {
                Text = "Update member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                if (source != null) source.Position = source.Count - 1;
            }
            LoadMemberList(AccountID);
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            if (!isPermit)
            {
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        public void LoadMemberList(int memberId = -1)
        {
            var members = memberRepository?.GetMembers();
            var member = memberRepository?.GetMemberByID(memberId);
            try
            {
                //The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source.
                source = new BindingSource();
                if (member != null)
                {
                    source.DataSource = member;
                } 
                else
                {
                    source.DataSource = members;
                }

                txtMemberId.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtMemberId.DataBindings.Add("Text", source, "MemberID");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

                if (members?.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (isPermit) btnDelete.Enabled = true;
                    else btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private MemberObject GetMemberObject()
        {
            MemberObject? member = null;
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        private void ClearText()
        {
            txtMemberId.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
