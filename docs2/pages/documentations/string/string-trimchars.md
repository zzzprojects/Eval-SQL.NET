# String_TrimChars

`String_TrimChars` removes all leading and trailing occurrences of a set of characters specified in `charsToTrimStr` from the the `source` string.

```csharp
String_TrimChars (
	@source NVARCHAR (MAX),
	@charsToTrimStr NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **charsToTrimStr**: A string that is converted to an array of Unicode characters to remove, or null.

## Returns

 - The string that remains after all white-space characters are removed from the start and end of the `source` string. 
 - If no characters can be trimmed from the `source` instance, the method returns it without any changes.

## Example

```csharp
SELECT SQLNET::String_TrimChars('*John Doe/', '*/')
```

# String_TrimChars4k

It is equivalent to `String_TrimChars` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_TrimChars4k (
	@source NVARCHAR (4000),
	@charsToTrimStr NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_TrimChars4k('*John Doe/', '*/')
```