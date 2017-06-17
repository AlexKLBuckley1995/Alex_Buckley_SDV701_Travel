namespace TravelItemAppWinForm
{
    partial class frmMapItem
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
            this.txtMapDimensions = new System.Windows.Forms.TextBox();
            this.txtMapType = new System.Windows.Forms.TextBox();
            this.lblMapDimensions = new System.Windows.Forms.Label();
            this.lblMapType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMapDimensions
            // 
            this.txtMapDimensions.Location = new System.Drawing.Point(143, 249);
            this.txtMapDimensions.Name = "txtMapDimensions";
            this.txtMapDimensions.Size = new System.Drawing.Size(100, 20);
            this.txtMapDimensions.TabIndex = 13;
            // 
            // txtMapType
            // 
            this.txtMapType.Location = new System.Drawing.Point(123, 207);
            this.txtMapType.Name = "txtMapType";
            this.txtMapType.Size = new System.Drawing.Size(100, 20);
            this.txtMapType.TabIndex = 14;
            // 
            // lblMapDimensions
            // 
            this.lblMapDimensions.AutoSize = true;
            this.lblMapDimensions.Location = new System.Drawing.Point(16, 243);
            this.lblMapDimensions.Name = "lblMapDimensions";
            this.lblMapDimensions.Size = new System.Drawing.Size(118, 26);
            this.lblMapDimensions.TabIndex = 15;
            this.lblMapDimensions.Text = "Map dimensions\r\n (in format widthxheight)";
            // 
            // lblMapType
            // 
            this.lblMapType.AutoSize = true;
            this.lblMapType.Location = new System.Drawing.Point(16, 210);
            this.lblMapType.Name = "lblMapType";
            this.lblMapType.Size = new System.Drawing.Size(51, 13);
            this.lblMapType.TabIndex = 16;
            this.lblMapType.Text = "Map type";
            // 
            // frmMapItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 306);
            this.Controls.Add(this.lblMapType);
            this.Controls.Add(this.lblMapDimensions);
            this.Controls.Add(this.txtMapType);
            this.Controls.Add(this.txtMapDimensions);
            this.Name = "frmMapItem";
            this.Text = "Map";
            this.Controls.SetChildIndex(this.txtMapDimensions, 0);
            this.Controls.SetChildIndex(this.txtMapType, 0);
            this.Controls.SetChildIndex(this.lblMapDimensions, 0);
            this.Controls.SetChildIndex(this.lblMapType, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMapDimensions;
        private System.Windows.Forms.TextBox txtMapType;
        private System.Windows.Forms.Label lblMapDimensions;
        private System.Windows.Forms.Label lblMapType;
    }
}