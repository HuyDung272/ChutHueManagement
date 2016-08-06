namespace ChutHueManagement.ChutHueManagement
{
    partial class FormConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnection));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Refresh = new DevComponents.DotNetBar.ButtonX();
            this.btn_XoaDSMC = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Lưu = new DevComponents.DotNetBar.ButtonX();
            this.btn_testConnection = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txt_passserver = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txt_userserver = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rd_SqlServerAuthentication = new System.Windows.Forms.RadioButton();
            this.rd_WindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.cb_MayChu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rd_Internet = new System.Windows.Forms.RadioButton();
            this.rd_Lan = new System.Windows.Forms.RadioButton();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btn_Huy = new DevComponents.DotNetBar.ButtonX();
            this.btn_DangNhap = new DevComponents.DotNetBar.ButtonX();
            this.btn_ChiTietDangNhap = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_username = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btn_Refresh);
            this.groupBox2.Controls.Add(this.btn_Lưu);
            this.groupBox2.Controls.Add(this.btn_testConnection);
            this.groupBox2.Controls.Add(this.labelX7);
            this.groupBox2.Controls.Add(this.txt_passserver);
            this.groupBox2.Controls.Add(this.labelX8);
            this.groupBox2.Controls.Add(this.txt_userserver);
            this.groupBox2.Controls.Add(this.rd_SqlServerAuthentication);
            this.groupBox2.Controls.Add(this.rd_WindowsAuthentication);
            this.groupBox2.Controls.Add(this.cb_MayChu);
            this.groupBox2.Controls.Add(this.labelX6);
            this.groupBox2.Controls.Add(this.labelX5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.labelX4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 165);
            this.groupBox2.MinimumSize = new System.Drawing.Size(404, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 235);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Refresh.ImageFixedSize = new System.Drawing.Size(21, 21);
            this.btn_Refresh.Location = new System.Drawing.Point(308, 100);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(89, 23);
            this.btn_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Refresh.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_XoaDSMC});
            this.btn_Refresh.TabIndex = 8;
            this.btn_Refresh.Text = "Tìm kiếm";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_XoaDSMC
            // 
            this.btn_XoaDSMC.GlobalItem = false;
            this.btn_XoaDSMC.ImageFixedSize = new System.Drawing.Size(23, 23);
            this.btn_XoaDSMC.Name = "btn_XoaDSMC";
            this.btn_XoaDSMC.Text = "Xóa danh sách máy chủ";
            this.btn_XoaDSMC.Click += new System.EventHandler(this.btn_XoaDSMC_Click);
            // 
            // btn_Lưu
            // 
            this.btn_Lưu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Lưu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Lưu.Location = new System.Drawing.Point(308, 206);
            this.btn_Lưu.Name = "btn_Lưu";
            this.btn_Lưu.Size = new System.Drawing.Size(89, 23);
            this.btn_Lưu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Lưu.TabIndex = 14;
            this.btn_Lưu.Text = "Lưu";
            this.btn_Lưu.Click += new System.EventHandler(this.btn_Lưu_Click);
            // 
            // btn_testConnection
            // 
            this.btn_testConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_testConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_testConnection.Location = new System.Drawing.Point(308, 178);
            this.btn_testConnection.Name = "btn_testConnection";
            this.btn_testConnection.Size = new System.Drawing.Size(89, 23);
            this.btn_testConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_testConnection.TabIndex = 13;
            this.btn_testConnection.Text = "Test Connection";
            this.btn_testConnection.Click += new System.EventHandler(this.btn_testConnection_Click);
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(20, 175);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 5;
            this.labelX7.Text = "Tên đăng nhập";
            // 
            // txt_passserver
            // 
            this.txt_passserver.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_passserver.Border.Class = "TextBoxBorder";
            this.txt_passserver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_passserver.DisabledBackColor = System.Drawing.Color.White;
            this.txt_passserver.ForeColor = System.Drawing.Color.Black;
            this.txt_passserver.Location = new System.Drawing.Point(101, 206);
            this.txt_passserver.Name = "txt_passserver";
            this.txt_passserver.PasswordChar = '*';
            this.txt_passserver.Size = new System.Drawing.Size(196, 20);
            this.txt_passserver.TabIndex = 12;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(20, 203);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 6;
            this.labelX8.Text = "Mật khẩu";
            // 
            // txt_userserver
            // 
            this.txt_userserver.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_userserver.Border.Class = "TextBoxBorder";
            this.txt_userserver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_userserver.DisabledBackColor = System.Drawing.Color.White;
            this.txt_userserver.ForeColor = System.Drawing.Color.Black;
            this.txt_userserver.Location = new System.Drawing.Point(101, 178);
            this.txt_userserver.Name = "txt_userserver";
            this.txt_userserver.Size = new System.Drawing.Size(196, 20);
            this.txt_userserver.TabIndex = 11;
            // 
            // rd_SqlServerAuthentication
            // 
            this.rd_SqlServerAuthentication.AutoSize = true;
            this.rd_SqlServerAuthentication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rd_SqlServerAuthentication.Checked = true;
            this.rd_SqlServerAuthentication.ForeColor = System.Drawing.Color.Black;
            this.rd_SqlServerAuthentication.Location = new System.Drawing.Point(105, 152);
            this.rd_SqlServerAuthentication.Name = "rd_SqlServerAuthentication";
            this.rd_SqlServerAuthentication.Size = new System.Drawing.Size(151, 17);
            this.rd_SqlServerAuthentication.TabIndex = 10;
            this.rd_SqlServerAuthentication.TabStop = true;
            this.rd_SqlServerAuthentication.Text = "SQL Server Authentication";
            this.rd_SqlServerAuthentication.UseVisualStyleBackColor = false;
            this.rd_SqlServerAuthentication.CheckedChanged += new System.EventHandler(this.rd_SqlServerAuthentication_CheckedChanged);
            // 
            // rd_WindowsAuthentication
            // 
            this.rd_WindowsAuthentication.AutoSize = true;
            this.rd_WindowsAuthentication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rd_WindowsAuthentication.ForeColor = System.Drawing.Color.Black;
            this.rd_WindowsAuthentication.Location = new System.Drawing.Point(105, 129);
            this.rd_WindowsAuthentication.Name = "rd_WindowsAuthentication";
            this.rd_WindowsAuthentication.Size = new System.Drawing.Size(140, 17);
            this.rd_WindowsAuthentication.TabIndex = 9;
            this.rd_WindowsAuthentication.Text = "Windows Authentication";
            this.rd_WindowsAuthentication.UseVisualStyleBackColor = false;
            this.rd_WindowsAuthentication.CheckedChanged += new System.EventHandler(this.rd_WindowsAuthentication_CheckedChanged);
            // 
            // cb_MayChu
            // 
            this.cb_MayChu.DisplayMember = "Text";
            this.cb_MayChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_MayChu.ForeColor = System.Drawing.Color.Black;
            this.cb_MayChu.FormattingEnabled = true;
            this.cb_MayChu.ItemHeight = 14;
            this.cb_MayChu.Location = new System.Drawing.Point(105, 102);
            this.cb_MayChu.Name = "cb_MayChu";
            this.cb_MayChu.Size = new System.Drawing.Size(192, 20);
            this.cb_MayChu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_MayChu.TabIndex = 7;
            this.cb_MayChu.SelectedIndexChanged += new System.EventHandler(this.cb_MayChu_SelectedIndexChanged);
            this.cb_MayChu.TextChanged += new System.EventHandler(this.cb_MayChu_TextChanged);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(23, 136);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "Kiểu xác thực";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(23, 100);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "Máy chủ SQL";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.rd_Internet);
            this.groupBox3.Controls.Add(this.rd_Lan);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(3, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 47);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kiểu kết nối";
            // 
            // rd_Internet
            // 
            this.rd_Internet.AutoSize = true;
            this.rd_Internet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rd_Internet.ForeColor = System.Drawing.Color.Black;
            this.rd_Internet.Location = new System.Drawing.Point(242, 18);
            this.rd_Internet.Name = "rd_Internet";
            this.rd_Internet.Size = new System.Drawing.Size(91, 17);
            this.rd_Internet.TabIndex = 6;
            this.rd_Internet.Text = "Mạng Internet";
            this.rd_Internet.UseVisualStyleBackColor = false;
            this.rd_Internet.CheckedChanged += new System.EventHandler(this.rd_Internet_CheckedChanged);
            // 
            // rd_Lan
            // 
            this.rd_Lan.AutoSize = true;
            this.rd_Lan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rd_Lan.Checked = true;
            this.rd_Lan.ForeColor = System.Drawing.Color.Black;
            this.rd_Lan.Location = new System.Drawing.Point(57, 19);
            this.rd_Lan.Name = "rd_Lan";
            this.rd_Lan.Size = new System.Drawing.Size(73, 17);
            this.rd_Lan.TabIndex = 5;
            this.rd_Lan.TabStop = true;
            this.rd_Lan.Text = "Mạng Lan";
            this.rd_Lan.UseVisualStyleBackColor = false;
            this.rd_Lan.CheckedChanged += new System.EventHandler(this.rd_Lan_CheckedChanged);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(3, 16);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(398, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "THÔNG TIN KẾT NỐI MÁY CHỦ SQL SERVER";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.labelX9);
            this.groupBox1.Controls.Add(this.btn_Huy);
            this.groupBox1.Controls.Add(this.btn_DangNhap);
            this.groupBox1.Controls.Add(this.btn_ChiTietDangNhap);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.txt_username);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.MaximumSize = new System.Drawing.Size(404, 95);
            this.groupBox1.MinimumSize = new System.Drawing.Size(404, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelX9.BackgroundImage = global::ChutHueManagement.ChutHueManagement.Properties.Resources._1370933891_preferences_desktop_cryptography;
            this.labelX9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.ForeColor = System.Drawing.Color.Black;
            this.labelX9.Location = new System.Drawing.Point(33, 16);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(52, 44);
            this.labelX9.TabIndex = 5;
            // 
            // btn_Huy
            // 
            this.btn_Huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Huy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Huy.Location = new System.Drawing.Point(207, 66);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(73, 23);
            this.btn_Huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Huy.TabIndex = 3;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_DangNhap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_DangNhap.Location = new System.Drawing.Point(303, 66);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(73, 23);
            this.btn_DangNhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_DangNhap.TabIndex = 2;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_ChiTietDangNhap
            // 
            this.btn_ChiTietDangNhap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ChiTietDangNhap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ChiTietDangNhap.Location = new System.Drawing.Point(5, 66);
            this.btn_ChiTietDangNhap.Name = "btn_ChiTietDangNhap";
            this.btn_ChiTietDangNhap.Size = new System.Drawing.Size(115, 23);
            this.btn_ChiTietDangNhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ChiTietDangNhap.TabIndex = 4;
            this.btn_ChiTietDangNhap.Text = "Chi tiết đăng nhập";
            this.btn_ChiTietDangNhap.Click += new System.EventHandler(this.btn_ChiTietDangNhap_Click);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(126, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Tên đăng nhập";
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_password.Border.Class = "TextBoxBorder";
            this.txt_password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_password.DisabledBackColor = System.Drawing.Color.White;
            this.txt_password.ForeColor = System.Drawing.Color.Black;
            this.txt_password.Location = new System.Drawing.Point(207, 44);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(169, 20);
            this.txt_password.TabIndex = 1;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(126, 45);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Mật khẩu";
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_username.Border.Class = "TextBoxBorder";
            this.txt_username.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_username.DisabledBackColor = System.Drawing.Color.White;
            this.txt_username.ForeColor = System.Drawing.Color.Black;
            this.txt_username.Location = new System.Drawing.Point(207, 18);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(169, 20);
            this.txt_username.TabIndex = 0;
            // 
            // buttonItem1
            // 
            this.buttonItem1.GlobalItem = false;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.connect;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(404, 70);
            this.labelX1.TabIndex = 0;
            // 
            // FormConnection
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Huy;
            this.ClientSize = new System.Drawing.Size(404, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 160);
            this.Name = "FormConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormConnectioncs_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_username;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_password;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btn_ChiTietDangNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rd_Internet;
        private System.Windows.Forms.RadioButton rd_Lan;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_MayChu;
        private System.Windows.Forms.RadioButton rd_SqlServerAuthentication;
        private System.Windows.Forms.RadioButton rd_WindowsAuthentication;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_passserver;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_userserver;
        private DevComponents.DotNetBar.ButtonX btn_testConnection;
        private DevComponents.DotNetBar.ButtonX btn_Refresh;
        private DevComponents.DotNetBar.ButtonX btn_DangNhap;
        private DevComponents.DotNetBar.ButtonX btn_Huy;
        private DevComponents.DotNetBar.ButtonX btn_Lưu;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem btn_XoaDSMC;

    }
}