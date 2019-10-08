# Math_Cosh

`Math_Cosh` returns the hyperbolic cosine of the specified angle.

```csharp
Math_Cosh (
	@value FLOAT (53))
RETURNS FLOAT (53)
```

## Parameters

 - **value**: An angle, measured in radians.

## Returns

The hyperbolic cosine of value. If value is equal to NegativeInfinity or PositiveInfinity, PositiveInfinity is returned. If value is equal to NaN, NaN is returned.

## Example

```csharp
SELECT SQLNET::Math_Cosh(0.1)
```

