using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.Utilities
{
    public class AppDictionary
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        public AppDictionary()
        {
            dic.Add("ID", "Mã");
            dic.Add("NameEntryMenu", "Loại thực đơn");
            dic.Add("IsDelete", "Tình trạng (Khóa)");
            dic.Add("Description", "Mô tả");
            dic.Add("NameFood", "Tên món");
            dic.Add("Price", "Đơn giá");
            dic.Add("Name", "Tên");
            dic.Add("Note", "Ghi chú");
            dic.Add("IsBackup", "Backup");
            dic.Add("Paths", "Đường dẫn");
            dic.Add("DateTime", "Thời gian");
        }
        public string KiemTra(string key)
        {
            string kq = dic.Where(p => p.Key == key).Select(p => p.Value).SingleOrDefault();
            if (kq == null)
                kq = key;
            return kq;
        }
    }
}

