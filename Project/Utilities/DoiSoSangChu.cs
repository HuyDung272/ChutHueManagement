using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.Utilities
{
    public class DoiSoSangChu
    {
        private readonly string[] ChuSo = { "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

        private readonly string[] DonVi = { "ngàn", "triệu", "tỉ" };

        private int _so;

        public int So
        {
            get { return _so; }
            set { _so = value; }
        }

        public DoiSoSangChu(int so)
        {
            So = so;
        }

        public override string ToString()
        {
            string Kq = "";
            char[] textSo = So.ToString(CultureInfo.InvariantCulture).ToCharArray();
            int lenght = textSo.Length;
            int x, c = 0;
            int j = (lenght - 1) / 3 + 1;
            for (int i = 0; i < lenght; i++)
            {
                c = int.Parse(textSo[i].ToString(CultureInfo.InvariantCulture));
                x = (lenght - 1 - i) % 3;
                if (x == 0)
                    j--;
                if (c != 0)
                {
                    if (c == 1 && x == 1)
                    {
                        c = int.Parse(textSo[i + 1].ToString(CultureInfo.InvariantCulture));
                        if (c == 0)
                        {
                            i++;
                            Kq += "muời ";
                            j--;
                            Kq += DonVi[j] + " ";
                        }
                        else
                        {
                            Kq += "muời ";
                        }
                    }
                    else
                    {
                        if (x == 0 && c == 5)
                            Kq += "lăm ";
                        else if (c == 1 && x == 0 && lenght > 1 && int.Parse(textSo[i - 1].ToString(CultureInfo.InvariantCulture)) != 1 && int.Parse(textSo[i - 1].ToString(CultureInfo.InvariantCulture)) != 0)
                        {
                            Kq += "mốt ";
                        }
                        else
                        {
                            Kq += ChuSo[c - 1] + " ";
                        }
                        if (x == 0)
                        {
                            Kq += DonVi[j] + " ";
                        }
                        if (x == 1)
                        {
                            Kq += "mơi ";
                        }
                        if (x == 2)
                        {
                            Kq += "trăm ";
                        }
                    }
                }
                else
                {
                    if (x == 1)
                    {
                        c = int.Parse(textSo[i + 1].ToString(CultureInfo.InvariantCulture));
                        if (c != 0)
                            Kq += "lẻ ";
                    }
                    if (x == 0 && i != lenght - 1)
                    {
                        Kq += DonVi[j] + " ";
                    }
                    else if (i == lenght - 1)
                    {
                        if (lenght > 2 && (int.Parse(textSo[i - 1].ToString(CultureInfo.InvariantCulture)) != 0 || int.Parse(textSo[i - 2].ToString(CultureInfo.InvariantCulture)) != 0))
                        {
                            Kq += DonVi[j] + " ";
                        }
                    }
                }

            }
            return Kq;
        }
    }
}
