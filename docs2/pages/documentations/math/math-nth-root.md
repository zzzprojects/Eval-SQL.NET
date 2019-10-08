# Math_NthRoot

`Math_NthRoot` returns the nth root of a specified number.

```csharp
Math_NthRoot (
	@value FLOAT (53),
	@nth FLOAT (53))
RETURNS FLOAT (53)
```

## Parameters

 - **value**: The number whose nth root is to be found.

## Returns

The nth root of a `value`.

## Example

```csharp
SELECT SQLNET::Math_NthRoot(8)
```

