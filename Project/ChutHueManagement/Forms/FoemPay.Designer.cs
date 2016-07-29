namespace ChutHueManagement.ChutHueManagement
{
    partial class FoemPay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.grvChiTiet = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtTongTien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTienKhachDua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTienThua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbSoBan = new DevComponents.DotNetBar.LabelX();
            this.lbTGD = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(100, 1);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(199, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Chi Tiết Hóa Đơn";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(12, 25);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Số Bàn :";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(153, 26);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(86, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Thời Gian Đến :";
            // 
            // grvChiTiet
            // 
            this.grvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodName,
            this.Total,
            this.PriceTotal});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvChiTiet.DefaultCellStyle = dataGridViewCellStyle8;
            this.grvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grvChiTiet.Location = new System.Drawing.Point(10, 159);
            this.grvChiTiet.Name = "grvChiTiet";
            this.grvChiTiet.RowHeadersVisible = false;
            this.grvChiTiet.Size = new System.Drawing.Size(427, 384);
            this.grvChiTiet.TabIndex = 1;
            // 
            // FoodName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.FoodName.DefaultCellStyle = dataGridViewCellStyle5;
            this.FoodName.HeaderText = "Tên Món";
            this.FoodName.Name = "FoodName";
            this.FoodName.Width = 200;
            // 
            // Total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Số Lượng";
            this.Total.Name = "Total";
            this.Total.Width = 65;
            // 
            // PriceTotal
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.PriceTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.PriceTotal.HeaderText = "Thành Tiền";
            this.PriceTotal.Name = "PriceTotal";
            this.PriceTotal.Width = 157;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(12, 59);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Tổng tiền";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(12, 549);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(184, 61);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "In Hóa Đơn";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(242, 549);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(197, 61);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "Thanh Toán";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(12, 88);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(98, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Tiền khách đưa";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(12, 117);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Tiền Thừa";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(124, 59);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(13, 23);
            this.labelX7.TabIndex = 3;
            this.labelX7.Text = ":";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(124, 88);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(13, 23);
            this.labelX8.TabIndex = 3;
            this.labelX8.Text = ":";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.Location = new System.Drawing.Point(124, 117);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(13, 23);
            this.labelX9.TabIndex = 3;
            this.labelX9.Text = ":";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(12, 137);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(98, 23);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "Chi tiết hóa đơn :";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTongTien.Border.Class = "TextBoxBorder";
            this.txtTongTien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTongTien.DisabledBackColor = System.Drawing.Color.White;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Black;
            this.txtTongTien.Location = new System.Drawing.Point(153, 57);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PreventEnterBeep = true;
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(284, 25);
            this.txtTongTien.TabIndex = 4;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTienKhachDua.Border.Class = "TextBoxBorder";
            this.txtTienKhachDua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTienKhachDua.DisabledBackColor = System.Drawing.Color.White;
            this.txtTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachDua.ForeColor = System.Drawing.Color.Black;
            this.txtTienKhachDua.Location = new System.Drawing.Point(153, 86);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.PreventEnterBeep = true;
            this.txtTienKhachDua.Size = new System.Drawing.Size(284, 25);
            this.txtTienKhachDua.TabIndex = 4;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // txtTienThua
            // 
            this.txtTienThua.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTienThua.Border.Class = "TextBoxBorder";
            this.txtTienThua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTienThua.DisabledBackColor = System.Drawing.Color.White;
            this.txtTienThua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienThua.ForeColor = System.Drawing.Color.Black;
            this.txtTienThua.Location = new System.Drawing.Point(153, 115);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.PreventEnterBeep = true;
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new System.Drawing.Size(284, 25);
            this.txtTienThua.TabIndex = 4;
            // 
            // lbSoBan
            // 
            this.lbSoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbSoBan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSoBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoBan.ForeColor = System.Drawing.Color.Black;
            this.lbSoBan.Location = new System.Drawing.Point(89, 25);
            this.lbSoBan.Name = "lbSoBan";
            this.lbSoBan.Size = new System.Drawing.Size(48, 23);
            this.lbSoBan.TabIndex = 0;
            this.lbSoBan.Text = "0";
            // 
            // lbTGD
            // 
            this.lbTGD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTGD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTGD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTGD.ForeColor = System.Drawing.Color.Black;
            this.lbTGD.Location = new System.Drawing.Point(242, 26);
            this.lbTGD.Name = "lbTGD";
            this.lbTGD.Size = new System.Drawing.Size(195, 23);
            this.lbTGD.TabIndex = 0;
            this.lbTGD.Text = "dd/mm/yyyy";
            // 
            // FoemPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 622);
            this.Controls.Add(this.txtTienThua);
            this.Controls.Add(this.txtTienKhachDua);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.grvChiTiet);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.lbTGD);
            this.Controls.Add(this.lbSoBan);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 661);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 661);
            this.Name = "FoemPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán Hóa Đơn";
            this.Load += new System.EventHandler(this.FoemPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX grvChiTiet;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTongTien;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTienKhachDua;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTienThua;
        private DevComponents.DotNetBar.LabelX lbSoBan;
        private DevComponents.DotNetBar.LabelX lbTGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceTotal;
    }
}