---
permalink: options
---

## AutoDispose()

AutoDispose object and delegate from the cache after the code has been evaluated.

{% include template-example.html %} 
{% highlight csharp %}
-- SELECT 3
SELECT SQLNET::New('1+2').AutoDispose().EvalInt()

{% endhighlight %}

Don't worry, we have you covered! Object and Delegate are automatically disposed after a period of time without activity.

## Code(string code)

Sets the code or expression to evaluate.

DECLARE @sqlnet SQLNET = SQLNET::New('')

{% include template-example.html %} 
{% highlight csharp %}
-- SELECT 3
SELECT @sqlnet.Code('1+2').EvalInt()

{% endhighlight %}

## Dispose()

Dispose object and delegate from the cache

{% include template-example.html %} 
{% highlight csharp %}
DECLARE @sqlnet SQLNET = SQLNET::New('x + y')

SELECT  @sqlnet
    .ValueInt('x', ColumnValueX)
    .ValueInt('y', ColumnValueY)
    .EvalInt()
FROM TableFormula

DECLARE @dispose BIT = @sqlnet.Dispose()

{% endhighlight %}

Don't worry, we have you covered! Object and Delegate are automatically disposed after a period of time without activity.

## Impersonate()

Change the security context to impersonate the credential of the one who runs the T-SQL statements.

{% include template-example.html %} 
{% highlight csharp %}
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
    .Impersonate()

-- SELECT * FROM DesktopFiles ORDER BY File.Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet

{% endhighlight %}

Impersonate the current execution context under which the routine is executing.

## Root()

Root is required when the expression already specified value. This feature has been added to allow Parallelism.

{% include template-example.html %} 
{% highlight csharp %}
DECLARE @sqlnet SQLNET = SQLNET::New('x+y').ValueInt('y', 2).Root()

-- SELECT 3
SELECT @sqlnet.ValueInt('x', 1).EvalInt()

{% endhighlight %}
