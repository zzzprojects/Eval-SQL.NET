##Evaluate C# code and expression in T-SQL stored procedure, function and trigger##

**Extend SQL with the full C# Syntax and get the best of both languages:**

- Access to .NET objects
	- Math
	- Regex
	- String Interpolation
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
CREATE PROCEDURE [dbo].[select_pricing]
AS
BEGIN
    -- SELECT [FormattedTotalPrice] FROM TableItems
    SELECT  SQLNET::New('(X*Y).ToString("$#.00")')
        .Val('X', UnitPrice)
        .Val('Y', Quantity)
        .Eval()
    FROM TableItems
END
```

## Download
**[SQLNET.zip](https://github.com/zzzprojects/Eval-SQL.NET/releases) <sub>(~525 KB)</sub>** 

*FREE Version limited to 50 characters

## Eval
**Evaluate and execute the code or expression.**

**Support:**

_SQL Runtime Evaluation_
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

_SQL Regex_
```sql
CREATE PROCEDURE [dbo].[select_where_regex_filter]
AS
BEGIN
    DECLARE @sqlnet_filterFile SQLNET = SQLNET::New('
    return Regex.IsMatch(FILEPATH, "^.*\.(jpg|gif|docx|pdf)$");')

    SELECT  *
    FROM    [FileTable]
    WHERE   @sqlnet_filterFile.Val('FILEPATH', FilePathColumn).Eval() = 1
END
```

_SQL Result Set_
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

## What's supported?
Eval SQL.NET support all C# Syntax:
- All C# Keywords ([MSDN Documentation](https://msdn.microsoft.com/en-us/library/x53a06bb.aspx))
- All C# Operators ([MSDN Documentation](https://msdn.microsoft.com/en-CA/library/6a71f45d.aspx))
- Constant Folding
- Extension Methods
- Generic Type
- Lambda Expression
- Number Suffix

You can even access to C# 6.0 features even in C# 4.0.
- string interpolation
- typename
- null conditional member access

**[Learn more](https://github.com/zzzprojects/Eval-SQL.NET/wiki/Syntax-Supported)**

## FREE vs PRO
Every month, a new monthly trial of the PRO Version is available to let you evaluate all its features without limitations.

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
- [Forum](https://zzzprojects.uservoice.com/forums/328452-eval-sql-net)
- sales@zzzprojects.com

## Contributing
_You received support from us and/or the FREE version helped you?_

Contribute to keep us developing FREE features and to thank us for our support.

We'll never require donations, but we appreciate them greatly

<a href="http://www.zzzprojects.com/contribute/" target="_blank"><img src="http://www.zzzprojects.com/images/paypal-contribute.png" alt="Contribute" height="64"></a>

A **huge thanks** for your extra support.


## More Projects

**Entity Framework**
- [Entity Framework Extensions](http://www.zzzprojects.com/products/dotnet-development/entity-framework-extensions/)
- [Entity Framework Plus](https://github.com/zzzprojects/EntityFramework-Plus)

**Bulk Operations**
- [NET Entity Framework Extensions](http://www.zzzprojects.com/products/dotnet-development/entity-framework-extensions/)
- [NET Bulk Operations](http://www.zzzprojects.com/products/dotnet-development/bulk-operations/)

**Expression Evaluator**
- [Eval SQL.NET](https://github.com/zzzprojects/Eval-SQL.NET)
- [Eval Expression.NET](https://github.com/zzzprojects/Eval-Expression.NET)

**Others**
- [Extension Methods Library](https://github.com/zzzprojects/Z.ExtensionMethods/)
- [LINQ Async](https://github.com/zzzprojects/Linq-AsyncExtensions)

**Need more info?** info@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!
