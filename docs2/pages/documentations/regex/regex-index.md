# Regex_Index

`Regex_Index` returns the position in the original string where the first character of the captured substring is found.

```csharp
Regex_Index (
	@input NVARCHAR (MAX),
	@pattern NVARCHAR (MAX)
	)
RETURNS INT
```

## Parameters

  - **input**: The input string that contains the text to convert.
  - **pattern**: The regular expression pattern to match.

## Returns

The zero-based index position in the original string where the first character of the captured substring is found or -1 if it is not. 

## Example

```csharp
SELECT SQLNET::Regex_Index('An extraordinary day dawns with each new day.', '\be\w*\b')
```

# Regex_Index4k

It is equivalent to `Regex_Index` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
Regex_Index4k (
	@input NVARCHAR (4000),
	@pattern NVARCHAR (4000)
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::Regex_Index4k('An extraordinary day dawns with each new day.', '\be\w*\b')
```
