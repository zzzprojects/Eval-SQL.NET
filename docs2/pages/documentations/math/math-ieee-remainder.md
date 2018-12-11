# Math_IEEERemainder

`Math_IEEERemainder` returns the remainder resulting from the division of a specified number by another specified number.

```csharp
Math_IEEERemainder (
	@x INT,
	@y INT)
RETURNS BIGINT
```

## Parameters

 - **x**: A dividend.
 - **y**: A divisor

## Returns

A number equal to `x` - (`y` Q), where Q is the quotient of `x` / `y` rounded to the nearest integer (if `x` / `y` falls halfway between two integers, the even integer is returned).

## Example

```csharp
SELECT SQLNET::Math_IEEERemainder(3, 2)
SELECT SQLNET::Math_IEEERemainder(-16.3, 4.1)
```

