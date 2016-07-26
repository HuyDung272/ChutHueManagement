namespace ChutHueManagement.Forms
{
    partial class FormInfo
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
            this.lb_NameRestaurant = new DevComponents.DotNetBar.LabelX();
            this.txtNameRestaurant = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lb_NameRestaurant
            // 
            // 
            // 
            // 
            this.lb_NameRestaurant.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_NameRestaurant.Location = new System.Drawing.Point(12, 9);
            this.lb_NameRestaurant.Name = "lb_NameRestaurant";
            this.lb_NameRestaurant.Size = new System.Drawing.Size(94, 23);
            this.lb_NameRestaurant.TabIndex = 1;
            this.lb_NameRestaurant.Text = "Tên quán ăn";
            // 
            // txtNameRestaurant
            // 
            this.txtNameRestaurant.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNameRestaurant.Border.Class = "TextBoxBorder";
            this.txtNameRestaurant.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNameRestaurant.DisabledBackColor = System.Drawing.Color.White;
            this.txtNameRestaurant.ForeColor = System.Drawing.Color.Black;
            this.txtNameRestaurant.Location = new System.Drawing.Point(112, 12);
            this.txtNameRestaurant.Name = "txtNameRestaurant";
            this.txtNameRestaurant.PreventEnterBeep = true;
            this.txtNameRestaurant.Size = new System.Drawing.Size(583, 20);
            this.txtNameRestaurant.TabIndex = 2;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(707, 419);
            this.Controls.Add(this.txtNameRestaurant);
            this.Controls.Add(this.lb_NameRestaurant);
            this.Name = "FormInfo";
            this.Text = "Thông tin quán ăn";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lb_NameRestaurant;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameRestaurant;
    }
}