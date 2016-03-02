Provide to SQL Server all missing pieces like regular expression and dynamic arithmetic string evaluation.

```sql
-- SELECT 3
SELECT  SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt()
```

**Find your solutions:**
- Dynamic Arithmetic Expression
- Dynamic Pivot Table
- Regular Expression
- String Interpolation
- Replace xp_cmdshell with DirectoryInfo & FileInfo

## Performance & Scalability
Performance tuning is one of the most important task for a DBA. Don’t miss the chance to **dramatically improve query performance** by **300%** for simple expression and by more than **2000%** for complex code over User-Defined Function (UDF) and Table-Valued Function (TVF).

_Benchmark to split string with delimiters in SQL_

| Methods       | 1,000 rows | 10,000 rows | 100,000 rows | 1,000,000 rows |
| ------------- | ---------: | ----------: | -----------: | -------------: |
|Eval-SQL.NET   | 4 ms       | 13 ms       | 160 ms       | 1,650 ms       |
|fn_split (TVF) | 100 ms     | 625 ms      | 5,500 ms     | 55,000 ms      |

## Download
**[Eval-SQL.NET-Install.sql](https://github.com/zzzprojects/Eval-SQL.NET/releases)**

_Minimum Requirements:_
- SQL 2012 / SQL Azure v12
- SAFE Permission (SQL CLR)

Stay updated with latest changes

<a href="https://twitter.com/zzzprojects" target="_blank"><img src="http://www.zzzprojects.com/images/twitter_follow.png" alt="Twitter Follow" height="24" /></a>
<a href="https://www.facebook.com/zzzprojects/" target="_blank"><img src="http://www.zzzprojects.com/images/facebook_like.png" alt="Facebook Like" height="24" /></a>

## Regular Expression - Split text with delimiters

##### Problem
You need to split a text with delimiter and need a flexible and scalable solution which allow multiple delimiters and perform with millions rows.

##### Solution
The Regex.Split function allow to use a regular expression to split a text which make it the most extensible solution.

```
-- CREATE test
DECLARE @t TABLE (Id INT , Input VARCHAR(MAX))
INSERT  INTO @t VALUES  ( 1, '1, 2, 3; 4; 5' ), ( 2, '6;7,8;9,10' )

-- SPLIT with many delimiters: ',' and ';'
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Split(input, ",|;")')

SELECT  *
FROM    @t AS A
        CROSS APPLY ( SELECT    *
                      FROM      dbo.SQLNET_EvalTVF_1(@sqlnet.ValueString('input', Input))
                    ) AS B
```

##### Capability
Regex allow to resolve all case unsupported by “LIKE” and “PATHINDEX”. You can easily validate email or website url using regular expression.

## Arithmetic Expression - Evaluate dynamic expression

##### Problem
You need a fast and flexible solution to support custom report fields and filters.

##### Solution
Evalute C# expression in SELECT statement and WHERE clause. The compiler honor operators precedence and parenthesis.

```csharp
-- CREATE test
DECLARE @table TABLE ( X INT, Y INT, Z INT )
INSERT  INTO @table VALUES  ( 2, 4, 6 ),  ( 3, 5, 7 ), ( 4, 6, 8 )

-- Result: 14, 22, 32
DECLARE @sqlnet SQLNET = SQLNET::New('x*y+z')
SELECT  @sqlnet.ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z)
               .EvalInt()
FROM    @table
```

##### Flexibility
Use C# language and features to build your expression
- C# Operators
- C# Keywords
- C# Objects
- Anonymous Type
- LINQ
- Etc.

## File Operation - Use FileInfo and DirectoryInfo
##### Problem
You need to read/write files and need a readable, maintenable and secure solution without enabling xp_cmdshell.

##### Solution
Use well-known and documented C# object to read and write your files and improve your server security by impersonating the current user context.

```csharp
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*")
          .Select(x => new { x.FullName, FileContent = File.ReadAllText(x.FullName) })
          .OrderBy(x => x.FullName)')
          .Impersonate()

-- SELECT FullName, FileContext FROM DesktopFiles ORDER BY Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
```

##### Security
Stop compromising your SQL Server with **HIGH security risk** procedure like xp_cmdshell which has no restriction and can execute bat/cmd script. 

Use a **more restrictive** solution with Eval SQL.NET and [EXTERNAL_ACCESS](https://msdn.microsoft.com/library/ms345101.aspx) permission which limit what the user can do.

## FREE vs PRO

Features | FREE Version | **[PRO Version](http://eval-sql.net/#pro)**
------------ | :-------------: | :-------------:
Maximum Characters | 50 | Unlimited
Commercial License | No | Yes
Support & Upgrades (1 year) | No | Yes

Learn more about the **[PRO Version](http://eval-sql.net/#pro)**

## Contribute
The best way to contribute is by **spreading the word** about the library:

 - Blog it
 - Comment it
 - Fork it
 - Star it
 - Share it
 
A **HUGE THANKS** for your help.

## More Projects

**Entity Framework**
- [EntityFramework Extensions](http://entityframework-extensions.net/)
- [EntityFramework Plus](http://entityframework-plus.net)

**Bulk Operations**
- [Bulk Operations](http://bulk-operations.net/)

**Expression Evaluator**
- [Eval-SQL.NET](http://eval-sql.net/)
- [Eval-Expression.NET](http://eval-expression.net/)

**Others**
- [Extension Methods Library](https://github.com/zzzprojects/Z.ExtensionMethods/)
- [LINQ Async](https://github.com/zzzprojects/Linq-AsyncExtensions)

**Need more info?** info@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!
