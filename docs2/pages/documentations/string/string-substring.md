# String_Substring

`String_Substring` returns a substring from this instance. The substring starts at a specified character position and has a specified length.

```csharp
String_Substring (
	@source NVARCHAR (MAX),
	@startIndex INT,
	@length INT
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **startIndex**: The zero-based starting character position of a substring in the `source` string.
  - **length**: The number of characters in the substring.

## Returns

A string that is equivalent to the substring of length that begins at `startIndex` in the `source` string, or Empty if `startIndex` is equal to the length of this instance and `length` is zero.

## Example

```csharp
SELECT SQLNET::String_Substring('Name: Felica Walker', 6, 13)
```

# String_Substring4k

It is equivalent to `String_Substring` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Substring4k (
	@source NVARCHAR (4000),
	@startIndex INT,
	@length INT
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_Substring4k('Name: Felica Walker', 6, 13)
```