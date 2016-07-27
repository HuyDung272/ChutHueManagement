namespace ChutHueManagement.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtn_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_UpDate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.dataGridViewLoad = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtn_Add,
            this.toolStripBtn_Delete,
            this.toolStripBtn_UpDate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(902, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtn_Add
            // 
            this.toolStripBtn_Add.Image = global::ChutHueManagement.ChutHueManagement.Properties.Resources.info;
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
            this.toolStripBtn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Delete.Image")));
            this.toolStripBtn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Delete.Name = "toolStripBtn_Delete";
            this.toolStripBtn_Delete.Size = new System.Drawing.Size(47, 22);
            this.toolStripBtn_Delete.Text = "Xóa";
            // 
            // toolStripBtn_UpDate
            // 
            this.toolStripBtn_UpDate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_UpDate.Image")));
            this.toolStripBtn_UpDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_UpDate.Name = "toolStripBtn_UpDate";
            this.toolStripBtn_UpDate.Size = new System.Drawing.Size(46, 22);
            this.toolStripBtn_UpDate.Text = "Sửa";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(902, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // dataGridViewLoad
            // 
            this.dataGridViewLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoad.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLoad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLoad.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLoad.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dataGridViewLoad.Location = new System.Drawing.Point(0, 50);
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
            this.dataGridViewLoad.Size = new System.Drawing.Size(902, 445);
            this.dataGridViewLoad.TabIndex = 1;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 495);
            this.Controls.Add(this.dataGridViewLoad);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMainMenu";
            this.Text = "`";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewLoad;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Add;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Delete;
        private System.Windows.Forms.ToolStripButton toolStripBtn_UpDate;
    }
}