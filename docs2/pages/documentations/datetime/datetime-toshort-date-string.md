# DateTime_ToShortDateString

`DateTime_ToShortDateString` converts the value of the current DateTime object to its equivalent short date string representation.

```csharp
DateTime_ToShortDateString (
	@currDate DATETIME
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A string that contains the short date string representation of the current DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToShortDateString('2015-5-25 3:02:15 AM')
```

