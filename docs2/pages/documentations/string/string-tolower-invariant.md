# String_ToLowerInvariant

`String_ToLowerInvariant` returns a copy of the `source` string converted to lowercase using the casing rules of the invariant culture.

```csharp
String_ToLowerInvariant (
	@source NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.

## Returns

A string in lowercase.

## Example

```csharp
SELECT SQLNET::String_ToLowerInvariant('wAr aNd pEaCe')
```

# String_ToLowerInvariant4k

It is equivalent to `String_ToLowerInvariant` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_ToLowerInvariant4k (
	@source NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_ToLowerInvariant4k('wAr aNd pEaCe')
```