# String_Length

`String_Length` returns the number of characters in the `source` string.

```csharp
String_Length (
	@source NVARCHAR (MAX), 
	)
RETURNS INT
```

## Parameters

  - **source**: The source string.

## Returns

The number of characters in the `source` string.

## Example

```csharp
SELECT SQLNET::String_Length('This is a string.')
```

# String_Length4k

It is equivalent to `String_Length` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Length4k (
	@source NVARCHAR (4000), 
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::String_Length4k('This is a string.')
```