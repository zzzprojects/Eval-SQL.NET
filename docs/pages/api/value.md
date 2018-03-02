---
permalink: value
---

## Value

Add or update a value associated with the specified key.

 - Val\Value (SQL_Variant)
 - ValueBigInt
 - ValueBinary
 - ValueBoolean
 - ValueByte
 - ValueBytes
 - ValueChars
 - ValueDateTime
 - ValueGuid
 - ValueInt
 - ValueString
 - ValueTinyInt
 - ValueXml

<div class="sqlfiddle">
                <pre class="schema">
CREATE TABLE tableSqlnets
(
    codeInt1 SQLNET,
    codeInt2 SQLNET,
    codeBinary SQLNET,
    codeString SQLNET
)
INSERT INTO dbo.tableSqlnets
(
    codeInt1,
    codeInt2,
    codeBinary,
    codeString
)
VALUES
(SQLNET::New('x+1').ValueInt('x', 2).ROOT(), SQLNET::New('x+1').ValueInt('x', 2).ROOT(),
 SQLNET::New('x.Length').ValueBinary('x', 0x11).ROOT(), SQLNET::New('"ZZZ " + x').ValueString('x', 'Projects').ROOT())
                </pre>
                <pre class="sql">
SELECT codeInt1.EvalInt() AS ResultInt1,
       codeInt2.EvalInt() AS ResultInt2,
       codeBinary.Eval() AS ResultBinary,
       codeString.Eval() AS ResultString
FROM dbo.tableSqlnets
                </pre>
</div>

For maximum performance, the right Value[Type] should be always used over Val && Value

## ValueNullable

 - Val\Value (require to specify the type in the key "int? x")
 - ValueBigInt
 - ValueBoolean
 - ValueByte
 - ValueBytes
 - ValueDateTime
 - ValueGuid
 - ValueInt
 - ValueTinyInt

{% include template-example.html %} 
{% highlight csharp %}
DECLARE @x1 INT = NULL;
DECLARE @x2 INT = 2;

DECLARE @sqlnet SQLNET = SQLNET::New('x.HasValue ? x.Value + 1 : 0');

-- SELECT 0
SELECT @sqlnet.ValueNullableInt('x', @x1).EvalInt() as Result

-- SELECT 3
SELECT @sqlnet.ValueNullableInt('x', @x2).EvalInt() as Result

{% endhighlight %}
{% include component-try-it.html href='http://sqlfiddle.com/#!18/1cdb6/5' %}
<div class="sqlfiddle">
                <pre class="schema">
CREATE TABLE tableSqlnet  (code1 SQLNET, code2 SQLNET)
INSERT INTO dbo.tableSqlnet ( code1, code2 )  VALUES (SQLNET::New('x.HasValue ? x.Value + 1 : 0').ROOT()
                                                      ,SQLNET::New('x.HasValue ? x.Value + 1 : 0').ROOT())
                </pre>
                <pre class="sql">
DECLARE @x1 INT = NULL
DECLARE @x2 INT = 2

select
-- SELECT 0 
code1.ValueNullableInt('x', @x1).EvalInt() as Result,
-- SELECT 3 
code2.ValueNullableInt('x', @x2).EvalInt() as Result  from tableSqlnet
                </pre>
</div>


## ValueSQLNET

Add or update a value associated with the specified key. The parameter "value" from the previously resolved expression is used.

<div class="sqlfiddle">
                <pre class="schema">
                </pre>
                <pre class="sql">
DECLARE @sqlnet SQLNET = SQLNET::New('var list = new List<int>() { 1, 2, 3, 4}')
DECLARE @result SQLNET = @sqlnet.EvalSQLNET()

-- SELECT 4
SELECT SQLNET::New('x.Count').ValueSQLNET('x', @result).Eval()  AS Result 
                </pre>
</div>


## GetValue

Gets the value associated with the specified key.

 - GetValue(string key)
 - GetValueBigInt(string key)
 - GetValueBit(string key)
 - GetValueInt(string key)
 - GetValueSmallInt(string key)
 - GetValueString(string key)
 - GetValueTinyInt(string key)

<div class="sqlfiddle">
                <pre class="schema">
                </pre>
                <pre class="sql">
SELECT
-- SELECT 1
SQLNET::New('x + 1').Val('x', 1).GetValue('x') as Result1,
-- SELECT 1
SQLNET::New('x + 1').Val('x', 1).GetValueBigInt('x') as Result2
                </pre>
</div>
