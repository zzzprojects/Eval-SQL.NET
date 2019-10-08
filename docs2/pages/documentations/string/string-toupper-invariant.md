# String_ToUpperInvariant

`String_ToUpperInvariant` returns a copy of the `source` string converted to uppercase using the casing rules of the invariant culture.

```csharp
String_ToUpperInvariant (
	@source NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.

## Returns

A string in uppercase.

## Example

```csharp
SELECT SQLNET::String_ToUpperInvariant('wAr aNd pEaCe')
```

# String_ToUpperInvariant4k

It is equivalent to `String_ToUpperInvariant` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_ToUpperInvariant4k (
	@source NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_ToUpperInvariant4k('wAr aNd pEaCe')
```