---
permalink: arithmetic-expressions
---

## Definition
An arithmetic expression is an expression that results in a numeric value. Try these examples to see how easy is to resolve an arithmetic expression.

Eval SQL.NET is a complete C# runtime compiler which honor operator precedence and parenthesis.

### Using formula & variables



{% include template-example.html %} 
{% highlight csharp %}
DECLARE @x INT = 2
DECLARE @y INT = 4
DECLARE @z INT = 6

DECLARE @result INT

SET @result = SQLNET::New('x*y+z')
                     .ValueInt('x', @x)
                     .ValueInt('y', @y)
                     .ValueInt('z', @z)
                     .EvalInt()  

-- SELECT 14
SELECT  @result as Result
{% endhighlight %}

### Using formula & table variables

{% include template-example.html %} 
{% highlight csharp %}

DECLARE @table TABLE ( X INT, Y INT, Z INT )

INSERT  INTO @table
VALUES  ( 2, 4, 6 ),
        ( 3, 5, 7 ),
        ( 4, 6, 8 )

-- 14
-- 22
-- 32
DECLARE @sqlnet SQLNET = SQLNET::New('x*y+z')
SELECT  @sqlnet.ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z)
               .EvalInt() as Result
FROM    @table

{% endhighlight %}

### Using table formula & variables

{% include template-example.html %} 
{% highlight csharp %}

DECLARE @table TABLE
    (
      Formula VARCHAR(50) ,
      X INT ,
      Y INT ,
      Z INT
    )

INSERT  INTO @table
VALUES  ( 'x*y+z', 2, 4, 6 ),
        ( 'x+y*z', 2, 4, 6 ),
        ( '(x+y)*z', 2, 4, 6 )

-- 14
-- 26
-- 36
DECLARE @sqlnet SQLNET = SQLNET::New('')
SELECT  @sqlnet.Code(Formula)
               .ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z).EvalInt() as Result
FROM    @table
{% endhighlight %}
