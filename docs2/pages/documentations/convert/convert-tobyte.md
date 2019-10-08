# Convert_ToByte

`Convert_ToByte` converts the specified string representation of a number to an equivalent 8-bit unsigned integer.
```csharp
Convert_ToByte (
	@value NVARCHAR (MAX)
	)
RETURNS TINYINT
```

## Parameters

  - **value**: A string that contains the number to convert.

## Returns

An 8-bit unsigned integer that is equivalent to the `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToByte('3')
SELECT SQLNET::Convert_ToByte('136')
```

