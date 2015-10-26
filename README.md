###Eval .NET expression in SQL stored procedure, function and trigger.###
- Dynamically evaluate expression
- Use column value as code and parameter
- Extend SQL Syntax with regex
- Make IO operator easy again

*From simple expression*
```sql
/* Use string.Format in SELECT clause */
SELECT  SQLNET::New('string.format("Hi firstname, lastname")')
	.Val('firstname', [ColumnFirstName])
	.Val('lastname', [ColumnLastName])
FROM [CustomerTable]
```
*To complex code*
```sql
/* SELECT * FROM [desktop_files] ORDER BY path */
DECLARE @sqlnet SQLNET = SQLNET::New('
var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var dir = new DirectoryInfo(Path);
var files = dir.GetFiles("*.*");
return files.Select(x => x.FullName).OrderBy(x => x).ToList();').SetImpersonate(1)

EXEC SQLNET_EvalResultSet @sqlnet
```

[Learn more](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)

## Download
zip file...

*Setup*

1. Open the script with Microsoft SQL Server Management Studio (SSMS).
2. Change script mode to SQLCMD Mode (Query -> SQLCMD Mode).
3. Change DatabaseName variable for your database name (See 'CHANGE ME' section).
4. Run the sql script in your database server to install assemblies & objects.

## Free VS Pro
Features | FREE Version | [PRO Version](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
------------ | ------------- | -------------
Maximum Characters | 50 | Unlimited
Maximum Variables | 2 | Unlimited
Learn more about the [PRO Version](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)

## Support
- [Documentation](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
- [Forum](https://zzzprojects.uservoice.com/forums/327759-eval-expression-net)
- sales@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!

## More Projects
  - [Entity Framework Plus.NET](sales@zzzprojects.com)
  - [NET Bulk Operations](sales@zzzprojects.com)
  - [Eval Expression.NET](sales@zzzprojects.com)
  - [Eval SQL.NET](sales@zzzprojects.com)


