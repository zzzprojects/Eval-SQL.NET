# DateTime_DayOfWeek

`DateTime_DayOfWeek` returns the day of the week represented by `currDate`.

```csharp
DateTime_DayOfWeek (
	@currDate DATETIME,
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

The day of the week represented by `currDate`.

## Example

```csharp
SELECT SQLNET::DateTime_DayOfWeek('2018-12-01')
```

