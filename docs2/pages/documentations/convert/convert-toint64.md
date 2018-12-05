# Convert_ToInt64

`Convert_ToInt64` converts the specified string representation of a number to an equivalent 64-bit signed integer.

```csharp
Convert_ToInt64 (
	@value NVARCHAR (MAX)
	)
RETURNS SMALLINT
```

## Parameters

  - **value**: A string that contains the number to convert.

## Returns

A 64-bit signed integer that is equivalent to the number in `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToInt64('854')
```
