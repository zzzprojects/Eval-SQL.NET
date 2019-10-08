# Math_RemainderInt64

`Math_RemainderInt64` returns the remainder of two 64-bit signed integers.
```csharp
Math_RemainderInt64 (
	@a INT,
	@b INT)
RETURNS INT
```

## Parameters

 - **a**: A dividend.
 - **b**: A divisor

## Returns

The remainder of the specified numbers.

## Example

```csharp
SELECT SQLNET::Math_RemainderInt64(2147483647, 2000)
```

