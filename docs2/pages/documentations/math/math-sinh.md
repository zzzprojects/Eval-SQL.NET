# Math_Sinh

`Math_Sinh` returns the hyperbolic sine of the specified angle.

```csharp
Math_Sinh (
	@value FLOAT (53))
RETURNS FLOAT (53)
```

## Parameters

 - **value**: An angle, measured in radians.

## Returns

The hyperbolic sine of value. If value is equal to NegativeInfinity or PositiveInfinity, PositiveInfinity is returned. If value is equal to NaN, NaN is returned.

## Example

```csharp
SELECT SQLNET::Math_Sinh(0.1)
```

