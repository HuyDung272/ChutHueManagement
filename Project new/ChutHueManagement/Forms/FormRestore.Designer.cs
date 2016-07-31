namespace ChutHueManagement.ChutHueManagement
{
    partial class FormRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRestore));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbox_BackupRestore = new System.Windows.Forms.ToolStripComboBox();
            this.btn_Restore = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewLoad = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStrip1.ForeColor = System.Drawing.Color.Black;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbox_BackupRestore,
            this.btn_Restore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1584, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbox_BackupRestore
            // 
            this.cbox_BackupRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbox_BackupRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_BackupRestore.ForeColor = System.Drawing.Color.Black;
            this.cbox_BackupRestore.Name = "cbox_BackupRestore";
            this.cbox_BackupRestore.Size = new System.Drawing.Size(121, 25);
            this.cbox_BackupRestore.SelectedIndexChanged += new System.EventHandler(this.cbox_BackupRestore_SelectedIndexChanged);
            // 
            // btn_Restore
            // 
            this.btn_Restore.Image = ((System.Drawing.Image)(resources.GetObject("btn_Restore.Image")));
            this.btn_Restore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Restore.Name = "btn_Restore";
            this.btn_Restore.Size = new System.Drawing.Size(120, 22);
            this.btn_Restore.Text = "Khôi phục dữ liệu";
            this.btn_Restore.Click += new System.EventHandler(this.btn_Restore_Click);
            // 
            // dataGridViewLoad
            // 
            this.dataGridViewLoad.AllowUserToAddRows = false;
            this.dataGridViewLoad.AllowUserToDeleteRows = false;
            this.dataGridViewLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLoad.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLoad.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewLoad.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewLoad.MultiSelect = false;
            this.dataGridViewLoad.Name = "dataGridViewLoad";
            this.dataGridViewLoad.ReadOnly = true;
            this.dataGridViewLoad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLoad.Size = new System.Drawing.Size(1584, 636);
            this.dataGridViewLoad.TabIndex = 1;
            // 
            // FormRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 661);
            this.Controls.Add(this.dataGridViewLoad);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRestore";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.FormRestore_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbox_BackupRestore;
        private System.Windows.Forms.ToolStripButton btn_Restore;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewLoad;
    }
}