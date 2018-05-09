# Eval

## Eval

Evaluate the code or expression and return the result.

 - Eval
 - EvalBigInt
 - EvalBinary
 - EvalBit
 - EvalDateTime
 - EvalInt
 - EvalSmallInt
 - EvalString
 - EvalTinyInt
 - EvalUniqueIdentifier
 - EvalVarBinary


```csharp
DECLARE @sqlnet SQLNET = SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).Root();

DECLARE @value_variant SQL_VARIANT = @sqlnet.Eval();
DECLARE @value_int INT = @sqlnet.EvalInt();
DECLARE @value_decimal DECIMAL(18, 2) = CAST(@sqlnet.Eval() AS DECIMAL(18, 2))

-- SELECT 3, 3, 3.00
SELECT @value_variant as variant , @value_int as int, @value_decimal as decimal
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/58568/15' %}

## EvalReadAccess

Evaluate the code or expression allowing "Read" and return the result.

 - EvalReadAccess
 - EvalReadAccessBigInt
 - EvalReadAccessBinary
 - EvalReadAccessBit
 - EvalReadAccessDateTime
 - EvalReadAccessInt
 - EvalReadAccessSmallInt
 - EvalReadAccessString
 - EvalReadAccessTinyInt
 - EvalReadAccessUniqueIdentifier
 - EvalReadAccessVarBinary

## EvalSQLNET

Evaluate the code or expression and return a new SQLNET object with the result in the parameter name "value"


```csharp
-- Eval and create a new SQLNET object
DECLARE @sqlnet SQLNET = SQLNET::New('var list = new List<int>() { 1, 2, 3, 4}')
DECLARE @result SQLNET = @sqlnet.EvalSQLNET()

-- Use the value previously resolved
-- SELECT 4
SELECT @result.Code('value.Count').EvalInt()  as Result
Useful to optimize code with object initialization like Regex.
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/989' %}

## EXEC SQLNET_EvalResultSet

Stored Procedures that evaluate code or expression and return a Result Set.


```csharp
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
    .Impersonate()

-- SELECT * FROM DesktopFiles ORDER BY File.Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
You can output the result to the client or insert it in a table like a normal procedure.
```


## EvalTVF

Evaluate the code or expression from a Table-Valued Function (TVF).

 - SQLNET_EvalTVF_1 (SQL_VARIANT)
 - SQLNET_EvalTVF_2 (SQL_VARIANT, SQL_VARIANT)
 - SQLNET_EvalTVF_3 (SQL_VARIANT, SQL_VARIANT, SQL_VARIANT)
 - SQLNET_EvalTVF_4 (SQL_VARIANT, SQL_VARIANT, SQL_VARIANT, SQL_VARIANT)
 - SQLNET_EvalTVF_5 (SQL_VARIANT, ..., SQL_VARIANT)
 - SQLNET_EvalTVF_String


```csharp
CREATE FUNCTION [dbo].[fn_Split]
    (
      @input VARCHAR(MAX) ,
      @pattern VARCHAR(8000) = ','
    )
RETURNS @split TABLE ( item VARCHAR(8000) )
    BEGIN
        DECLARE @regex_split SQLNET = SQLNET::New('Regex.Split(input, pattern)')
                                             .ValueString('input', @input)
                                             .ValueString('pattern', @pattern)

        INSERT  INTO @split
                SELECT  CAST(Value_1 AS VARCHAR(8000))
                FROM    [dbo].[SQLNET_EvalTVF_1](@regex_split)
        RETURN
    END

GO

-- SPLIT with multiple delimiters (',' and ';')
SELECT * FROM dbo.fn_Split('1, 2, 3; 4; 5', ',|;')
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/b738f/2' %}
