# DateTime_ToLongDateString

`DateTime_ToLongDateString` converts the value of the current DateTime object to its equivalent long date string representation.

```csharp
DateTime_ToLongDateString (
	@currDate DATETIME
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A string that contains the long date string representation of the current DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToLongDateString('2015-5-25 3:02:15 AM')
```

