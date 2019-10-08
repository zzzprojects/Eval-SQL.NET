# DateTime_ToStringWithFormat

`DateTime_ToStringWithFormat` converts the value of the current DateTime object to its equivalent string representation using the specified format and the formatting conventions of the current culture.

```csharp
DateTime_ToStringWithFormat (
	@currDate DATETIME,
	@format NVARCHAR (MAX))
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.
 - **format**: A standard or custom date and time format string.

## Returns

A string representation of value of the current DateTime object as specified by `format`.

## Example

```csharp
SELECT SQLNET::DateTime_ToStringWithFormat('2015-5-25 3:02:15 AM', 'dd MMM HH:mm:ss')
```

