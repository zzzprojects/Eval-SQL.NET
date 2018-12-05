# DateTime_DayOfYear

`DateTime_DayOfYear` returns day of the year, expressed as a value between 1 and 366 represented by `currDate`.

```csharp
DateTime_DayOfYear (
	@currDate DATETIME,
	)
RETURNS INT
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

The day of the year, expressed as a value between 1 and 366.

## Example

```csharp
SELECT SQLNET::DateTime_DayOfYear('2018-12-01')
SELECT SQLNET::DateTime_DayOfYear('2016-12-31')
```

