##Evaluate C# code and expression in T-SQL stored procedure, function and trigger##

**Extend SQL with the full C# Syntax and get the best of both languages:**

- Access to .NET objects
	- Math
	- Regex
	- String.Format
- Evaluate expression at runtime
	- Use column value as code
	- Use column value as parameter
- Perform IO Operation
	- Replace xp_cmdshell with C# Syntax
	- DirectoryInfo
	- FileInfo
	- Impersonate
- Function Improvment
	- Modify Table State
	- Try/Catch Error Handling
    
```sql
CREATE PROCEDURE [dbo].[select_formula]
AS
BEGIN
	SELECT  SQLNET::New('X + Y')
		.Val('X', ColumnValueX)
		.Val('Y', ColumnValueY)
		.Eval()
	FROM TableFormula
END
```

## Download
**[SQLNET.zip](https://github.com/zzzprojects/Eval-SQL.NET/releases) <sub>(~525 KB)</sub>** 

*FREE Version - up to 50 characters

## Eval
**Evaluate and execute the code or expression.**

**Support:**

_Runtime Evaluation_
```sql
CREATE PROCEDURE [dbo].[select_formula]
AS
BEGIN
	SELECT  SQLNET::New('X + Y')
		.Val('X', ColumnValueX)
		.Val('Y', ColumnValueY)
		.Eval()
	FROM TableFormula
END
```

_Regex_
```sql
CREATE PROCEDURE [dbo].[select_where_regex_filter]
AS
BEGIN
    DECLARE @sqlnet_filterFile SQLNET = SQLNET::New('
    return Regex.IsMatch(FILEPATH, "^.*\.(jpg|gif|docx|pdf)$");')

    SELECT  *
    FROM    [FileTable]
    WHERE   @sqlnet_filterFile.SetValue('FILEPATH', FilePathColumn).Eval() = 1
END
```

_Result Set_
```sql
CREATE PROCEDURE [dbo].[select_directiry_files] @PATH VARCHAR(255)
AS
BEGIN
	DECLARE @sqlnet SQLNET = SQLNET::New('
	var dir = new DirectoryInfo(PATH);
	return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
	.Val('PATH', @PATH)
	
	/* SELECT * FROM [path_files] ORDER BY path */
	EXEC SQLNET_EvalResultSet @sqlnet
END
```

**[Learn more](https://github.com/zzzprojects/Eval-SQL.NET/wiki)**

## FREE vs PRO
With the free version comes a month long trial of the pro license to let you evaluate all its functonalities without limits.

Features | FREE Version | [PRO Version](http://eval-sql.net/#pro)
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Commercial License | No | Yes
Royalty-Free | No | Yes
Support & Upgrades (1 year) | No | Yes
Learn more about the **[PRO Version](http://eval-sql.net/#pro)**

## Support
Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!

- [Website](http://eval-sql.net/)
- [Documentation](https://github.com/zzzprojects/Eval-SQL.NET/wiki)
- [Forum](http://zzzprojects.uservoice.com/forums/328452-eval-sql-net)
- sales@zzzprojects.com

## More Projects
  - [NET Entity Framework Extensions](http://www.zzzprojects.com/products/dotnet-development/entity-framework-extensions/)
  - [NET Bulk Operations](http://www.zzzprojects.com/products/dotnet-development/bulk-operations/)
  - [Eval Expression.NET](http://eval-expression.net/)
  - [Eval SQL.NET](http://eval-sql.net/)


