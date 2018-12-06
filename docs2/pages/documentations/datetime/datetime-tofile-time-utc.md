# DateTime_ToFileTimeUtc

`DateTime_ToFileTimeUtc` converts the value of the `currDate` DateTime object to a Windows file time.

```csharp
DateTime_ToFileTimeUtc (
	@currDate DATETIME
	)
RETURNS BIGINT
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

The value of the `currDate` DateTime object expressed as a Windows file time.

## Example

```csharp
DECLARE @var BIGINT
SELECT @var = SQLNET::DateTime_ToFileTimeUtc('2015-5-25')
SELECT SQLNET::DateTime_FromFileTimeUtc(@var)
```

