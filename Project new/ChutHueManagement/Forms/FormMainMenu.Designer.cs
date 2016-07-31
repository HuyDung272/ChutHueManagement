namespace ChutHueManagement.ChutHueManagement
{
    partial class FormMainMenu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtn_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_UpDate = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewLoad = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStrip1.ForeColor = System.Drawing.Color.Black;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtn_Add,
            this.toolStripBtn_Delete,
            this.toolStripBtn_UpDate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1584, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtn_Add
            // 
            this.toolStripBtn_Add.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.add;
            this.toolStripBtn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripBtn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Add.Name = "toolStripBtn_Add";
            this.toolStripBtn_Add.Size = new System.Drawing.Size(58, 22);
            this.toolStripBtn_Add.Text = "Thêm";
            this.toolStripBtn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtn_Add.Click += new System.EventHandler(this.toolStripBtn_Add_Click);
            // 
            // toolStripBtn_Delete
            // 
            this.toolStripBtn_Delete.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.Delete;
            this.toolStripBtn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Delete.Name = "toolStripBtn_Delete";
            this.toolStripBtn_Delete.Size = new System.Drawing.Size(47, 22);
            this.toolStripBtn_Delete.Text = "Xóa";
            this.toolStripBtn_Delete.Click += new System.EventHandler(this.toolStripBtn_Delete_Click);
            // 
            // toolStripBtn_UpDate
            // 
            this.toolStripBtn_UpDate.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.Update;
            this.toolStripBtn_UpDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_UpDate.Name = "toolStripBtn_UpDate";
            this.toolStripBtn_UpDate.Size = new System.Drawing.Size(75, 22);
            this.toolStripBtn_UpDate.Text = "Cập nhật";
            this.toolStripBtn_UpDate.Click += new System.EventHandler(this.toolStripBtn_UpDate_Click);
            // 
            // dataGridViewLoad
            // 
            this.dataGridViewLoad.AllowUserToAddRows = false;
            this.dataGridViewLoad.AllowUserToDeleteRows = false;
            this.dataGridViewLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoad.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLoad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoad.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLoad.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLoad.EnableHeadersVisualStyles = false;
            this.dataGridViewLoad.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewLoad.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewLoad.MultiSelect = false;
            this.dataGridViewLoad.Name = "dataGridViewLoad";
            this.dataGridViewLoad.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLoad.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLoad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLoad.Size = new System.Drawing.Size(1584, 636);
            this.dataGridViewLoad.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.sửaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 70);
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.thêmToolStripMenuItem.Text = "Thêm";
            this.thêmToolStripMenuItem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.sửaToolStripMenuItem.Text = "Cập nhật";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 661);
            this.Controls.Add(this.dataGridViewLoad);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMainMenu";
            this.Text = "Loại thực đơn";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewLoad;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Add;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Delete;
        private System.Windows.Forms.ToolStripButton toolStripBtn_UpDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
    }
}