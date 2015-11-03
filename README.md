###Eval .NET code and expression in SQL stored procedure, function and trigger.###
- Dynamically evaluate .NET expression in SQL
- Use column value as code and parameter
- Extend SQL Syntax with regex
- Make IO operator easy again

*From simple expression...*
```sql
CREATE PROCEDURE [dbo].[select_formula]
AS
BEGIN
	SELECT  SQLNET::New('x + y')
		.Val('x', ColumnValueX)
		.Val('y', ColumnValueY)
		.Eval()
	FROM TableFormula
END
```

*and regex in where clause...*
```sql
CREATE PROCEDURE [dbo].[select_where_regex_filter]
AS
BEGIN
	DECLARE @sqlnet_filterFile SQLNET = SQLNET::New().SetCode('
	return Regex.IsMatch(filePath, "^.*\.(jpg|gif|docx|pdf)$");')
	
	SELECT  *
	FROM    [FileTable]
	WHERE	@sqlnet_filterFile.SetValue('filePath', FilePathColumn).Eval() = 1
END
```

*to more complex code returning a result set.*
```sql
CREATE PROCEDURE [dbo].[select_desktop_files]
AS
BEGIN
	DECLARE @sqlnet SQLNET = SQLNET::New('
	var dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
	return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
	
	/* SELECT * FROM [desktop_files] ORDER BY path */
	EXEC SQLNET_EvalResultSet @sqlnet
END
```

[Learn more](http://eval-sql.net/documentations/#more)

## Download
[SQLNET.zip](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net) <sub>(~525 KB)</sub>

*Setup*

1. Open the script with Microsoft SQL Server Management Studio (SSMS).
2. Change script mode to SQLCMD Mode (Query -> SQLCMD Mode).
3. Change DatabaseName variable for your database name (See 'CHANGE ME' section).
4. Run the sql script in your database server to install assemblies & objects.

Enjoy all free features for an unlimited period and PRO features for the current month.

To unlock all PRO features, visit http://eval-expression.net/

## Free VS Pro
Features | FREE Version | [PRO Version](http://eval-sql.net/#pro)
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Maximum Variables | 2 | Unlimited
Learn more about the [PRO Version](http://eval-sql.net/#pro)

## Support
- [Website](http://eval-sql.net/)
- [Documentation](http://eval-sql.net/documentations/)
- [Forum](https://zzzprojects.uservoice.com/forums/328452-eval-sql-net)
- sales@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!

## More Projects
  - [NET Entity Framework Ext.](http://www.zzzprojects.com/products/dotnet-development/entity-framework-extensions/)
  - [NET Bulk Operations](http://www.zzzprojects.com/products/dotnet-development/bulk-operations/)
  - [Eval Expression.NET](http://eval-expression.net/)
  - [Eval SQL.NET](http://eval-sql.net/)


