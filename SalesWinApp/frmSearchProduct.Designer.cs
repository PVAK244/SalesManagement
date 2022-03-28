namespace SalesWinApp
{
    partial class frmSearchProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbProductProperties = new System.Windows.Forms.Label();
            this.cbProductProperties = new System.Windows.Forms.ComboBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.dgvProductSearchList = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.businessDataProviderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.businessDataProviderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.businessDataProviderBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSearchList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbProductProperties
            // 
            this.lbProductProperties.AutoSize = true;
            this.lbProductProperties.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbProductProperties.Location = new System.Drawing.Point(52, 34);
            this.lbProductProperties.Name = "lbProductProperties";
            this.lbProductProperties.Size = new System.Drawing.Size(98, 31);
            this.lbProductProperties.TabIndex = 0;
            this.lbProductProperties.Text = "Column:";
            // 
            // cbProductProperties
            // 
            this.cbProductProperties.AutoCompleteCustomSource.AddRange(new string[] {
            "ProductId",
            "ProductName",
            "UnitPrice",
            "UnitInStock"});
            this.cbProductProperties.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductProperties.FormattingEnabled = true;
            this.cbProductProperties.Items.AddRange(new object[] {
            "ProductId",
            "ProductName",
            "UnitPrice",
            "UnitInStock"});
            this.cbProductProperties.Location = new System.Drawing.Point(160, 30);
            this.cbProductProperties.Name = "cbProductProperties";
            this.cbProductProperties.Size = new System.Drawing.Size(244, 39);
            this.cbProductProperties.TabIndex = 1;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSearch.Location = new System.Drawing.Point(483, 34);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(87, 31);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Search:";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchProduct.Location = new System.Drawing.Point(571, 31);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(380, 38);
            this.txtSearchProduct.TabIndex = 3;
            this.txtSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchProduct_KeyDown);
            // 
            // dgvProductSearchList
            // 
            this.dgvProductSearchList.AllowUserToAddRows = false;
            this.dgvProductSearchList.AllowUserToDeleteRows = false;
            this.dgvProductSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSearchList.Location = new System.Drawing.Point(52, 87);
            this.dgvProductSearchList.Name = "dgvProductSearchList";
            this.dgvProductSearchList.ReadOnly = true;
            this.dgvProductSearchList.RowHeadersWidth = 51;
            this.dgvProductSearchList.RowTemplate.Height = 29;
            this.dgvProductSearchList.Size = new System.Drawing.Size(899, 529);
            this.dgvProductSearchList.TabIndex = 4;
            // 
            // businessDataProviderBindingSource
            // 
            // 
            // businessDataProviderBindingSource1
            // 
            // 
            // businessDataProviderBindingSource2
            // 
            // 
            // frmSearchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 647);
            this.Controls.Add(this.dgvProductSearchList);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.cbProductProperties);
            this.Controls.Add(this.lbProductProperties);
            this.Name = "frmSearchProduct";
            this.Text = "Search Product Item";
            this.Load += new System.EventHandler(this.frmSearchProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSearchList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessDataProviderBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductProperties;
        private System.Windows.Forms.ComboBox cbProductProperties;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.DataGridView dgvProductSearchList;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource businessDataProviderBindingSource;
        private System.Windows.Forms.BindingSource businessDataProviderBindingSource1;
        private System.Windows.Forms.BindingSource businessDataProviderBindingSource2;
    }
}