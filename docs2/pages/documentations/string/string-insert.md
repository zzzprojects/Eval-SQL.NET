# String_Insert

`String_Insert` returns a new string in which a `value` string is inserted at a specified index position in the `source` string.

```csharp
String_Insert (
	@source NVARCHAR (MAX), 
	@startIndex INT,
	@value NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **startIndex**: The zero-based index position of the insertion.
  - **value**: The string to insert.

## Returns

A new string that is equivalent to the `source` string, but with `value` inserted at position `startIndex`.

## Example

```csharp
SELECT SQLNET::String_Insert('This is a string.', 10, 'new ')
SELECT SQLNET::String_Insert('aaaabbbb', 4, ' ')
```

# String_Insert4k

It is equivalent to `String_Insert` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Insert4k (
	@source NVARCHAR (4000), 
	@startIndex INT,
	@value NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_Insert4k('This is a string.', 10, 'new ')
SELECT SQLNET::String_Insert4k('aaaabbbb', 4, ' ')
```