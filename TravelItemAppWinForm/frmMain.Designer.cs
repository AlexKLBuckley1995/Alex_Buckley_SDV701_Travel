namespace TravelItemAppWinForm
{
    partial class frmMain
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
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTravelCategories = new System.Windows.Forms.Label();
            this.btnPendingOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstLocations
            // 
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(12, 28);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(362, 160);
            this.lstLocations.TabIndex = 1;
            this.lstLocations.DoubleClick += new System.EventHandler(this.lstLocations_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(393, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTravelCategories
            // 
            this.lblTravelCategories.AutoSize = true;
            this.lblTravelCategories.Location = new System.Drawing.Point(12, 9);
            this.lblTravelCategories.Name = "lblTravelCategories";
            this.lblTravelCategories.Size = new System.Drawing.Size(82, 13);
            this.lblTravelCategories.TabIndex = 5;
            this.lblTravelCategories.Text = "Travel locations";
            // 
            // btnPendingOrders
            // 
            this.btnPendingOrders.Location = new System.Drawing.Point(393, 95);
            this.btnPendingOrders.Name = "btnPendingOrders";
            this.btnPendingOrders.Size = new System.Drawing.Size(75, 53);
            this.btnPendingOrders.TabIndex = 6;
            this.btnPendingOrders.Text = "View pending orders";
            this.btnPendingOrders.UseVisualStyleBackColor = true;
            this.btnPendingOrders.Click += new System.EventHandler(this.btnPendingOrders_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 245);
            this.Controls.Add(this.btnPendingOrders);
            this.Controls.Add(this.lblTravelCategories);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstLocations);
            this.Name = "frmMain";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstLocations;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTravelCategories;
        private System.Windows.Forms.Button btnPendingOrders;
    }
}

