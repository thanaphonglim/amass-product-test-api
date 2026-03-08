using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Application.Common.Helpers
{
    public static class ProductCodeFormatter
    {
        public static string Format(string code)
        {
            return string.Join("-",
                Enumerable.Range(0, code.Length / 4)
                    .Select(i => code.Substring(i * 4, 4)));
        }
    }
}
