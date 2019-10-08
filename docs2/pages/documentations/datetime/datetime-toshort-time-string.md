# DateTime_ToShortTimeString

`DateTime_ToShortTimeString` converts the value of the current DateTime object to its equivalent short time string representation.

```csharp
DateTime_ToShortTimeString (
	@currDate DATETIME
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A string that contains the short time string representation of the current DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToShortTimeString('2015-5-25 3:02:15 AM')
```

-