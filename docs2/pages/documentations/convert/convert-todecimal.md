# Convert_ToDecimal

`Convert_ToDecimal` converts the specified string representation of a number to an equivalent decimal number.

```csharp
Convert_ToDecimal (
	@value NVARCHAR (MAX)
	)
RETURNS NUMERIC (18)
```

## Parameters

  - **value**: A string that contains a number to convert.

## Returns

A decimal number that is equivalent to the number in `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToDecimal('2015-12-27')
```
