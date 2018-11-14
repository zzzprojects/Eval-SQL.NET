# Configuration

## Configuration

Optional stored procedure for License and Configuration



```csharp

CREATE PROCEDURE SQLNET_GlobalConfiguration
AS
BEGIN
    -- The procedure is automatically called when the server restart/assembly load
    -- If the assembly is already loaded, a manual execution is required
    -- EXEC SQLNET_Configuration
	DECLARE @isValid BIT = SQLNET::AddLicense('[LicenseName]', '[LicenseKey]')

	-- SELECT 1
	SELECT @isValid

	-- SELECT 1
    SELECT SQLNET::New('
EvalManager.Configuration.RegisterAlias("MyMath", "Math");
EvalManager.Configuration.ExpireCacheDelay = TimeSpan.FromMinutes(5);
EvalManager.Configuration.SlidingExpirationDelegate = TimeSpan.FromHours(3);
EvalManager.Configuration.SlidingExpirationItem = TimeSpan.FromMinutes(1);
return true;
').Eval()

END
```

## Configuration Register & Unregister

Register or unregister information used by the EvalContext under which the code or expression is compiled.

 - RegisterAlias(string alias, string name)
 - RegisterAssembly(param Assembly[])
 - RegisterDomainAssemblies()
 - RegisterExtensionMethod(param Type[])
 - RegisterExtensionMethod(param MethodInfo[])
 - RegisterGlobalConstant(string key, object value)
 - RegisterGlobalVariable(string key, object value)
 - RegisterStaticMember(param Type[])
 - RegisterStaticMember(param MemberInfo[])
 - RegisterType(param Type[])

[EvalContext - Register & Unregister](https://github.com/zzzprojects/Eval-Expression.NET/wiki/EvalContext-Register-&-Unregister)

## Configuration Options

Change option used by the EvalContext under which the code or expression is compiled.

 - BindingFlags
 - UseCaretForExponent

[EvalContext - Options](https://github.com/zzzprojects/Eval-Expression.NET/wiki/EvalContext-Options)

## Configuration.ExpireCacheDelay

Sets a span of time within the next time the ExpireCache method is invoked to evict inactive cache item.

## Configuration.SlidingExpirationDelegate

Sets a span of time within which a delegate must be accessed before it is evicted from the cache.

## Configuration.SlidingExpirationItem

Sets a span of time within which an item must be accessed before it is evicted from the cache.

