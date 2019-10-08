# Regex_IsMatch

`Regex_IsMatch` indicates whether the specified regular expression finds a match in the specified input string.

```csharp
Regex_IsMatch (
	@input NVARCHAR (MAX),
	@pattern NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

  - **input**: The input string that contains the text to convert.
  - **pattern**: The regular expression pattern to match.

## Returns

The zero-based index position in the original string where the first character of the captured substring is found or -1 if it is not. 

## Example

```csharp
SELECT SQLNET::Regex_IsMatch('A08Z-931-468A', '^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$')
SELECT SQLNET::Regex_IsMatch('_A90-123-129X', '^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$')
```

# Regex_IsMatch4k

It is equivalent to `Regex_IsMatch` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
Regex_IsMatch4k (
	@input NVARCHAR (4000),
	@pattern NVARCHAR (4000)
	)
RETURNS BIT
```

## Example

```csharp
SELECT SQLNET::Regex_IsMatch4k('A08Z-931-468A', '^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$')
SELECT SQLNET::Regex_IsMatch4k('_A90-123-129X', '^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$')
```
