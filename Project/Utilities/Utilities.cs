using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using NLog;

namespace ChutHueManagement.Utilities
{
    public class Library_Controls
    {
        public static void ShowMDI(FormCollection col, string FormName)
        {
            for (int i = 0; i < col.Count; i++)
            {
                if (col[i].Name.CompareTo("FormPrimary") == 0)
                {
                    continue;
                }
                else
                {
                    if (col[i].Name.CompareTo(FormName) == 0)
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            col[i].Hide();
                        }
                        catch (Exception)
                        {
                        }

                    }

                }
            }
        }
    }

    public class StringHelper
    {
        public static bool IsNullorEmpty(string text)
        {
            return text == null || text.Trim() == string.Empty || text == "";
        }

        public static bool Length(string text, int length)
        {
            if (text.Length <= length)
                return true;
            return false;
        }

        public static bool KT_KyTuDacBiet(string text)
        {
            Match m = Regex.Match(text, @"[!@#$%&*]+", RegexOptions.IgnoreCase);
            if (m.Success)
                return true;
            return false;
        }

        public static bool KT_KyTuDacBiet_So(string text)
        {
            Match m = Regex.Match(text, @"[!@#$%&*0-9]+", RegexOptions.IgnoreCase);
            if (m.Success)
                return true;
            return false;
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static string CatchuoiGia(string gia)
        {
            string[] ch = gia.Split('.');
            return ch[0];
        }
    }

    public class DataUtil
    {
        /// <summary>
        /// chỉ cho nhập số
        /// </summary>
        public static void PressInt(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        /// <summary>
        /// tạo lớp từ điển
        /// </summary>
        static AppDictionary td = new AppDictionary();
        public static int ToInt(object val, int def)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return def;
            }
        }

        public static int ToInt(object val)
        {
            return ToInt(val, 0);
        }

        public static string ToString(object val, string def)
        {
            try
            {
                return Convert.ToString(val);
            }
            catch
            {
                return def;
            }
        }

        public static string ToString(object val)
        {
            return ToString(val, null);
        }

        public static decimal ToDecimal(object val, decimal def)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                return def;
            }
        }

        public static decimal ToDecimal(object val)
        {
            return ToDecimal(val, -1);
        }

        public static bool KTToDecimal(object val)
        {
            try
            {
                Convert.ToDecimal(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// đổi column tên của datatable 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable ChangeColumn(DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ColumnName = td.KiemTra(col.ColumnName);
                }
            }
            return dt;
        }

        /// <summary>
        /// đổi column tên của datatable 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void ChangeColumn(DataGridView grid)
        {
            DataTable dt = (DataTable)grid.DataSource;
            if (dt != null)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ColumnName = td.KiemTra(col.ColumnName);
                }
            }
            grid.DataSource = dt;
        }

        /// <summary>
        /// hàm chuyển từ chuối có dấu sang chuối không có dấu
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// kiểm tra chuỗi có dấu
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool KiemTraChuoi(string s1, string s2)
        {
            if (convertToUnSign3(s1).ToLower() == convertToUnSign3(s2).ToLower())
                return true;
            else
            {
                return false;
            }
        }

        /// <summary>
        /// swap chuỗi
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        public static void SwapString(ref string s1, ref string s2)
        {
            string c = s1;
            s1 = s2;
            s2 = s1;
        }

        /// <summary>
        /// kiểm tra startwitdth
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool StringStartWith(string s1, string s2)
        {
            return convertToUnSign3(s1.ToLower()).StartsWith(convertToUnSign3(s2.ToLower()));
        }

        /// <summary>
        /// kiểm tra số điện thoại
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public static bool KiemTraSoDt(string sdt)
        {
            Match m = Regex.Match(sdt, @"^[0-9]{6,11}$", RegexOptions.IgnoreCase);
            if (m.Success)
                return true;
            return false;
        }

        /// <summary>
        /// hàm chuyển số thánh bool 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool[] ConvertBool(int x)
        {
            bool[] bits = new bool[4];
            int i = 0;
            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? true : false;
                x >>= 1;
            }
            Array.Reverse(bits, 0, i);
            return bits;
        }

        /// <summary>
        /// hàm chuyển từ bool sang số
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ConvertToInt(bool[] x)
        {
            int lenght = x.Count();
            int kq = 0;
            for (int i = 0; i < lenght; i++)
            {
                if (x[i])
                    kq += (int)Math.Pow(2, lenght - 1 - i);
            }
            return kq;
        }


        public static bool KiemTraEmail(string email)
        {
            Match m = Regex.Match(email, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase);
            if (m.Success)
                return true;
            return false;
        }


        /// <summary>
        /// kiểm tra startwith
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool StringStartWith(string s1, string[] arr)
        {
            foreach (string ar in arr)
            {
                if (!s1.StartsWith(ar))
                    return false;
            }
            return true;
        }


        /// <summary>
        /// hàm tìm kiếm theo các đối tượng
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="doituong"></param>
        /// <param name="text"></param>
        /// <returns></returns>


        public static DataTable TimkiemTheo(DataTable dt, string doituong, string text)
        {
            return TimkiemTheo(dt, typeof(string), doituong, text);
        }


        public static DataTable TimkiemTheo(DataTable dt, Type type, string doituong, string text)
        {
            if (type == typeof(string))
            {
                var table2 = dt.AsEnumerable().Where(x => StringStartWith(x.Field<string>(doituong), text));
                return table2.Any() ? table2.CopyToDataTable() : null;
            }
            if (type == typeof(int))
            {
                var table2 = dt.AsEnumerable().Where(x => StringStartWith(x.Field<int>(doituong).ToString(), text));
                return table2.Any() ? table2.CopyToDataTable() : null;
            }
            return null;
        }

        /// <summary>
        /// hàm kiểm tra trong datable theo thời gian
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="doituong"></param>
        /// <param name="text"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static DataTable TimkiemTheo(DataTable dt, string doituong, int text, int k)
        {
            var table2 = dt.AsEnumerable()
                             .Where(x => ConvertToDateTime(x.Field<DateTime>(doituong), k) == text);
            return table2.Any() ? table2.CopyToDataTable() : null;
        }

        /// <summary>
        /// hàm kiểm tra dattime
        /// </summary>
        /// <param name="dtime"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int ConvertToDateTime(DateTime dtime, int k)
        {
            switch (k)
            {
                case 0:
                    return dtime.Day;
                case 1:
                    return dtime.Month;
                case 2:
                    return dtime.Year;
                case 3:
                    return (int)Math.Ceiling((double)dtime.Month / 3);
                    //break;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// hàm kiểm tra thông tin nhập vào là text 
        /// </summary>
        /// <param name="inputStrings"></param>
        /// <returns></returns>
        public static bool CheckInput(params string[] inputStrings)
        {
            foreach (string str in inputStrings)
            {
                if (StringHelper.IsNullorEmpty(str))
                    return false;
            }
            return true;
        }
    }

    public class FileHelper
    {
        private string path;
        private FileStream stream;

        public FileHelper(string filePath)
        {
            path = filePath;
        }

        private void OpenToRead()
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        private void OpenToWrite()
        {
            stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        }

        private void OpenToAppend()
        {
            stream = new FileStream(path, FileMode.Append, FileAccess.Write);
        }

        public void AppendLine(string data)
        {
            this.OpenToAppend();

            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(data);
            sw.Close();
        }

        public void WriteLine(string data)
        {
            this.OpenToWrite();
            StreamWriter sw = new StreamWriter(data);
            sw.WriteLine(data);
            sw.Close();
        }

        public string ReadAll()
        {
            this.OpenToRead();
            StreamReader sr = new StreamReader(stream);

            string data = sr.ReadToEnd();
            sr.Close();
            return data;
        }
    }

    public class Logger
    {
        /// <summary>
        /// tao files log cuar nlog 
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void Write(string errorMessage)
        {
            ///tao log
            string path = ConfigurationManager.AppSettings["logPath"];
            FileHelper helper = new FileHelper(path);
            helper.AppendLine(errorMessage);

            ///tao nlog
            var log = LogManager.GetCurrentClassLogger();
            log.Error(errorMessage);
        }

        public static void Write(Exception ex)
        {
            ///log
            Logger.Write(ex.Message);
            ///nlog
            var log = LogManager.GetCurrentClassLogger();
            log.Error(ex);
        }
    }
}
