Provide to your SQL Server all missing pieces like regular expression and dynamic arithmetic string evaluation.

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

_* PRO Version unlocked for the current month_

_Minimum Requirements:_
- SQL 2012 / SQL Azure v12
- SAFE Permission (SQL CLR)

Stay updated with latest changes

<a href="https://twitter.com/zzzprojects" target="_blank"><img src="http://www.zzzprojects.com/images/twitter_follow.png" alt="Twitter Follow" height="24" /></a>
<a href="https://www.facebook.com/zzzprojects/" target="_blank"><img src="http://www.zzzprojects.com/images/facebook_like.png" alt="Facebook Like" height="24" /></a>

## Evaluate dynamic arithmetic/math expression in SQL
_Make the impossible now possible. Evaluate C# expression in SQL to overcome limitations._

- Allow trusted users to create report field and filter
- Consume Web Service
- Replace text in template with String Interpolation

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

## Replace xp_cmdshell with restrictive alternative
_Avoid enabling xp_cmdshell and compromising your SQL Server and use instead a more restrictive solution._
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
- [Dapper Plus](http://dapper-plus.net/)

**Expression Evaluator**
- [Eval-SQL.NET](http://eval-sql.net/)
- [Eval-Expression.NET](http://eval-expression.net/)

**Others**
- [Extension Methods Library](https://github.com/zzzprojects/Z.ExtensionMethods/)
- [LINQ Async](https://github.com/zzzprojects/Linq-AsyncExtensions)

**Need more info?** info@zzzprojects.com

Contact our outstanding customer support for any request. We usually answer within the next business day, hour, or minutes!
