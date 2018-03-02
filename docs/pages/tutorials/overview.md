---
permalink: overview
---

## Definition


**Eval SQL.NET** is a library that allow to evaluate dynamically C# expression directly in T-SQL. You never used Eval SQL.NET? Don't worry, this step-by-step walkthrough will help you to understand the library.

Provide to your SQL Server all missing pieces like regular expression and dynamic arithmetic string evaluation.

<div class="sqlfiddle">
                <pre class="schema">
                </pre>
                <pre class="sql">
SELECT  SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt() as Result
                </pre>
</div>

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

<div class="sqlfiddle">
                <pre class="schema">
CREATE TABLE tableValue  ( X INT, Y INT, Z INT )
INSERT  INTO tableValue VALUES  ( 2, 4, 6 ),  ( 3, 5, 7 ), ( 4, 6, 8 )
                </pre>
                <pre class="sql">
-- Result: 14, 22, 32
DECLARE @sqlnet SQLNET = SQLNET::New('x*y+z')
SELECT  @sqlnet.ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z)
               .EvalInt() as Result
FROM    tableValue
                </pre>
</div>

## Split text with delimiter

Improve performance and capability for splitting text with an easy to use split function and LINQ expression

- Split text with multiple delimiters
- Split text using a regular expression
- Include row index

<div class="sqlfiddle">
                <pre class="schema">
-- CREATE test
CREATE TABLE t (Id INT , Input VARCHAR(MAX))
INSERT  INTO t VALUES  ( 1, '1, 2, 3; 4; 5' ), ( 2, '6;7,8;9,10' )
                </pre>
                <pre class="sql">
-- SPLIT with many delimiters: ',' and ';'
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Split(input, ",|;")')

SELECT  *
FROM    t AS A
        CROSS APPLY ( SELECT    *
                      FROM      dbo.SQLNET_EvalTVF_1(@sqlnet.ValueString('input', Input))
                    ) AS B
                </pre>
</div>

## Use regular expression in SQL Server

Use Regex flexibility to overcome "LIKE" and "PATHINDEX" limitations.

 - IsMatch
 - Match
 - Matches
 - Replace
 - Split
 
<div class="sqlfiddle">
                <pre class="schema">
Create Table customer ( Email VARCHAR(255) )

INSERT  INTO customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )
                </pre>
                <pre class="sql">
DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, 
@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")')

-- SELECT 'invalid.com'
SELECT * FROM customer WHERE @valid_email.ValueString('email', Email).EvalBit() = 0
                </pre>
</div>

## Replace xp_cmdshell with restrictive alternative

Avoid enabling xp_cmdshell and compromising your SQL Server and use instead a more restrictive solution.

 - Impersonate Context
 - Improve maintainability
 - Improve readability
 - Improve security

{% include template-example.html title='Example' %} 
{% highlight csharp %}
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
{% endhighlight %}

## Contribute

The best way to contribute is by spreading the word about the library:

 - Blog it
 - Comment it
 - Fork it
 - Star it
 - Share it
 - A **HUGE THANKS** for your help.
