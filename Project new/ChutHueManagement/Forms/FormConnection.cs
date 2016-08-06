using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.Utilities;
using System.Threading;
using System.Configuration;

using System.Security.Cryptography;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormConnection : DevComponents.DotNetBar.Metro.MetroForm
    {
        readonly string db = "Initial Catalog=ChutHueManagement;";

        readonly string db1 = "database=ChutHueManagement;";

        bool dong;

        int heigh;

        private string Text = string.Empty;

        List<string> listserver = new List<string>();

        string author = "";

        string server = "";

        /// <summary>
        /// lưu thông tin của người đăng nhập
        /// </summary>
        public AccountEntity account = new AccountEntity();

        //public TaiKhoanEntity TaiKhoan;

        public FormConnection()
        {
            InitializeComponent();
        }

        
        

        private void FormConnectioncs_Load(object sender, EventArgs e)
        {
            dong = true;
            heigh = groupBox2.Height;
            this.Size = new Size(this.Size.Width, this.Height - heigh);
            groupBox2.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChiTietDangNhap_Click(object sender, EventArgs e)
        {
            if (dong)
            {
                this.Size = new Size(this.Size.Width, this.Height + heigh);
                dong = !dong;
                rd_Lan.Checked = true;
                btn_Lưu.Enabled = false;
                btn_testConnection.Enabled = true;
                groupBox2.Enabled = true;
                
            }
            else
            {
                groupBox2.Enabled = false;
                this.Size = new Size(this.Size.Width, this.Height - heigh);
                dong = !dong;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void GetServerMangLan()
        {
            RemoveItemcb();
            //Thread t = new Thread(() => (new Splash.Splash1("Đang tìm kiếm server")).ShowDialog());
            //t.Start();
            
            listserver = this.ConvertToList(SqlLocator.GetServers());

            //DataTable data = new DataTable();
            //data.Columns.Add("NameServer", typeof(string));
            //List<DataRow> rows = new List<DataRow>();

            //for (int i = 0; i < listserver.Length; i++)
            //{
            //    DataRow row = data.NewRow();
            //    row["NameServer"] = listserver[i].ToString();
            //    data.Rows.Add(row);
            //}
            //cb_MayChu.DataSource = data;
            SetItemcdLan();
            //cb_MayChu.DisplayMember = "NameServer";
            //cb_MayChu.ValueMember = "NameServer";

            cb_MayChu.SelectedIndex = 0;
            //t.Abort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string connect = Configurations.Configs.ConnectionString;
            SqlConnection conn = new SqlConnection(connect);
            if (IsInput())
            {
                try
                {
                    conn.Open();
                    if (CheckLogin())
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể kết nối tới SQL Server");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

       

        /// <summary>
        /// kiểm tra thông tin đăng nhập
        /// </summary>
        /// <returns></returns>
        private bool CheckLogin()
        {
            if (IsInput())
            {
                string encodepass = DataUtil.HashPassword(DataUtil.HashPassword(txt_password.Text));
                var nv = AccountManager.LogIn(txt_username.Text, encodepass, ref Text);
                try
                {
                    account = AccountManager.ConvertToList(nv)[0];
                }
                catch (Exception)
                {
                    MessageBox.Show(Text);
                    return false;
                }
                //TaiKhoan = TaiKhoanManager.ConvertToList(TaiKhoanManager.Find_UserName(txt_username.Text))[0];
                return true;
            }
            return false;
        }

        /// <summary>
        /// kiểm tra thông tin nhập vao của người dùng
        /// </summary>
        /// <returns></returns>
        private bool IsInput()
        {
            if (StringHelper.IsNullorEmpty(txt_username.Text))
            {
                MessageBox.Show("Tài khoản không được để trống !");
                return false;
            }
            if (StringHelper.IsNullorEmpty(txt_password.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống !");
                return false;
            }
            return true;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetServerMangLan();
        }

        void RemoveItemcb()
        {
            int dem = cb_MayChu.Items.Count;
            for (int i = 0; i < dem; i++)
            {
                cb_MayChu.Items.RemoveAt(0);
            }
        }

        string connect = "";

        private void btn_testConnection_Click(object sender, EventArgs e)
        {
            string temp = server;
            stringservername(ref temp);

            if (rd_WindowsAuthentication.Checked)
            {
                connect = temp + ";" + db + author;
            }
            else
            {
                connect = temp + ";" + db1 + GetInfo();
            }
            //Thread t = new Thread(() => (new Splash.Splash1("Kiểm tra kết nối")).ShowDialog());
            //t.Start();

            if (Connection(connect))
            {
                //t.Abort();
                MessageBox.Show("Connection thành công");
                btn_Lưu.Enabled = true;
            }
            else
            {
                //t.Abort();
                MessageBox.Show("Không thể kết nối tới SQL Server");
                btn_Lưu.Enabled = false;
            }
        }

        private void cb_MayChu_SelectedIndexChanged(object sender, EventArgs e)
        {
            server = "Data Source=" + cb_MayChu.SelectedItem as string;
        }

        private void rd_WindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl(false);
            author = "Integrated Security=True;";
        }

        void DisableControl(bool dk)
        {
            txt_userserver.Enabled = dk;
            txt_passserver.Enabled = dk;
        }

        private void rd_SqlServerAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl(true);
            author = "Persist Security Info=True;";
        }

        private void rd_Internet_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Internet.Checked)
            {
                RemoveItemcb();
                cb_MayChu.Items.Add("");
                rd_SqlServerAuthentication.Checked = true;
                rd_WindowsAuthentication.Enabled = false;
                btn_Refresh.Enabled = false;
                cb_MayChu.SelectedIndex = 0;
                cb_MayChu.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void SetItemcdLan()
        {
            for (int i = 0; i < listserver.Count; i++)
            {
                cb_MayChu.Items.Add(listserver[i]);
            }
            if (cb_MayChu.Items.Count != 0)
            {
                cb_MayChu.SelectedIndex = 0;
            }
        }

        private void rd_Lan_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Lan.Checked)
            {
                RemoveItemcb();
                SetItemcdLan();
                rd_WindowsAuthentication.Enabled = true;
                cb_MayChu.DropDownStyle = ComboBoxStyle.DropDownList;
                btn_Refresh.Enabled = true;
            }
        }

        bool Connection(string strinconnection)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strinconnection);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        string GetInfo()
        {
            return "uid=" + txt_userserver.Text + ";pwd=" + txt_passserver.Text;
        }

        void stringservername(ref string server)
        {
            if (server.IndexOf('\\') == -1)
            {
                    server = server + @",1433";
            }
            else
            {
                string[] temp = server.Split('\\');
                if (rd_Internet.Checked)
                {
                    server = temp[0] + @",1433\" + temp[1];
                }
                else
                    server = temp[0] + @"\" + temp[1];
            }
        }

        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
            configSection.ConnectionStrings[key].ConnectionString = value;
            configuration.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("connectionStrings");
            //File.Copy("CuaHangMayTinh.PresentationLayer.exe.config", "..\\..\\App.Config", true);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Lưu_Click(object sender, EventArgs e)
        {
            if (Connection(connect))
            {
                UpdateSetting("DbPassport", connect);
                //UpdateSetting("LocalSqlServer", connect);
                MessageBox.Show("Connection thành công");
                btn_Lưu.Enabled = false;
            }
            else
            {
                MessageBox.Show("Không thể kết nối thành công");
            }
        }

        private void cb_MayChu_TextChanged(object sender, EventArgs e)
        {
            server = "Data Source=" + cb_MayChu.Text;
        }

        private List<string> ConvertToList(string[] list)
        {
            List<string> kq = new List<string>();
            for (int i = 0; i < list.Length; i++)
            {
                kq.Add(list[i]);
            }
            return kq;
        }

        private void btn_XoaDSMC_Click(object sender, EventArgs e)
        {
            RemoveItemcb();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
