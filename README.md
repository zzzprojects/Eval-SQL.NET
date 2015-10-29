###Eval .NET code and expression in SQL stored procedure, function and trigger.###
- Dynamically evaluate expression
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

[Learn more](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)

## Download
[SQLNET.zip](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net) (~525 KB)

*Setup*

1. Open the script with Microsoft SQL Server Management Studio (SSMS).
2. Change script mode to SQLCMD Mode (Query -> SQLCMD Mode).
3. Change DatabaseName variable for your database name (See 'CHANGE ME' section).
4. Run the sql script in your database server to install assemblies & objects.

## Free VS Pro
Features | FREE Version | [PRO Version](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Maximum Variables | 2 | Unlimited
Learn more about the [PRO Version](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)

## Support
- [Website](http://eval-sql.net/)
- [Documentation](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
- [Forum](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
- sales@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!

## More Projects
  - [Entity Framework Plus.NET](sales@zzzprojects.com)
  - [NET Bulk Operations](sales@zzzprojects.com)
  - [Eval Expression.NET](sales@zzzprojects.com)
  - [Eval SQL.NET](sales@zzzprojects.com)


