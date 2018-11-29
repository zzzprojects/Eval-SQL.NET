# String_Remove

`String_Remove` returns a new string in which all the characters in the `source` string, beginning at a specified position are deleted till the end of the `source` string.

```csharp
String_Remove (
	@source NVARCHAR (MAX),
	@startIndex INT
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **startIndex**: The zero-based position to begin deleting characters.

## Returns

 - A new string that is equivalent to this string except for the removed characters.

## Example

```csharp
SELECT SQLNET::String_Remove('abc---def', 3)
```

# String_Remove4k

It is equivalent to `String_Remove` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Remove4k (
	@source NVARCHAR (4000),
	@startIndex INT
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_Remove4k('abc---def', 3)
```