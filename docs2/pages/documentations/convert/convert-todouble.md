# Convert_ToDouble

`Convert_ToDouble` converts the specified string representation of a number to an equivalent double-precision floating-point number.

```csharp
Convert_ToDouble (
	@value NVARCHAR (MAX)
	)
RETURNS FLOAT (53)
```

## Parameters

  - **value**: A string that contains the number to convert.

## Returns

A double-precision floating-point number that is equivalent to the number in `value`.

## Example

```csharp
SELECT SQLNET::Convert_ToDouble('-1,035.77219')
SELECT SQLNET::Convert_ToDouble('1e-35')
```
