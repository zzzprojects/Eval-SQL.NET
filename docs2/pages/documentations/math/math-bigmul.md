# Math_BigMul

`Math_BigMul` produces the full product of two 32-bit numbers.

```csharp
Math_BigMul (
	@a INT,
	@b INT)
RETURNS BIGINT
```

## Parameters

 - **a**: The first number to multiply.
 - **b**: The second number to multiply.

## Returns

The number containing the product of the specified numbers.

## Example

```csharp
SELECT SQLNET::Math_BigMul(2147483647, 2147483647)
```

