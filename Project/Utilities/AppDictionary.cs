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
            dic.Add("NhanVien", "Nhân Viên");
            dic.Add("MaMT", "Mã MT");
            dic.Add("TenMT", "Tên Máy Tính");
            dic.Add("DonGia", "Đơn Giá");
            dic.Add("MoTa", "Mô Tả");
            dic.Add("TenNV", "Tên nhân viên");
            dic.Add("NghiepVu", "Nghiệp vụ");
            dic.Add("DiaChi", "Địa chỉ");
            dic.Add("SoDT", "Số điện thoại");
            dic.Add("NgaySinh", "Ngày Sinh");
            dic.Add("GioiTinh", "Giới tính");
            dic.Add("TinhTrang", "Tình trạng");
            dic.Add("TenNCC", "Tên nhà cung cấp");
            dic.Add("MaSoThue", "Mã số thuế");
            dic.Add("TenKH", "Tên khách hàng");
            dic.Add("CMND_MaSoThue", "CMND-Mã số thuế");
            dic.Add("HangSX", "Hãng sản xuất");
            dic.Add("IDLoaiMH", "Id Loại mặt hàng");
            dic.Add("NuocSX", "Nước sản xuất");
            dic.Add("GiaNhap", "Giá nhập");
            dic.Add("GiaBan", "Giá Bán");
            dic.Add("BaoHanh", "Bảo hành");
            dic.Add("CauHinh", "Cấu hình");
            dic.Add("SoLuong", "Số lượng");
            dic.Add("Gia", "Giá");
            dic.Add("IDModelMH", "ID Model Nhập");
            dic.Add("IDHDNhap", "ID Hóa đơn nhập");
            dic.Add("IDHDBan", "ID hóa đơn bán");
            dic.Add("IDHDXuat", "ID Hóa Đơn Xuất");
            dic.Add("IDBLTraHang", "ID biên lai trả hàng");
            dic.Add("TenLoai", "Tên Loại");
            dic.Add("GhiChu", "Ghi Chú");
            dic.Add("MaHD", "Mã Hóa Đơn");
            dic.Add("TongTien", "Tổng Tiền");
            dic.Add("MaBL", "Mã Biên Lai");
            dic.Add("NameGroup", "Phân Quyền");
            dic.Add("DonVi", "Đơn vị");
            dic.Add("MaDonViTinh", "Mã đơn vị tính");
            dic.Add("MaKH", "Mã khách hàng");
            dic.Add("MaNCC", "Mã nhà cung cấp");
            dic.Add("MaLoaiMH", "Mã loại mặt hàng");
            dic.Add("TenLoaiMH", "Tên loại mặt hàng");
            dic.Add("MaModelMH", "Mã model mặt hàng");
            dic.Add("MaNV", "Mã nhân viên");
            dic.Add("NgayLap", "Ngày lập");
            dic.Add("MaHoaDon", "Mã hóa đơn");
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

