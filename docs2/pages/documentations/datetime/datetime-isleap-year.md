# DateTime_IsLeapYear

`DateTime_IsLeapYear` returns an indication whether the specified year is a leap year.

```csharp
DateTime_IsLeapYear (
	@year INT)
	)
RETURNS BIT
```

## Parameters

  - **year**: A 4-digit year.

## Returns

`true` if `year` is a leap year; otherwise, `false`.

## Example

```csharp
SELECT SQLNET::DateTime_IsLeapYear('2017')
SELECT SQLNET::DateTime_IsLeapYear('2012')
```

