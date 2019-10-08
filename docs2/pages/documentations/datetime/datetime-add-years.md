# DateTime_AddYears

`DateTime_AddYears` returns a new DateTime that adds the specified number of years to the value of `currDate`.

```csharp
DateTime_AddYears (
	@currDate DATETIME, 
	@value INT)
	)
RETURNS DATETIME
```

## Parameters

  - **currDate**: The current datetime object.
  - **value**: A number of years. The `value` parameter can be negative or positive.

## Returns

A new `DateTime` object whose value is the sum of the date and time represented by `currDate` and the number of years represented by `value`.

## Example

```csharp
SELECT SQLNET::DateTime_AddYears('2017-05-25', 4)
SELECT SQLNET::DateTime_AddYears('2018-12-01', -3)
```

