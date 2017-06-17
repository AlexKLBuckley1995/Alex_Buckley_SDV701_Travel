namespace TravelItemAppWinForm
{
    partial class frmItem
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemModified = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemBrand = new System.Windows.Forms.TextBox();
            this.txtQuantityAvailable = new System.Windows.Forms.TextBox();
            this.lblQuantityAvailable = new System.Windows.Forms.Label();
            this.btnItemOk = new System.Windows.Forms.Button();
            this.btnItemCancel = new System.Windows.Forms.Button();
            this.lblDateModifiedValue = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(13, 13);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(35, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Name";
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Location = new System.Drawing.Point(13, 49);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(35, 13);
            this.lblBrandName.TabIndex = 1;
            this.lblBrandName.Text = "Brand";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Location = new System.Drawing.Point(13, 86);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(74, 13);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "Price (in NZD)";
            // 
            // lblItemModified
            // 
            this.lblItemModified.AutoSize = true;
            this.lblItemModified.Location = new System.Drawing.Point(13, 128);
            this.lblItemModified.Name = "lblItemModified";
            this.lblItemModified.Size = new System.Drawing.Size(73, 13);
            this.lblItemModified.TabIndex = 3;
            this.lblItemModified.Text = "Date Modified";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(90, 13);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 20);
            this.txtItemName.TabIndex = 5;
            // 
            // txtItemBrand
            // 
            this.txtItemBrand.Location = new System.Drawing.Point(90, 46);
            this.txtItemBrand.Name = "txtItemBrand";
            this.txtItemBrand.Size = new System.Drawing.Size(100, 20);
            this.txtItemBrand.TabIndex = 6;
            // 
            // txtQuantityAvailable
            // 
            this.txtQuantityAvailable.Location = new System.Drawing.Point(123, 165);
            this.txtQuantityAvailable.Name = "txtQuantityAvailable";
            this.txtQuantityAvailable.Size = new System.Drawing.Size(100, 20);
            this.txtQuantityAvailable.TabIndex = 8;
            this.txtQuantityAvailable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantityAvailable_KeyPress);
            // 
            // lblQuantityAvailable
            // 
            this.lblQuantityAvailable.AutoSize = true;
            this.lblQuantityAvailable.Location = new System.Drawing.Point(16, 168);
            this.lblQuantityAvailable.Name = "lblQuantityAvailable";
            this.lblQuantityAvailable.Size = new System.Drawing.Size(91, 13);
            this.lblQuantityAvailable.TabIndex = 9;
            this.lblQuantityAvailable.Text = "Quantity available";
            // 
            // btnItemOk
            // 
            this.btnItemOk.Location = new System.Drawing.Point(292, 230);
            this.btnItemOk.Name = "btnItemOk";
            this.btnItemOk.Size = new System.Drawing.Size(75, 23);
            this.btnItemOk.TabIndex = 10;
            this.btnItemOk.Text = "Ok";
            this.btnItemOk.UseVisualStyleBackColor = true;
            this.btnItemOk.Click += new System.EventHandler(this.btnItemOk_Click);
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Location = new System.Drawing.Point(292, 269);
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.Size = new System.Drawing.Size(75, 23);
            this.btnItemCancel.TabIndex = 11;
            this.btnItemCancel.Text = "Cancel";
            this.btnItemCancel.UseVisualStyleBackColor = true;
            this.btnItemCancel.Click += new System.EventHandler(this.btnItemCancel_Click);
            // 
            // lblDateModifiedValue
            // 
            this.lblDateModifiedValue.AutoSize = true;
            this.lblDateModifiedValue.Location = new System.Drawing.Point(117, 128);
            this.lblDateModifiedValue.Name = "lblDateModifiedValue";
            this.lblDateModifiedValue.Size = new System.Drawing.Size(0, 13);
            this.lblDateModifiedValue.TabIndex = 12;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(93, 83);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 306);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblDateModifiedValue);
            this.Controls.Add(this.btnItemCancel);
            this.Controls.Add(this.btnItemOk);
            this.Controls.Add(this.lblQuantityAvailable);
            this.Controls.Add(this.txtQuantityAvailable);
            this.Controls.Add(this.txtItemBrand);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemModified);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblBrandName);
            this.Controls.Add(this.lblItemName);
            this.Name = "frmItem";
            this.Text = "frmItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblItemModified;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemBrand;
        private System.Windows.Forms.TextBox txtQuantityAvailable;
        private System.Windows.Forms.Label lblQuantityAvailable;
        private System.Windows.Forms.Button btnItemOk;
        private System.Windows.Forms.Button btnItemCancel;
        private System.Windows.Forms.Label lblDateModifiedValue;
        private System.Windows.Forms.TextBox txtPrice;
    }
}