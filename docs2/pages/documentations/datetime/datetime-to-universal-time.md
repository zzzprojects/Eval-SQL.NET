# DateTime_ToUniversalTime

`DateTime_ToUniversalTime` converts the value of the `currDate` DateTime object to Coordinated Universal Time (UTC) time.

```csharp
DateTime_ToUniversalTime (
	@currDate DATETIME
	)
RETURNS BIGINT
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A DateTime object in Coordinated Universal Time (UTC) time equivalent to the value of the current DateTime object, or `MaxValue` if the converted value is too large to be represented by a DateTime object, or `MinValue` if the converted value is too small to be represented as a DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToUniversalTime('2015-5-25')
```

