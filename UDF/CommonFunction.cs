using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace UDF
{
    [Guid("589DCCC1-7101-4014-B18B-1A5B87B27544")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class CommonFunction : UDFBase
    {
        public CommonFunction()
        {

        }

        public int MergeRowsCount(Range rng)
        {
            return rng.MergeArea.Rows.Count;
        }
    }
}
