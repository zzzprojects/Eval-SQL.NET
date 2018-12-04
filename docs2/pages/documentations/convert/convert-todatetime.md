# Convert_ToDateTime

`Convert_ToDateTime` converts the specified string representation of a date and time to an equivalent date and time value.

```csharp
Convert_ToDateTime (
	@value NVARCHAR (MAX)
	)
RETURNS TINYINT
```

## Parameters

  - **value**: The string representation of a date and time.

## Returns

The date and time equivalent of the value of `value`, or the date and time equivalent of `MinValue` if `value` is null.

## Example

```csharp
SELECT SQLNET::Convert_ToDateTime('2015-12-27')
```
