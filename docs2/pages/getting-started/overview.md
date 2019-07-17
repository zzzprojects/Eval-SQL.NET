# Overview

## Definition

**Eval SQL.NET** is a library that allows to evaluate dynamically C# expression directly in T-SQL. You never used Eval SQL.NET? Don't worry, this step-by-step walkthrough will help you understand the library.

Provide to your SQL Server all missing pieces like regular expression and dynamic arithmetic string evaluation.


```csharp
-- SELECT 3
SELECT  SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt() as Result
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1105' %}

## Installing
Download the <a href="/download">SQLNET.zip</a>

### SQL Server 2017 - prerequisite
1. Open the script SQLNET-Cert.sql
2. Run the script
3. Continue the install with next step

### SQL Server 2008 or higher
1. Open the script SQLNET-Install.sql
2. Replace '[DATABASE_NAME]' with your database name
3. Run the script

### Note
- For EXTERNAL_ACCESS PERMISSION
	- Uncomment "ALTER DATABASE [DATABASE_NAME] SET TRUSTWORTHY ON"
	- Uncomment "WITH PERMISSION_SET = EXTERNAL_ACCESS"
	- Comment "WITH PERMISSION_SET = SAFE"
	
- For UNSAFE PERMISSION
	- Uncomment "ALTER DATABASE [DATABASE_NAME] SET TRUSTWORTHY ON"
	- Uncomment "WITH PERMISSION_SET = UNSAFE"
	- Comment "WITH PERMISSION_SET = SAFE"

## Requirements

### Minimus Requirements

- SQL Server 2012+
- SAFE Permission (SQL CLR)

### Find your solutions:

 - Dynamic Arithmetic Expression
 - Dynamic Pivot Table
 - Regular Expression
 - String Interpolation
 - Replace xp_cmdshell with DirectoryInfo & FileInfo

## Performance & Scalability

Performance tuning is one of the most important task for a DBA. Don't miss the chance to **dramatically improve query performance** by **300%** for simple expression and by more than **2000%** for complex code over User-Defined Function (UDF) and Table-Valued Function (TVF).

| Methods         | 1,000 rows     | 10,000 rows    | 100,000 rows   | 1,000,000 rows |
| :-------------- | -------------: | -------------: | -------------: | -------------: |
| Eval-SQL.NET    | 4 ms           | 13 ms          | 160 ms         | 1,650 ms       |
| fn_split (TVF)  | 100 ms         | 625 ms         | 5,500 ms       | 55,000 ms      |

*Benchmark to split string with delimiters in SQL*

## Evaluate dynamic arithmetic/math expression in SQL

Make the impossible now possible. Evaluate C# expression in SQL to overcome limitations.

- Allow trusted users to create report field and filter
- Consume Web Service
- Replace text in template with String Interpolation

### Dynamic Expression Example
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
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9bc9b/1' %}

## Split text with delimiter

Improve performance and capability for splitting text with an easy to use split function and LINQ expression

- Split text with multiple delimiters
- Split text using a regular expression
- Include row index


### Split Text Example
```csharp
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
{% include component-try-it.html href='http://sqlfiddle.com/#!18/98a4b/1' %}

## Use regular expression in SQL Server

Use Regex flexibility to overcome "LIKE" and "PATINDEX" limitations.

 - IsMatch
 - Match
 - Matches
 - Replace
 - Split

### Regular Expression Example
```csharp
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
{% include component-try-it.html href='http://sqlfiddle.com/#!18/79508/1' %}

## Replace xp_cmdshell with restrictive alternative

Avoid enabling xp_cmdshell and compromising your SQL Server and use instead a more restrictive solution.

 - Impersonate Context
 - Improve maintainability
 - Improve readability
 - Improve security

### Example
```csharp
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*")
          .Select(x => new { x.FullName, FileContent = File.ReadAllText(x.FullName) })
          .OrderBy(x => x.FullName)')*9*
          .Impersonate()

-- SELECT FullName, FileContext FROM DesktopFiles ORDER BY Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
```

## Contribute

The best way to contribute is by spreading the word about the library:

 - Blog it
 - Comment it
 - Fork it
 - Star it
 - Share it

A **HUGE THANKS** for your help.
