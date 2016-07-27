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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_NameMainMenu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Description = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btn_Add = new DevComponents.DotNetBar.ButtonX();
            this.btn_Clear = new DevComponents.DotNetBar.ButtonX();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
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
            this.txt_NameMainMenu.Location = new System.Drawing.Point(105, 15);
            this.txt_NameMainMenu.Name = "txt_NameMainMenu";
            this.txt_NameMainMenu.PreventEnterBeep = true;
            this.txt_NameMainMenu.Size = new System.Drawing.Size(176, 20);
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
            this.txt_Description.Location = new System.Drawing.Point(105, 44);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.PreventEnterBeep = true;
            this.txt_Description.Size = new System.Drawing.Size(176, 109);
            this.txt_Description.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Mô tả";
            // 
            // btn_Add
            // 
            this.btn_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Add.Location = new System.Drawing.Point(7, 168);
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
            this.btn_Clear.Location = new System.Drawing.Point(105, 168);
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
            this.btn_Exit.Location = new System.Drawing.Point(203, 167);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // FormMainMenu_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 202);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txt_NameMainMenu);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(309, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(309, 241);
            this.Name = "FormMainMenu_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMainMenu_Add";
            this.Load += new System.EventHandler(this.FormMainMenu_Add_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NameMainMenu;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Description;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btn_Add;
        private DevComponents.DotNetBar.ButtonX btn_Clear;
        private DevComponents.DotNetBar.ButtonX btn_Exit;
    }
}