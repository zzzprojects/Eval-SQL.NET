# Convert_ToDateTime

`Convert_ToDateTime` converts the specified string representation of a date and time to an equivalent date and time value.

```csharp
Convert_ToDateTime (
	@value NVARCHAR (MAX)
	)
RETURNS DATETIME
```

## Parameters

  - **value**: The string representation of a date and time.

## Returns

The date and time that is equivalent to the `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToDateTime('2015-12-27')
```
