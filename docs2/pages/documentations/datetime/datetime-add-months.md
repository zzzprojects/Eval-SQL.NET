# DateTime_AddMonths

`DateTime_AddMonths` returns a new DateTime that adds the specified number of months to the value of `currDate`.

```csharp
DateTime_AddMonths (
	@currDate DATETIME, 
	@value INT)
	)
RETURNS DATETIME
```

## Parameters

  - **currDate**: The current datetime object.
  - **value**: A number of months. The `value` parameter can be negative or positive.

## Returns

A new `DateTime` object whose value is the sum of the date and time represented by `currDate` and the number of months represented by `value`.

## Example

```csharp
SELECT SQLNET::DateTime_AddMonths('2017-05-25', 4)
SELECT SQLNET::DateTime_AddMonths('2018-12-01', -3)
```

