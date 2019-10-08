# Convert_ToBoolean

`Convert_ToBoolean` converts the specified string representation of a logical value to its Boolean equivalent.
```csharp
Convert_ToBoolean (
	@value NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

  - **value**: A string that contains the value of either `TrueString` or `FalseString`.

## Returns

`true` if `value` equals `TrueString`, or false if `value` equals `FalseString`.

## Example

```csharp
SELECT SQLNET::Convert_ToBoolean('false')
SELECT SQLNET::Convert_ToBoolean('true')
```

