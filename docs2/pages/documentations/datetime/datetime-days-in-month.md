# DateTime_DaysInMonth

`DateTime_DaysInMonth` returns day of the year, expressed as a value between 1 and 366 represented by `currDate`.

```csharp
DateTime_DaysInMonth (
	@year INT,
	@month INT
	)
RETURNS INT
```

## Parameters

 - **year**: The year.
 - **month**: The month (a number ranging from 1 to 12).

## Returns

The number of days in `month` for the specified `year`.

## Example

```csharp
SELECT SQLNET::DateTime_DaysInMonth('2018', 12)
SELECT SQLNET::DateTime_DaysInMonth('2016', 2)
```

