namespace TravelItemAppWinForm
{
    partial class frmTravelLocation
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
            this.btnCategoryClose = new System.Windows.Forms.Button();
            this.lstLocationItems = new System.Windows.Forms.ListBox();
            this.btnAddEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.lblLocationDescription = new System.Windows.Forms.Label();
            this.lblLocationDescriptionValue = new System.Windows.Forms.Label();
            this.lblQuantityAvailable = new System.Windows.Forms.Label();
            this.pbLocation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCategoryClose
            // 
            this.btnCategoryClose.Location = new System.Drawing.Point(527, 311);
            this.btnCategoryClose.Name = "btnCategoryClose";
            this.btnCategoryClose.Size = new System.Drawing.Size(75, 23);
            this.btnCategoryClose.TabIndex = 0;
            this.btnCategoryClose.Text = "Close";
            this.btnCategoryClose.UseVisualStyleBackColor = true;
            this.btnCategoryClose.Click += new System.EventHandler(this.btnCategoryClose_Click);
            // 
            // lstLocationItems
            // 
            this.lstLocationItems.FormattingEnabled = true;
            this.lstLocationItems.Location = new System.Drawing.Point(12, 152);
            this.lstLocationItems.Name = "lstLocationItems";
            this.lstLocationItems.Size = new System.Drawing.Size(469, 199);
            this.lstLocationItems.TabIndex = 3;
            this.lstLocationItems.DoubleClick += new System.EventHandler(this.lstLocationItems_DoubleClick);
            // 
            // btnAddEditItem
            // 
            this.btnAddEditItem.Location = new System.Drawing.Point(527, 236);
            this.btnAddEditItem.Name = "btnAddEditItem";
            this.btnAddEditItem.Size = new System.Drawing.Size(75, 40);
            this.btnAddEditItem.TabIndex = 4;
            this.btnAddEditItem.Text = "Add/Edit Item";
            this.btnAddEditItem.UseVisualStyleBackColor = true;
            this.btnAddEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(527, 282);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 5;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(45, 136);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(35, 13);
            this.lblItemName.TabIndex = 6;
            this.lblItemName.Text = "Name";
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(189, 136);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(31, 13);
            this.lblItemType.TabIndex = 7;
            this.lblItemType.Text = "Type";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(301, 136);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 8;
            this.lblLocation.Text = "Location";
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Location = new System.Drawing.Point(16, 13);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(64, 13);
            this.lblLocationName.TabIndex = 10;
            this.lblLocationName.Text = "Default text ";
            // 
            // lblLocationDescription
            // 
            this.lblLocationDescription.AutoSize = true;
            this.lblLocationDescription.Location = new System.Drawing.Point(189, 13);
            this.lblLocationDescription.Name = "lblLocationDescription";
            this.lblLocationDescription.Size = new System.Drawing.Size(60, 13);
            this.lblLocationDescription.TabIndex = 11;
            this.lblLocationDescription.Text = "Description";
            // 
            // lblLocationDescriptionValue
            // 
            this.lblLocationDescriptionValue.AutoSize = true;
            this.lblLocationDescriptionValue.Location = new System.Drawing.Point(268, 13);
            this.lblLocationDescriptionValue.Name = "lblLocationDescriptionValue";
            this.lblLocationDescriptionValue.Size = new System.Drawing.Size(0, 13);
            this.lblLocationDescriptionValue.TabIndex = 12;
            // 
            // lblQuantityAvailable
            // 
            this.lblQuantityAvailable.AutoSize = true;
            this.lblQuantityAvailable.Location = new System.Drawing.Point(402, 136);
            this.lblQuantityAvailable.Name = "lblQuantityAvailable";
            this.lblQuantityAvailable.Size = new System.Drawing.Size(91, 13);
            this.lblQuantityAvailable.TabIndex = 13;
            this.lblQuantityAvailable.Text = "Quantity available";
            // 
            // pbLocation
            // 
            this.pbLocation.Location = new System.Drawing.Point(474, 13);
            this.pbLocation.Name = "pbLocation";
            this.pbLocation.Size = new System.Drawing.Size(164, 100);
            this.pbLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLocation.TabIndex = 14;
            this.pbLocation.TabStop = false;
            // 
            // frmTravelLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 363);
            this.Controls.Add(this.pbLocation);
            this.Controls.Add(this.lblQuantityAvailable);
            this.Controls.Add(this.lblLocationDescriptionValue);
            this.Controls.Add(this.lblLocationDescription);
            this.Controls.Add(this.lblLocationName);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnAddEditItem);
            this.Controls.Add(this.lstLocationItems);
            this.Controls.Add(this.btnCategoryClose);
            this.Name = "frmTravelLocation";
            this.Text = "View location items";
            ((System.ComponentModel.ISupportInitialize)(this.pbLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCategoryClose;
        private System.Windows.Forms.ListBox lstLocationItems;
        private System.Windows.Forms.Button btnAddEditItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Label lblLocationDescription;
        private System.Windows.Forms.Label lblLocationDescriptionValue;
        private System.Windows.Forms.Label lblQuantityAvailable;
        private System.Windows.Forms.PictureBox pbLocation;
    }
}