# Options

## AutoDispose()

AutoDispose object and delegate from the cache after the code has been evaluated.


```csharp
-- SELECT 3
SELECT SQLNET::New('1+2').AutoDispose().EvalInt() as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/994' %}

Don't worry, we have you covered! Object and Delegate are automatically disposed after a period of time without activity.

## Code(string code)

Sets the code or expression to evaluate.

DECLARE @sqlnet SQLNET = SQLNET::New('')


```csharp
DECLARE @sqlnet SQLNET = SQLNET::New('')

-- SELECT 3
SELECT @sqlnet.Code('1+2').EvalInt() as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1125' %}

## Dispose()

Dispose object and delegate from the cache


```csharp
DECLARE @sqlnet SQLNET = SQLNET::New('x + y')

SELECT  @sqlnet
    .ValueInt('x', 1)
    .ValueInt('y', 2)
    .EvalInt() as Result


SELECT  @sqlnet.getcode() as Result

DECLARE @dispose BIT = @sqlnet.Dispose()

--Not work because dipose...
SELECT  @sqlnet
    .ValueInt('x', 1)
    .ValueInt('y', 2)
    .EvalInt() as Result


--Not work because dipose...
SELECT  @sqlnet.getcode() as Result
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/996' %}

Don't worry, we have you covered! Object and Delegate are automatically disposed after a period of time without activity.

## Impersonate()

Change the security context to impersonate the credential of the one who runs the T-SQL statements.


```csharp
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
    .Impersonate()

-- SELECT * FROM DesktopFiles ORDER BY File.Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet

```


Impersonate the current execution context under which the routine is executing.

## Root()

Root is required when the expression already specified value. This feature has been added to allow Parallelism.


```csharp
DECLARE @sqlnet SQLNET = SQLNET::New('x+y').ValueInt('y', 2).Root()

-- SELECT 3
SELECT @sqlnet.ValueInt('x', 1).EvalInt()  as Result

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/997' %}
