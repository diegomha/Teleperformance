using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Teleperformance.Helpers
{
    public static class SecurityHelper
    {
        private static string salt = "Ta*:uKd--douU3*GR_rOU?at-H:vPYIJ";

        public static string MD5(this string s, bool useSalt = false)
        {
            if (useSalt)
                s = salt + s;

            var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}