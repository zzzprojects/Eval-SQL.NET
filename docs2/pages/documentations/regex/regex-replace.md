# Regex_Replace

`Regex_Replace` replaces all strings that match a specified regular expression with a specified replacement string. 

```csharp
Regex_Replace (
	@input NVARCHAR (MAX),
	@pattern NVARCHAR (MAX),
	@replacement NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **input**: The input string that contains the text to convert.
  - **pattern**: The regular expression pattern to match.
  - **replacement**: The replacement string.

## Returns

A new string that is identical to the `input` string, except that the `replacement` string takes the place of each matched string. If `pattern` is not matched in the current instance, the method returns the current instance unchanged.

## Example

```csharp
SELECT SQLNET::Regex_Replace('Dot Net Not Perls', 'N.t', 'NET')
```

# Regex_Replace4k

It is equivalent to `Regex_Replace` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
Regex_Replace4k (
	@input NVARCHAR (4000),
	@pattern NVARCHAR (4000),
	@replacement NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::Regex_Replace4k('Dot Net Not Perls', 'N.t', 'NET')
```
