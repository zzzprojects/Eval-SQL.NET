# Regex_Split

`Regex_Split` splits an input string into an array of substrings at the positions defined by a regular expression pattern.

```csharp
Regex_Split (
	@input NVARCHAR (MAX),
	@pattern NVARCHAR (MAX)
	)
RETURNS TABLE (Match NVARCHAR (MAX) NULL)
```

## Parameters

  - **input**: The input string that contains the text to convert.
  - **pattern**: The regular expression pattern to match.

## Returns

An array of strings.

## Example

```csharp
SELECT * FROM Regex_Split('plum--pear', '-')
```

# Regex_Split4k

It is equivalent to `Regex_Split` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
Regex_Split4k (
	@input NVARCHAR (4000),
	@pattern NVARCHAR (4000)
	)
RETURNS TABLE (Match NVARCHAR (4000) NULL)
```

## Example

```csharp
SELECT * FROM Regex_Split4k('plum--pear', '-')
```
