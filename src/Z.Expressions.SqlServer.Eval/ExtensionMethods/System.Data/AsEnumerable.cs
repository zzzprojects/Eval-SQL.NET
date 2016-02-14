using System.Collections.Generic;
using System.Data;

public static partial class Extensions
{
    public static List<DataRow> AsEnumerable(this DataTable @this)
    {
        var drs = new List<DataRow>();

        foreach (DataRow row in @this.Rows)
        {
            drs.Add(row);
        }

        return drs;
    }
}