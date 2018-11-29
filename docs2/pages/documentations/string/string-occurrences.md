# String_Occurrences

`String_Occurrences` returns the number of occurrences of `searchValue` in the `source` string.

```csharp
String_Occurrences (
	@source NVARCHAR (MAX),
	@searchValue NVARCHAR (MAX),
	@isCaseSensitive BIT
	)
RETURNS INT
```

## Parameters

  - **source**: The source string.
  - **searchValue**: The string to search within the source string.
  - **isCaseSensitive**: 0 to ignore case during the comparison; otherwise, 1.

## Returns

The number of characters in the `source` string.

## Example

```csharp
SELECT SQLNET::String_Occurrences('This is a String.', 's', 0)
SELECT SQLNET::String_Occurrences('This is a String.', 's', 1)
```

# String_Occurrences4k

It is equivalent to `String_Occurrences` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Occurrences4k (
	@source NVARCHAR (4000),
	@searchValue NVARCHAR (4000),
	@isCaseSensitive BIT
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::String_Occurrences4k('This is a String.', 's', 0)
SELECT SQLNET::String_Occurrences4k('This is a String.', 's', 1)
```