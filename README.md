##Evaluate code and expression using .NET in T-SQL stored procedure, function and trigger##
- Evaluate expression at runtime
- Extend SQL Syntax with .NET object: Regex, String.Format, Math, ...
- Perform IO Operation with DirectoryInfo, FileInfo, Impersonalization, ...

## Eval
**Evaluate and execute the code or expression.**

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
**[Learn more](http://eval-sql.net/documentations/#more)**

## EXEC SQLNET_EvalResultSet
**Stored Procedures that evaluate the code and return a Result Set.**

> _You can output the result to the client or insert it in a table like a normal procedure with a SELECT statement._

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

**[Learn more](http://eval-sql.net/documentations/#more)**

## Download
[SQLNET.zip](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net) <sub>(~525 KB)</sub>

*Setup*

1. Open the script with Microsoft SQL Server Management Studio (SSMS).
2. Change script mode to SQLCMD Mode (Query -> SQLCMD Mode).
3. Change DatabaseName variable for your database name (See 'CHANGE ME' section).
4. Run the sql script in your database server to install assemblies & objects.

Enjoy all free features for an unlimited period and PRO features for the current month.

To unlock all PRO features, visit http://eval-expression.net/

## API - Cheat Sheet
Easy to use API

```sql
SELECT  SQLNET::New('X+Y').Val('X', 1).Val('Y', 2).Eval()
```
Options | Value | Eval
------------ | ------------- | -------------
SQLNET::New(code) | Val(key, object) | Eval()
Code(code) | Value(key, object) | EvalBigInt()
Cache(bit) | ValueBinary(key, byte[]) | EvalBit()
Dispose() | ValueString(key, string) | EvalInt()
Impersonate(bit) | ValueXml(key, XML) | EvalSmallInt()
 | ValueSQLNET(key, SQLNET) | EvalString()
 | | EvalTinyInt()
 | | EvalSQLNET()
 | | EXEC SQLNET_EvalResultSet

## Free VS Pro
Features | FREE Version | [PRO Version](http://eval-sql.net/#pro)
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Commercial License | No | Yes
Royalty-Free | No | Yes
Support & Upgrades (1 year) | No | Yes
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


