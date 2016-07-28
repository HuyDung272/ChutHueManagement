namespace ChutHueManagement.Forms
{
    partial class FormMainMenu_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu_Add));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_NameMainMenu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Description = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btn_Add = new DevComponents.DotNetBar.ButtonX();
            this.btn_Clear = new DevComponents.DotNetBar.ButtonX();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonX();
            this.lblUpdate = new DevComponents.DotNetBar.LabelX();
            this.radioBtn_IsDelete = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(12, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Loại thực đơn";
            // 
            // txt_NameMainMenu
            // 
            this.txt_NameMainMenu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_NameMainMenu.Border.Class = "TextBoxBorder";
            this.txt_NameMainMenu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_NameMainMenu.DisabledBackColor = System.Drawing.Color.White;
            this.txt_NameMainMenu.ForeColor = System.Drawing.Color.Black;
            this.txt_NameMainMenu.Location = new System.Drawing.Point(105, 30);
            this.txt_NameMainMenu.Name = "txt_NameMainMenu";
            this.txt_NameMainMenu.PreventEnterBeep = true;
            this.txt_NameMainMenu.Size = new System.Drawing.Size(173, 20);
            this.txt_NameMainMenu.TabIndex = 1;
            // 
            // txt_Description
            // 
            this.txt_Description.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_Description.Border.Class = "TextBoxBorder";
            this.txt_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Description.DisabledBackColor = System.Drawing.Color.White;
            this.txt_Description.ForeColor = System.Drawing.Color.Black;
            this.txt_Description.Location = new System.Drawing.Point(105, 57);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.PreventEnterBeep = true;
            this.txt_Description.Size = new System.Drawing.Size(173, 85);
            this.txt_Description.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(12, 54);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Mô tả";
            // 
            // btn_Add
            // 
            this.btn_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Add.Location = new System.Drawing.Point(7, 189);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Clear.Location = new System.Drawing.Point(105, 189);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "Xóa trắng";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(203, 188);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lblUpdate
            // 
            this.lblUpdate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.Black;
            this.lblUpdate.Location = new System.Drawing.Point(7, 3);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(274, 23);
            this.lblUpdate.TabIndex = 0;
            this.lblUpdate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // radioBtn_IsDelete
            // 
            this.radioBtn_IsDelete.AutoSize = true;
            this.radioBtn_IsDelete.BackColor = System.Drawing.Color.White;
            this.radioBtn_IsDelete.ForeColor = System.Drawing.Color.Black;
            this.radioBtn_IsDelete.Location = new System.Drawing.Point(7, 157);
            this.radioBtn_IsDelete.Name = "radioBtn_IsDelete";
            this.radioBtn_IsDelete.Size = new System.Drawing.Size(106, 17);
            this.radioBtn_IsDelete.TabIndex = 7;
            this.radioBtn_IsDelete.TabStop = true;
            this.radioBtn_IsDelete.Text = "Tình trạng (khóa)";
            this.radioBtn_IsDelete.UseVisualStyleBackColor = false;
            // 
            // FormMainMenu_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 224);
            this.Controls.Add(this.radioBtn_IsDelete);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txt_NameMainMenu);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(309, 241);
            this.Name = "FormMainMenu_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMainMenu_Add";
            this.Load += new System.EventHandler(this.FormMainMenu_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NameMainMenu;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Description;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btn_Add;
        private DevComponents.DotNetBar.ButtonX btn_Clear;
        private DevComponents.DotNetBar.ButtonX btn_Exit;
        private DevComponents.DotNetBar.LabelX lblUpdate;
        private System.Windows.Forms.RadioButton radioBtn_IsDelete;
    }
}