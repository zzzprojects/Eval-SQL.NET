# DateTime_FromFileTimeUtc

`DateTime_FromFileTimeUtc` converts the specified Windows file time to an equivalent UTC time.

```csharp
DateTime_FromFileTimeUtc (
	@fileTime BIGINT
	)
RETURNS DATETIME
```

## Parameters

 - **fileTime**: A Windows file time expressed in ticks.

## Returns

An object that represents the UTC time equivalent of the date and time represented by the `fileTime` parameter.

## Example

```csharp
DECLARE @var BIGINT
SELECT @var = SQLNET::DateTime_ToFileTimeUtc('2017-7-23')
SELECT SQLNET::DateTime_FromFileTimeUtc(@var)
```

