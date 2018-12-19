# Value

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


```csharp
-- SELECT 3
SELECT SQLNET::New('x+1').ValueInt('x', 2).EvalInt() as Result

-- SELECT 3
SELECT SQLNET::New('x+1').ValueInt('x', 2).EvalInt() as Result

-- SELECT 1
SELECT SQLNET::New('x.Length').ValueBinary('x', 0x11).Eval() as Result

-- SELECT 'ZZZ Projects'
SELECT SQLNET::New('"ZZZ " + x').ValueString('x', 'Projects').Eval() as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/009cc/2' %}

> For maximum performance, the right Value[Type] should always be used over Val && Value

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


```csharp
DECLARE @x1 INT = NULL;
DECLARE @x2 INT = 2;

DECLARE @sqlnet SQLNET = SQLNET::New('x.HasValue ? x.Value + 1 : 0');

-- SELECT 0
SELECT @sqlnet.ValueNullableInt('x', @x1).EvalInt() as Result

-- SELECT 3
SELECT @sqlnet.ValueNullableInt('x', @x2).EvalInt() as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/1cdb6/5' %}

## ValueSQLNET

Add or update a value associated with the specified key. The parameter "value" from the previously resolved expression is used.


```csharp
DECLARE @sqlnet SQLNET = SQLNET::New('var list = new List<int>() { 1, 2, 3, 4}')
DECLARE @result SQLNET = @sqlnet.EvalSQLNET()

-- SELECT 4
SELECT SQLNET::New('x.Count').ValueSQLNET('x', @result).Eval()  AS Result 

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/3149e/2' %}

## GetValue

Gets the value associated with the specified key.

 - GetValue(string key)
 - GetValueBigInt(string key)
 - GetValueBit(string key)
 - GetValueInt(string key)
 - GetValueSmallInt(string key)
 - GetValueString(string key)
 - GetValueTinyInt(string key)


```csharp
-- SELECT 1
SELECT SQLNET::New('x + 1').Val('x', 1).GetValue('x') as Result

-- SELECT 1
SELECT SQLNET::New('x + 1').Val('x', 1).GetValueBigInt('x') as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/3149e/6' %}
