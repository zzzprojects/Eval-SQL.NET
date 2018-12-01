# String_ToUpper

`String_ToUpper` returns a copy of the `source` string converted to uppercase.

```csharp
String_ToUpper (
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
SELECT SQLNET::String_ToUpper('wAr aNd pEaCe')
```

# String_ToUpper4k

It is equivalent to `String_ToUpper` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_ToUpper4k (
	@source NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_ToUpper4k('wAr aNd pEaCe')
```