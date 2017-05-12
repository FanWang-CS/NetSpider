using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCollection.Helper
{
    class StringHelper
    {
        //获取两个字符串相同的前缀
        public static String getIdentical_Prefix(String firstStr, String secondStr)
        {
            String result = "";
            if(String.IsNullOrEmpty(firstStr) || String.IsNullOrEmpty(secondStr))
            {
                return result;
            }
            int len = Math.Min(firstStr.Length,secondStr.Length);
            for(int i = 0; i < len; i++)
            {
                if (firstStr.ElementAt(i).Equals(secondStr.ElementAt(i)))
                {
                    result += firstStr.ElementAt(i);
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
