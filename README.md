# What's Eval-SQL.Net?
Eval SQL.NET is a library that allows evaluating C# expression dynamically directly in T-SQL.

It provides to your SQL Server all missing pieces like regular expression and dynamic arithmetic string evaluation.

```sql
-- SELECT 3
SELECT  SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt() as Result
```
**<a href="http://sqlfiddle.com/#!18/9eecb/1105" target="_blank">Try it online</a>** 

**Find your solutions:**
- Dynamic Arithmetic Expression
- Dynamic Pivot Table
- Regular Expression
- String Interpolation
- Replace xp_cmdshell with DirectoryInfo & FileInfo

## Performance & Scalability
Performance tuning is one of the most important tasks for a DBA. Don’t miss the chance to **dramatically improve query performance** by **300%** for simple expression and more than **2000%** for complex code over User-Defined Function (UDF) and Table-Valued Function (TVF).

_Benchmark to split string with delimiters in SQL_

| Methods       | 1,000 rows | 10,000 rows | 100,000 rows | 1,000,000 rows |
| ------------- | ---------: | ----------: | -----------: | -------------: |
|Eval-SQL.NET   | 4 ms       | 13 ms       | 160 ms       | 1,650 ms       |
|fn_split (TVF) | 100 ms     | 625 ms      | 5,500 ms     | 55,000 ms      |

## Download
**[Eval-SQL.NET-Install.sql](https://github.com/zzzprojects/Eval-SQL.NET/releases)**

_* PRO Version unlocked for the current month_

_Minimum Requirements:_
- SQL 2012 / SQL Azure v12
- SAFE Permission (SQL CLR)

## Evaluate dynamic arithmetic/math expression in SQL
_Make the impossible now possible. Evaluate C# expression in SQL to overcome limitations._

- Allow trusted users to create report field and filter
- Consume Web Service
- Replace text in the template with String Interpolation

```csharp
-- CREATE test
DECLARE @table TABLE ( X INT, Y INT, Z INT )
INSERT  INTO @table VALUES  ( 2, 4, 6 ),  ( 3, 5, 7 ), ( 4, 6, 8 )

-- Result: 14, 22, 32
DECLARE @sqlnet SQLNET = SQLNET::New('x*y+z')
SELECT  @sqlnet.ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z)
               .EvalInt() as Result
FROM    @table
```
**<a href="http://sqlfiddle.com/#!18/f3624/2" target="_blank">Try it online</a>** 

## Split text with delimiter
_Improve performance and capability for splitting text with an easy to use split function and LINQ expression_
- Split text with multiple delimiters
- Split text using a regular expression
- Include row index

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
**<a href="http://sqlfiddle.com/#!18/01dcf/1" target="_blank">Try it online</a>** 

## Use regular expression in SQL Server
_Use Regex flexibility to overcome “LIKE” and “PATHINDEX” limitations._
- IsMatch
- Match
- Matches
- Replace
- Split

```sql
DECLARE @customer TABLE ( Email VARCHAR(255) )

INSERT  INTO @customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )

DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, 
@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")')

-- SELECT 'invalid.com'
SELECT * FROM @customer WHERE @valid_email.ValueString('email', Email).EvalBit() = 0
```
**<a href="http://sqlfiddle.com/#!18/92200/2" target="_blank">Try it online</a>** 

## Replace xp_cmdshell with restrictive alternative
_Avoid enabling xp_cmdshell and compromising your SQL Server and use a more restrictive solution instead._
- Impersonate Context
- Improve maintainability
- Improve readability
- Improve security

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

## FREE vs PRO

Features | **[PRO Version](http://eval-sql.net/#pro)**
------------ | :-------------:
Maximum Characters | Unlimited
Commercial License | Yes
Support & Upgrades (1 year) | Yes

Learn more about the **[PRO Version](http://eval-sql.net/#pro)**

## Contribute

The best way to contribute is by **spreading the word** about the library:

 - Blog it
 - Comment it
 - Star it
 - Share it
 
A **HUGE THANKS** for your help.

## More Projects

- Projects:
   - [EntityFramework Extensions](https://entityframework-extensions.net/)
   - [Dapper Plus](https://dapper-plus.net/)
   - [C# Eval Expression](https://eval-expression.net/)
- Learn Websites
   - [Learn EF Core](https://www.learnentityframeworkcore.com/)
   - [Learn Dapper](https://www.learndapper.com/)
- Online Tools:
   - [.NET Fiddle](https://dotnetfiddle.net/)
   - [SQL Fiddle](https://sqlfiddle.com/)
   - [ZZZ Code AI](https://zzzcode.ai/)
- and much more!

To view all our free and paid projects, visit our website [ZZZ Projects](https://zzzprojects.com/).
