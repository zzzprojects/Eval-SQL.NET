# String_IndexOfCurrentCulture

`String_IndexOfCurrentCulture` returns the zero-based index of the first occurrence of a `searchValue` Unicode character or string within the `source` string using culture-sensitive sort rules and the current culture.

```csharp
String_IndexOfCurrentCulture (
	@source NVARCHAR (MAX), 
	@searchValue NVARCHAR (MAX)
	)
RETURNS INT
```

## Parameters

  - **source**: The source string.
  - **searchValue**: The string to search within the source string.

## Returns

The zero-based index position of the `searchValue` parameter from the start of the `source` string if that string is found, or -1 if it is not. If `searchValue` is Empty, the return value is 0.

## Example

```csharp
SELECT SQLNET::String_IndexOfCurrentCulture('This is a string.', 'string')
SELECT SQLNET::String_IndexOfCurrentCulture('Archæology', 'Æ')
```

# String_IndexOfCurrentCulture4k

It is equivalent to `String_IndexOfCurrentCulture` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_IndexOfCurrentCulture4k (
	@source NVARCHAR (4000), 
	@searchValue NVARCHAR (4000)
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::String_IndexOfCurrentCulture4k('This is a string.', 'string')
SELECT SQLNET::String_IndexOfCurrentCulture4k('Archæology', 'Æ')
```