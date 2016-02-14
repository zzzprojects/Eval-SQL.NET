using System.Data;
using System.Data.SqlClient;

public static partial class Extensions
{
    public static DataTable ExecuteDataTable(this SqlCommand @this)
    {
        var dt = new DataTable();

        using (var dataAdapter = new SqlDataAdapter(@this))
        {
            dataAdapter.Fill(dt);
        }

        return dt;
    }
}