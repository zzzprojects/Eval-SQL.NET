# String_RemoveNumOfChars

`String_RemoveNumOfChars` returns a new string in which a specified number of characters in the `source` beginning at a specified position have been deleted.

```csharp
String_RemoveNumOfChars (
	@source NVARCHAR (MAX),
	@startIndex INT
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **startIndex**: The zero-based position to begin deleting characters.
  - **count**: The number of characters to delete.

## Returns

 - A new string that is equivalent to this string except for the removed characters.

## Example

```csharp
SELECT SQLNET::String_RemoveNumOfChars('abc---def', 3, 3)
```

# String_RemoveNumOfChars4k

It is equivalent to `String_RemoveNumOfChars` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_RemoveNumOfChars4k (
	@source NVARCHAR (4000),
	@startIndex INT
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_RemoveNumOfChars4k('abc---def', 3, 3)
```