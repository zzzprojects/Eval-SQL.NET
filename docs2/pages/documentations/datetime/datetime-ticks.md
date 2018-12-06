# DateTime_Ticks

`DateTime_Ticks` returns the number of ticks that represent the date and time of the `currDate` instance.

```csharp
DateTime_Ticks(
	@currDate DATETIME
	)
RETURNS BIGINT
```

## Parameters

  - **currDate**: The current datetime object.

## Returns

The number of ticks that represent the date and time of the `currDate` instance. The value is between `DateTime.MinValue.Ticks` and `DateTime.MaxValue.Ticks`.

## Example

```csharp
SELECT SQLNET::DateTime_Ticks(2018-12-01)
```

