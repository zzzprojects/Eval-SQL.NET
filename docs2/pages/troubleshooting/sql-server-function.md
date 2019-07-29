# SQL Server Function (UDF)

## Introduction

User-Defined Function (UDF) encapsulates code to make it easier to reuse. However, there are some limitations and restrictions:

 - Cannot call stored procedure
 - Cannot use try/catch
 - Cannot modify table state
 - Cannot run dynamic sql

**Eval SQL.NET** enhances function capabilities and lets you use C# language directly in T-SQL functions to overcome their limitations and restrictions.

## SQL Function - Better readability

### Problem

You need to write a function but the code soon becomes very complex and unmaintainable.

### Solution

Eval SQL.NET improves the readability and maintainability of complex functions by using well-known C# objects.


```csharp

DECLARE @s VARCHAR(MAX) = '1, 2, 3; 4; 5'
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Split(input, ",|;")')

SELECT  *
FROM    dbo.SQLNET_EvalTVF_1(@sqlnet.ValueString('input', @s))

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1069' %}

### Discussion

For simple code, SQL syntax may work like a charm but when the code's complexity increases, less SQL is best suited for the job. It is designed to write queries, not to create long spaghetti code. We all have seen some functions that could have been written so much easier using another language like C#.

One of the most common function is probably the fn_split function. It's not that hard to understand but thousands of variances exist and most of them are limited to only one delimiter. Using Eval SQL.NET, the fn_split function takes regular expression to split text which makes it very powerful.


## SQL Function - Error handling

### Problem

You need to handle an error with a TRY/CATCH but you receive the SQL error:

 - *Invalid use of a side-effecting operator 'BEGIN TRY' within a function.*
 - *Invalid use of a side-effecting operator 'END TRY' within a function.*
 - *Invalid use of a side-effecting operator 'BEGIN CATCH' within a function.*
 - *Invalid use of a side-effecting operator 'END CATCH' within a function.*

### Solution

Eval SQL.NET makes it possible to handle errors with TRY/CATCH within a T-SQL function.


```csharp

CREATE FUNCTION [dbo].[fn_try_catch] ( @x INT, @y INT )
RETURNS INT
AS
    BEGIN
        RETURN SQLNET::New('
try
{
	return x / y
}
catch (Exception ex)
{
	return x;
}
').ValueInt('x', @x).ValueInt('y', @y).EvalInt()

    END

GO
	
-- SELECT 4
SELECT  dbo.fn_try_catch(4, 0) as Result

-- SELECT 2
SELECT  dbo.fn_try_catch(4, 2) as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/d0cf1/1' %}

## SQL Function - Call stored procedure

### Problem

You need to call a procedure within a function but you receive the SQL error:

 - *Only functions and some extended stored procedures can be executed from within a function.**

### Solution

Eval SQL.NET makes it possible to call stored procedures within a T-SQL function.


```csharp

CREATE FUNCTION [dbo].[fn_CallProcedure] ( )
RETURNS SQL_VARIANT
AS
    BEGIN
        RETURN SQLNET::New('
defaultCommand.CommandText = "[PROCEDURE_NAME]"; 
defaultCommand.CommandType = CommandType.StoredProcedure;
defaultCommand.Parameters.AddWithValue("name", name);
return defaultCommand.ExecuteScalar();
').ValueString('name', 'zzz').Eval()

    END

```

Using this feature is highly **NOT RECOMMENDED**.

## SQL Function - Modify table state

### Problem

You need to insert, update or delete data within a function but you receive the SQL error:

User-defined functions cannot be used to perform actions that modify the database state.

### Solution

Eval SQL.NET makes it possible to modify table state (insert, update and delete) within a T-SQL function.


```csharp

CREATE FUNCTION [dbo].[fn_modify_table_state]
    (
      @conn VARCHAR(8000) ,
      @sql VARCHAR(8000)
    )
RETURNS INT
AS
    BEGIN
        RETURN SQLNET::New('
using(var connection = new SqlConnection(conn))
{
    connection.Open();

    using(var command = new SqlCommand(sql, connection))
    {
        return command.ExecuteNonQuery();
    }
}
').ValueString('conn', @conn).ValueString('sql', @sql).EvalReadAccessInt()

    END

    GO

DECLARE @conn VARCHAR(8000) = 'Data Source=XPS8700;Initial Catalog=SqlServerEval_Debug;Integrated Security=True'
DECLARE @sql VARCHAR(8000) = 'UPDATE [Table_1] SET Value = -1 WHERE Name = ''zzz'''

DECLARE @rowAffecteds INT =  dbo.fn_modify_table_state(@conn, @sql)

```

Using this feature is highly **NOT RECOMMENDED**.

## SQL Function - Run dynamic SQL

### Problem

You need to "EXECUTE" a string within a function but you receive the SQL error:

Invalid use of a side-effecting operator 'EXECUTE STRING' within a function.

### Solution

Eval SQL.NET makes it possible to run "EXECUTE" and evaluate dynamic expressions within a T-SQL function.


```csharp

CREATE FUNCTION [dbo].[fn_Exec_Count] ( @sql VARCHAR(8000) )
RETURNS INT
AS
    BEGIN
        RETURN SQLNET::New('
var dt = new DataTable();
var s = "Data Source=XPS8700;Initial Catalog=SqlServer_Eval;Integrated Security=True";
using(var connection = new SqlConnection(s))
{
    connection.Open();

    using(var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandText = "EXEC(''" + sql + "'')"; 
        dt.Load(command.ExecuteReader());
        return dt.Rows.Count;
    }
}
').ValueString('sql', @sql).EvalReadAccessInt()

    END

GO

-- SELECT 2
SELECT  dbo.fn_Exec_Count('SELECT 1 UNION SELECT 2') as Result

```

Using this feature is highly **NOT RECOMMENDED**.

## Conclusion

Eval SQL.NET improves the readability and make the code easier to develop and maintain with C# syntax over complex SQL code.

Even if you are now allowed to make some table modifications, we don't recommend using this feature and use a stored procedure instead. Make sure you use the right tool for the right job.

