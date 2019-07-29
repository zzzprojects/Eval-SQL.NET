# SQL Server Eval

## Introduction

How to evaluate an arithmetic expression in SQL Server is a common subject. There are several reasons why an "Eval" function like JavaScript could be useful in SQL such as evaluating custom report fields for a trusted user.

Multiple partial solutions exist like using "EXEC(Transact-SQL)" which is limited, it cannot be used inside SELECT statement and lead to SQL Injection or using an homemade function which, most of time, fail supporting simple operator priorities and parenthesis.

**SQL Eval.NET** is a complete solution which, not only lets you evaluate dynamic arithmetic expression, but lets you use the full C# language directly in T-SQL stored procedures, functions and triggers.


```csharp
DECLARE @tableFormula TABLE (Formula VARCHAR(255), X INT, Y INT, Z INT)

INSERT  INTO @tableFormula
VALUES  ( 'x+y*z', 1, 2, 3 ),
        ( '(x+y)*z', 1, 2, 3 )

-- Select_0: 7
-- Select_1: 9
SELECT  SQLNET::New(Formula).ValueInt('x', X).ValueInt('y', Y).ValueInt('z', Z).EvalInt() as Result
FROM    @tableFormula
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/2f73a/1' %}

## SQL Eval - Arithmetic / Math Expression

### Problem

You need to evaluate a dynamic arithmetic operation specified by a trusted user or check a dynamic rule.

 - Dynamic report calculation field
 - Dynamic report query filter
 - Dynamic rule validation

### Solution

Eval SQL.NET supports all C# operators including operators precedence and parenthesis.

Evaluating an expression is very fast and scalable. You can see performance 3-20x faster than User-Defined Function (UDF) and you can evaluate an expression as much as ONE MILLION times under a second.


```csharp
DECLARE @items TABLE (Quantity INT, Price MONEY)

INSERT  INTO @items
VALUES  ( 2, 10 ),
        ( 9, 6 ),
        ( 15, 2 ),
        ( 6, 0 ),
        ( 84, 5 )

DECLARE @customColumn SQLNET = SQLNET::New('(quantity * price).ToString("$#.00")')
DECLARE @customFilter SQLNET = SQLNET::New('quantity > 3 && price > 0')

-- Select_0: 9, 6.00, $54.00
-- Select_1: 15, 2.00, $30.00
-- Select_2: 84, 5.00, $420.00
SELECT  * ,
        @customColumn.ValueInt('quantity', Quantity).Val('price', Price).EvalString() as Result
FROM    @items
WHERE   @customFilter.ValueInt('quantity', Quantity).Val('price', Price).EvalBit() = 1
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/4ed27/1' %}

## SQL Eval - Dynamic Expression

### Problem

You need to evaluate and execute a dynamic SQL expression which requires more than basic arithmetic operators.

 - if/else
 - switch/case
 - try/catch

### Solution

Eval SQL.NET is flexible and supports almost all C# keywords and features including:

 - Anonymous Type
 - Generic Type
 - Lambda Expression
 - LINQ


```csharp
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
   ').ValueInt('x', @x).ValueInt('y', @y).ValueInt('z', @z).EvalInt()

        SELECT  @result as Result
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
{% include component-try-it.html href='http://sqlfiddle.com/#!18/6b73d/2' %}

## SQL Eval - Framework class Library

### Problem

You have a complex SQL and you know C# Syntax and C# Object could very easily solve this problem.

 - Regex
 - DirectoryInfo / FileInfo
 - String.Format

### Solution

Eval SQL.NET improves readability and maintainability over complex SQL. It supports all [.NET framework class libraries](https://msdn.microsoft.com/en-us/library/gg145045.aspx) (FCL) that are supported by [SQL CLR Framework Libraries](https://docs.microsoft.com/en-us/sql/relational-databases/clr-integration/database-objects/supported-net-framework-libraries).


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
{% include component-try-it.html href='http://sqlfiddle.com/#!18/ca1ba/2' %}

## Conclusion

Eval SQL.NET can be seen in SQL Server as the function "eval()" equivalent of JavaScript. Unlike common solutions limited to very simple math expressions, Eval SQL.NET features go way beyond:

 - Access to C# Operators
 - Access to C# Keywords
 - Access to C# Objects

Getting better performance than User-Defined Function (UDF) and Table-Valued Function (TVF) is the Icing on the Cake!
