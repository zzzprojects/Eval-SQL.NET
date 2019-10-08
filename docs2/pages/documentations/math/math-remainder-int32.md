# Math_RemainderInt32

`Math_RemainderInt32` returns the remainder of two 32-bit signed integers.

```csharp
Math_RemainderInt32 (
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
SELECT SQLNET::Math_RemainderInt32(2147483647, 2000)
```

