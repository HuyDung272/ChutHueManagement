namespace ChutHueManagement.ChutHueManagement
{
    partial class AddEditInvoiceDetail
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtsoLuong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbbMon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtThanhTien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(63, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Chọn món";
            // 
            // txtsoLuong
            // 
            this.txtsoLuong.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtsoLuong.Border.Class = "TextBoxBorder";
            this.txtsoLuong.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsoLuong.DisabledBackColor = System.Drawing.Color.White;
            this.txtsoLuong.ForeColor = System.Drawing.Color.Black;
            this.txtsoLuong.Location = new System.Drawing.Point(81, 49);
            this.txtsoLuong.Name = "txtsoLuong";
            this.txtsoLuong.PreventEnterBeep = true;
            this.txtsoLuong.Size = new System.Drawing.Size(205, 22);
            this.txtsoLuong.TabIndex = 1;
            this.txtsoLuong.TextChanged += new System.EventHandler(this.txtsoLuong_TextChanged);
            this.txtsoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsoLuong_KeyPress);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 50);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Số lượng";
            // 
            // cbbMon
            // 
            this.cbbMon.DisplayMember = "Text";
            this.cbbMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMon.ForeColor = System.Drawing.Color.Black;
            this.cbbMon.FormattingEnabled = true;
            this.cbbMon.ItemHeight = 17;
            this.cbbMon.Location = new System.Drawing.Point(81, 21);
            this.cbbMon.Name = "cbbMon";
            this.cbbMon.Size = new System.Drawing.Size(205, 23);
            this.cbbMon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbMon.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(12, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 38);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "buttonX1";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(181, 111);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 38);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "buttonX1";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(12, 79);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(63, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Thành Tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtThanhTien.Border.Class = "TextBoxBorder";
            this.txtThanhTien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtThanhTien.DisabledBackColor = System.Drawing.Color.White;
            this.txtThanhTien.ForeColor = System.Drawing.Color.Black;
            this.txtThanhTien.Location = new System.Drawing.Point(81, 78);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.PreventEnterBeep = true;
            this.txtThanhTien.Size = new System.Drawing.Size(205, 22);
            this.txtThanhTien.TabIndex = 2;
            // 
            // AddEditInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 161);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbbMon);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.txtsoLuong);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddEditInvoiceDetail";
            this.Text = "Sửa Thông Tin Món";
            this.Load += new System.EventHandler(this.AddEditInvoiceDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsoLuong;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbMon;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtThanhTien;
    }
}