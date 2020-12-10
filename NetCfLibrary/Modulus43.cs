using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HTIPackageAllocation.NetCfLibrary
{
    public static class Modulus43
    {

        /// <summary>
        /// In the Modulus 43 method, below characters can be used.
        /// [0] ~ [9], [A] ~ [Z], [-], [.], [ ], [$], [/], [+], [%]
        /// Attention:
        ///   - Small letters can NOT be used.
        ///   - CheckDigit may return a space character [ ].
        /// 
        /// http://www.activebarcode.com/codes/checkdigit/modulo43.html
        /// https://jonhilton.net/2008/07/31/code-39-mod-43-checksum/
        /// </summary>
        public static string GetCheckDigit(string barcode)
        {
            const string CharSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";
            bool failed = false;
            int subtotal = 0;

            int index;
            for (int i = 0; i < barcode.Length; i++)
            {
                index = CharSet.IndexOf(barcode.Substring(i, 1));
                if (index < 0)
                {
                    failed = true;
                    break;
                }
                else
                {
                    subtotal += index;
                }
            }

            return (failed) ? null : CharSet.Substring(subtotal % 43, 1);
        }
    }
}
