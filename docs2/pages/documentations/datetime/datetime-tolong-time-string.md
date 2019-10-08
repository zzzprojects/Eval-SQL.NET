# DateTime_ToLongTimeString

`DateTime_ToLongTimeString` converts the value of the current DateTime object to its equivalent long time string representation.

```csharp
DateTime_ToLongTimeString (
	@currDate DATETIME
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A string that contains the long time string representation of the current DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToLongTimeString('2015-5-25 3:02:15 AM')
```

-