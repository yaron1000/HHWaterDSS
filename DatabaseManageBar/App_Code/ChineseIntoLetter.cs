using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManageBar
{
    class ChineseIntoLetter
    {
        /// <summary>
        /// 得到汉字拼音首字母
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <returns></returns>
        public static string HZToPYSimple(string chineseStr)
        {
            try
            {
                byte[] b = System.Text.UnicodeEncoding.Default.GetBytes(chineseStr);
                string res = "";
                for (int i = 0; i < b.Length; )
                {
                    if (i == b.Length - 1)
                    {
                        if (char.IsNumber((char)b[i]) || char.IsLetter((char)b[i]))
                            res += (char)b[i++];
                        else
                        {
                            i++;
                            continue;
                        }
                    }
                    else if (Convert.ToByte(b[i]) > 127)//汉字
                    {
                        string tmp = System.Text.UnicodeEncoding.Default.GetString(b, i, 2);
                        tmp = HZToCode(tmp);
                        if (tmp.Length > 0)
                            res += tmp[0];
                        i += 2;
                    }
                    else
                    {
                        if (char.IsNumber((char)b[i]) || char.IsLetter((char)b[i]))
                            res += (char)b[i++];
                        else
                        {
                            i++;
                            continue;
                        }
                    }
                }
                return res.ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception("错误:", ex);
            }
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        private static string HZToCode(string chineseStr)//typeStr是指拼音还是五笔码
        {
            try
            {
                string resultStr = "";
                byte[] arrCN = Encoding.Default.GetBytes(chineseStr);
                if (arrCN.Length > 1)
                {
                    int area = (short)arrCN[0];
                    int pos = (short)arrCN[1];
                    int code = (area << 8) + pos;
                    int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 
                        48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 
                        51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                    for (int i = 0; i < 26; i++)
                    {
                        int max = 55290;
                        if (i != 25) max = areacode[i + 1];
                        if (areacode[i] <= code && code < max)
                        {
                            resultStr = Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                            break;
                        }
                    }
                }

                return resultStr;
            }
            catch (Exception ex)
            {
                throw new Exception("错误:", ex);
            }
        }
    }
}
