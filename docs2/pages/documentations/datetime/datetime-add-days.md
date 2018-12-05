# DateTime_AddDays

`DateTime_AddDays` returns a new DateTime that adds the specified number of days to the value of `currDate`.

```csharp
DateTime_AddDays (
	@currDate DATETIME, 
	@value FLOAT (53))
	)
RETURNS DATETIME
```

## Parameters

  - **currDate**: The current datetime object.
  - **value**: A number of whole and fractional days. The `value` parameter can be negative or positive.

## Returns

A new `DateTime` object whose value is the sum of the date and time represented by `currDate` and the number of days represented by `value`.

## Example

```csharp
SELECT SQLNET::DateTime_AddDays('2017-05-25', 4)
SELECT SQLNET::DateTime_AddDays('2018-12-01', 2.2)
```

