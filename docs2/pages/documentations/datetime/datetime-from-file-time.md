# DateTime_FromFileTime

`DateTime_FromFileTime` converts the specified Windows file time to an equivalent local time.

```csharp
DateTime_FromFileTime (
	@fileTime BIGINT
	)
RETURNS DATETIME
```

## Parameters

 - **fileTime**: A Windows file time expressed in ticks.

## Returns

An object that represents the local time equivalent of the date and time represented by the `fileTime` parameter.

## Example

```csharp
DECLARE @var BIGINT
SELECT @var = SQLNET::DateTime_ToFileTime('2015-5-25')
SELECT SQLNET::DateTime_FromFileTime(@var)
```

