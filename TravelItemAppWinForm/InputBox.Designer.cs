namespace TravelItemAppWinForm
{
    partial class InputBox
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
            this.lblCategoryChoice = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.btnOkCategory = new System.Windows.Forms.Button();
            this.btnCancelCategory = new System.Windows.Forms.Button();
            this.lblCategoryInput = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCategoryChoice
            // 
            this.lblCategoryChoice.AutoSize = true;
            this.lblCategoryChoice.Location = new System.Drawing.Point(35, 24);
            this.lblCategoryChoice.Name = "lblCategoryChoice";
            this.lblCategoryChoice.Size = new System.Drawing.Size(196, 13);
            this.lblCategoryChoice.TabIndex = 0;
            this.lblCategoryChoice.Text = "What travel item do you want to create?";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.Location = new System.Drawing.Point(38, 78);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Size = new System.Drawing.Size(353, 20);
            this.txtItemCategory.TabIndex = 1;
            this.txtItemCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemCategory_KeyPress);
            // 
            // btnOkCategory
            // 
            this.btnOkCategory.Location = new System.Drawing.Point(343, 155);
            this.btnOkCategory.Name = "btnOkCategory";
            this.btnOkCategory.Size = new System.Drawing.Size(75, 23);
            this.btnOkCategory.TabIndex = 2;
            this.btnOkCategory.Text = "Ok";
            this.btnOkCategory.UseVisualStyleBackColor = true;
            this.btnOkCategory.Click += new System.EventHandler(this.btnOkCategory_Click);
            // 
            // btnCancelCategory
            // 
            this.btnCancelCategory.Location = new System.Drawing.Point(242, 155);
            this.btnCancelCategory.Name = "btnCancelCategory";
            this.btnCancelCategory.Size = new System.Drawing.Size(75, 23);
            this.btnCancelCategory.TabIndex = 3;
            this.btnCancelCategory.Text = "Cancel";
            this.btnCancelCategory.UseVisualStyleBackColor = true;
            this.btnCancelCategory.Click += new System.EventHandler(this.btnCancelCategory_Click);
            // 
            // lblCategoryInput
            // 
            this.lblCategoryInput.AutoSize = true;
            this.lblCategoryInput.Location = new System.Drawing.Point(35, 50);
            this.lblCategoryInput.Name = "lblCategoryInput";
            this.lblCategoryInput.Size = new System.Drawing.Size(83, 13);
            this.lblCategoryInput.TabIndex = 4;
            this.lblCategoryInput.Text = "lblCategoryInput";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(35, 169);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "lblError";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 191);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblCategoryInput);
            this.Controls.Add(this.btnCancelCategory);
            this.Controls.Add(this.btnOkCategory);
            this.Controls.Add(this.txtItemCategory);
            this.Controls.Add(this.lblCategoryChoice);
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryChoice;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Button btnOkCategory;
        private System.Windows.Forms.Button btnCancelCategory;
        private System.Windows.Forms.Label lblCategoryInput;
        private System.Windows.Forms.Label lblError;
    }
}