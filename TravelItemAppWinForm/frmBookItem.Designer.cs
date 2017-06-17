namespace TravelItemAppWinForm
{
    partial class frmBookItem
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
            this.lblISBNNumber = new System.Windows.Forms.Label();
            this.lblBookWeight = new System.Windows.Forms.Label();
            this.txtISBNNumber = new System.Windows.Forms.TextBox();
            this.txtBookWeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblISBNNumber
            // 
            this.lblISBNNumber.AutoSize = true;
            this.lblISBNNumber.Location = new System.Drawing.Point(16, 211);
            this.lblISBNNumber.Name = "lblISBNNumber";
            this.lblISBNNumber.Size = new System.Drawing.Size(70, 13);
            this.lblISBNNumber.TabIndex = 13;
            this.lblISBNNumber.Text = "ISBN number";
            // 
            // lblBookWeight
            // 
            this.lblBookWeight.AutoSize = true;
            this.lblBookWeight.Location = new System.Drawing.Point(16, 250);
            this.lblBookWeight.Name = "lblBookWeight";
            this.lblBookWeight.Size = new System.Drawing.Size(99, 13);
            this.lblBookWeight.TabIndex = 14;
            this.lblBookWeight.Text = "Book weight (in Kg)";
            // 
            // txtISBNNumber
            // 
            this.txtISBNNumber.Location = new System.Drawing.Point(109, 208);
            this.txtISBNNumber.Name = "txtISBNNumber";
            this.txtISBNNumber.Size = new System.Drawing.Size(100, 20);
            this.txtISBNNumber.TabIndex = 15;
            // 
            // txtBookWeight
            // 
            this.txtBookWeight.Location = new System.Drawing.Point(123, 247);
            this.txtBookWeight.Name = "txtBookWeight";
            this.txtBookWeight.Size = new System.Drawing.Size(100, 20);
            this.txtBookWeight.TabIndex = 16;
            this.txtBookWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookWeight_KeyPress);
            // 
            // frmBookItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 306);
            this.Controls.Add(this.txtBookWeight);
            this.Controls.Add(this.txtISBNNumber);
            this.Controls.Add(this.lblBookWeight);
            this.Controls.Add(this.lblISBNNumber);
            this.Name = "frmBookItem";
            this.Text = "Book";
            this.Controls.SetChildIndex(this.lblISBNNumber, 0);
            this.Controls.SetChildIndex(this.lblBookWeight, 0);
            this.Controls.SetChildIndex(this.txtISBNNumber, 0);
            this.Controls.SetChildIndex(this.txtBookWeight, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblISBNNumber;
        private System.Windows.Forms.Label lblBookWeight;
        private System.Windows.Forms.TextBox txtISBNNumber;
        private System.Windows.Forms.TextBox txtBookWeight;
    }
}