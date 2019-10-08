# Math_Tanh

`Math_Tanh` returns the hyperbolic tangent of the specified angle.

```csharp
Math_Tanh (
	@value FLOAT (53))
RETURNS FLOAT (53)
```

## Parameters

 - **value**: An angle, measured in radians.

## Returns

The hyperbolic tangent of value. If value is equal to NegativeInfinity or PositiveInfinity, PositiveInfinity is returned. If value is equal to NaN, NaN is returned.

## Example

```csharp
SELECT SQLNET::Math_Tanh(0.2)
```

