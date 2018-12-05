# Convert_ToInt32

`Convert_ToInt32` converts the specified string representation of a number to an equivalent 32-bit signed integer.

```csharp
Convert_ToInt32 (
	@value NVARCHAR (MAX)
	)
RETURNS SMALLINT
```

## Parameters

  - **value**: A string that contains the number to convert.

## Returns

A 32-bit signed integer that is equivalent to the number in `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToInt32('4285')
```
