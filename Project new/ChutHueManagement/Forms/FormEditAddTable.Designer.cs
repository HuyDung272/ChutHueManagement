namespace ChutHueManagement.ChutHueManagement
{
    partial class FormEditAddTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditAddTable));
            this.txtNamNew = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtNameOld = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtNamNew
            // 
            this.txtNamNew.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNamNew.Border.Class = "TextBoxBorder";
            this.txtNamNew.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNamNew.DisabledBackColor = System.Drawing.Color.White;
            this.txtNamNew.ForeColor = System.Drawing.Color.Black;
            this.txtNamNew.Location = new System.Drawing.Point(80, 76);
            this.txtNamNew.Name = "txtNamNew";
            this.txtNamNew.PreventEnterBeep = true;
            this.txtNamNew.Size = new System.Drawing.Size(225, 22);
            this.txtNamNew.TabIndex = 0;
            this.txtNamNew.WatermarkText = "Nhập Tên Mới";
            this.txtNamNew.TextChanged += new System.EventHandler(this.txtNamNew_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Mới";
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTieuDe.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.Black;
            this.lbTieuDe.Location = new System.Drawing.Point(109, 5);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(85, 31);
            this.lbTieuDe.TabIndex = 1;
            this.lbTieuDe.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Cũ";
            // 
            // txtNameOld
            // 
            this.txtNameOld.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNameOld.Border.Class = "TextBoxBorder";
            this.txtNameOld.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNameOld.DisabledBackColor = System.Drawing.Color.White;
            this.txtNameOld.Enabled = false;
            this.txtNameOld.ForeColor = System.Drawing.Color.Black;
            this.txtNameOld.Location = new System.Drawing.Point(80, 43);
            this.txtNameOld.Name = "txtNameOld";
            this.txtNameOld.PreventEnterBeep = true;
            this.txtNameOld.Size = new System.Drawing.Size(225, 22);
            this.txtNameOld.TabIndex = 0;
            this.txtNameOld.WatermarkText = "Tên Cũ";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.Delete;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(178, 118);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 35);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.check;
            this.btnOK.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btnOK.Location = new System.Drawing.Point(15, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(127, 35);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Thêm";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormEditAddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 164);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbTieuDe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameOld);
            this.Controls.Add(this.txtNamNew);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(333, 203);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(333, 203);
            this.Name = "FormEditAddTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.FormEditAddTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNamNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameOld;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}