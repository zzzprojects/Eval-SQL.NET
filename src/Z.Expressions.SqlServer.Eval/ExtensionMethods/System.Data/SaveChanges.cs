using System.Data;
using System.Data.SqlClient;

public static partial class Extensions
{
    public static void SaveChanges(this DataTable @this)
    {
        var sql = @this.ExtendedProperties["ZZZ_Select"].ToString();
        using (var connection = new SqlConnection("context connection = true"))
        {
            using (var adapter = new SqlDataAdapter(sql, connection))
            {
                // ReSharper disable once UnusedVariable
                var cmdBuilder = new SqlCommandBuilder(adapter);
                connection.Open();

                adapter.Update(@this);
            }
        }
    }
}