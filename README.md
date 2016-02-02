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
DECLARE @tableFormula TABLE
    (
      Formula VARCHAR(255) ,
      X INT ,
      Y INT ,
      Z INT
    )

INSERT  INTO @tableFormula
VALUES  ( 'x+y*z', 1, 2, 3 ),
        ( '(x+y)*z', 1, 2, 3 )

-- SELECT 7
-- SELECT 9
SELECT  SQLNET::New(Formula).Val('x', X).Val('y', Y).Val('z', Z).EvalInt()
FROM    @tableFormula
```

## Download
**[SQLNET.zip](https://github.com/zzzprojects/Eval-SQL.NET/releases)**

_Minimum Requirements_
- SQL CLR Permission Level: **SAFE**
- SQL 2012
- .NET Framework 4.0

## Main Features
#### SQL Runtime Evaluation

Evaluate and execute the code or expression.

```sql
CREATE PROCEDURE [dbo].[Select_Switch] @x INT, @y INT, @z INT
AS
    BEGIN
        DECLARE @result INT

        SET @result = SQLNET::New('
switch(x)
{
    case 1: return y + z;
    case 2: return y - z;
    case 3: return y * z;
    default: return Convert.ToInt32(y ^^ z); // Pow
}
   ').Val('x', @x).Val('y', @y).Val('z', @z).EvalInt()

        SELECT  @result
    END

GO

-- RETURN 5
EXEC Select_Switch 1, 2, 3
-- RETURN -1
EXEC Select_Switch 2, 2, 3
-- RETURN 6
EXEC Select_Switch 3, 2, 3
-- RETURN 8
EXEC Select_Switch 4, 2, 3
```

**[Learn more](https://github.com/zzzprojects/Eval-SQL.NET/wiki)**

#### SQL Regex

Evaluate and execute the code or expression.

```sql
CREATE FUNCTION [dbo].[fn_Split]
    (
      @input VARCHAR(MAX) ,
      @pattern VARCHAR(8000) = ','
    )
RETURNS @split TABLE ( item VARCHAR(8000) )
    BEGIN
        DECLARE @regex_split SQLNET = SQLNET::New('Regex.Split(input, pattern)')
                                             .ValueString('input', @input)
                                             .Val('pattern', @pattern)

        INSERT  INTO @split
                SELECT  CAST(Value_1 AS VARCHAR(8000))
                FROM    [dbo].[SQLNET_EvalTVF_1](@regex_split)
        RETURN
    END

GO

-- SPLIT with multiple delimiters (',' and ';')
SELECT * FROM dbo.fn_Split('1, 2, 3; 4; 5', ',|;')
```

**[Learn more](https://github.com/zzzprojects/Eval-SQL.NET/wiki)**

#### SQL Result Set

Evaluate and execute the code or expression.

```sql
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
    .Impersonate()

-- SELECT * FROM DesktopFiles ORDER BY File.Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
```

**[Learn more](https://github.com/zzzprojects/Eval-SQL.NET/wiki)**

## FREE vs PRO

Every month, a **[FREE trial](https://github.com/zzzprojects/Eval-SQL.NET/releases)** of the PRO version is available to let you evaluate all its features without limitations.

Features | FREE Version | PRO Version
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Commercial License | No | Yes
Support & Upgrades (1 year) | No | Yes

Learn more about the **[PRO Version](http://eval-sql.net/#pro)**

## Contributing
_You received support from us and/or the FREE version helped you?_

Contribute to keep us developing FREE features and to thank us for our support.

We'll never require donations, but we appreciate them greatly

<a href="http://www.zzzprojects.com/contribute/" target="_blank"><img src="http://www.zzzprojects.com/images/paypal-contribute.png" alt="Contribute" height="48"></a>

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
