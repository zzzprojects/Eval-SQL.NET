# Math_CubeRoot

`Math_CubeRoot` returns the cube root of a specified number.

```csharp
Math_CubeRoot (
	@value FLOAT (53))
RETURNS FLOAT (53)
```

## Parameters

 - **value**: The number whose cude root is to be found.

## Returns

The cube root of a `value`.

## Example

```csharp
SELECT SQLNET::Math_CubeRoot(8)
```

