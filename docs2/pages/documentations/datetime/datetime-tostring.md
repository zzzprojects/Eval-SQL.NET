# DateTime_ToString

`DateTime_ToString` converts the value of the current DateTime object to its equivalent string representation.

```csharp
DateTime_ToString (
	@currDate DATETIME
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A string representation of the value of the current DateTime object.

## Example

```csharp
SELECT SQLNET::DateTime_ToString('2015-5-25 3:02:15 AM')
```

