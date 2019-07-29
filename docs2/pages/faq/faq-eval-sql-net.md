# FAQ - Eval SQL.NET

## Bug Fixing

You found a bug when compiling? [Report it](https://github.com/zzzprojects/Eval-SQL.NET/issues) and it will be fixed, usually within one business day.

## Namespace

All namespace support by SQL CLR are supported by Eval SQL.NET.

[Supported .NET Framework Libraries](https://msdn.microsoft.com/en-us/library/ms403279.aspx)

 - CustomMarshalers
 - Microsoft.VisualBasic
 - Microsoft.VisualC
 - mscorlib
 - System
 - System.Configuration
 - System.Data
 - System.Data.OracleClient
 - System.Data.SqlXml
 - System.Deployment
 - System.Security
 - System.Transactions
 - System.Web.Services
 - System.Xml
 - System.Core.dll
 - System.Xml.Linq.dll
 - All common namespaces and extension methods can be used without specifying the fullname.

You can see the full list [here](https://github.com/zzzprojects/Eval-SQL.NET/blob/master/src/Z.Expressions.SqlServer.Eval/EvalContext/EvalContext.RegisterDefaultAlias.cs)

Let us know if you believe we missed some.

## Performance

You are worried about performance? Don't worry, Eval SQL.NET is super-fast and can evaluate over 150,000 expressions in a loop under one second and over 1,000,000 using a table!

Result highly vary depending of your SQL Server performance and expressions to evaluate.


```csharp

DECLARE @startTime DATETIME,
@endTime DATETIME

DECLARE @I INT = -1
DECLARE @sqlnet SQLNET = SQLNET::New('i + 1')
-- LET Compile the expression to check the compiled performance
SET @I = @sqlnet.Val('i', @I).EvalInt()

SET @startTime = GETDATE()

WHILE @I < 125000
    BEGIN
        SET @I = @sqlnet.ValueInt('i', @I).EvalInt()
    END

SET @endTime = GETDATE()
PRINT 'StartTime = ' + CONVERT(VARCHAR(30), @startTime, 121)
PRINT 'EndTime = ' + CONVERT(VARCHAR(30), @endTime, 121)
PRINT 'Duration = ' + CONVERT(VARCHAR(30), @endTime - @starttime, 114)

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/3149e/10' %}

## Security

SQL CLR allows three types of permissions:

 - SAFE
 - EXTERNAL_ACCESS
 - UNSAFE Eval SQL.NET supports all types and is installed by default with SAFE permissions. Read more about [SQL CLR Permissions](https://msdn.microsoft.com/en-CA/library/ms345101.aspx)

## SQL Injection

This library allows to use parameter, so no SQL Injection is possible!

However, if you build the string to evaluate as you build a dynamic SQL, then there is nothing we can do for you.

## Decimal throw an error!

In C#, decimals must be suffixed with "m" to make them valid. By default "1.1" in C# is a double which cannot be added with decimal value.


```csharp

// Trow exception
SELECT SQLNET::New('(x)+1.1234').Val('x', 1.1).Eval() as Result

-- SELECT 2.2234
SELECT SQLNET::New('(x)+1.1234m').Val('x', 1.1).Eval() as Result
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/3149e/11' %}
