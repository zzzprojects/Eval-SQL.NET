# Convert_ToInt16

`Convert_ToInt16` converts the string representation of a number in a specified base to an equivalent 16-bit signed integer.

```csharp
Convert_ToInt16 (
	@value NVARCHAR (MAX)
	)
RETURNS SMALLINT
```

## Parameters

  - **value**: A string that contains the number to convert.

## Returns

A 16-bit signed integer that is equivalent to the number in `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToInt16('251')
```
