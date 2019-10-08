# Regex_Match

`Regex_Match` searches an input string for a substring that matches a regular expression pattern and returns the first occurrence of that string.

```csharp
Regex_Match (
	@input NVARCHAR (MAX),
	@pattern NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **input**: The input string that contains the text to convert.
  - **pattern**: The regular expression pattern to match.

## Returns

Gets the captured substring from the input string.

## Example

```csharp
SELECT SQLNET::Regex_Match('An extraordinary day dawns with each new day.', '\be\w*\b')
```

# Regex_Match4k

It is equivalent to `Regex_Match` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
Regex_Match4k (
	@input NVARCHAR (4000),
	@pattern NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::Regex_Match4k('An extraordinary day dawns with each new day.', '\be\w*\b')
```
