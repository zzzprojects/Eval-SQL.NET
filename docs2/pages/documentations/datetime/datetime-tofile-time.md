# DateTime_ToFileTime

`DateTime_ToFileTime` converts the value of the `currDate` DateTime object to a Windows file time.

```csharp
DateTime_ToFileTime (
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
SELECT @var = SQLNET::DateTime_ToFileTime('2015-5-25')
SELECT SQLNET::DateTime_FromFileTime(@var)
```

