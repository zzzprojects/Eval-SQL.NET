# Regex_Escape

`Regex_Escape` escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $, ., #, and white space) by replacing them with their escape codes. This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.

```csharp
Regex_Escape (
	@input NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **input**: The input string that contains the text to convert.

## Returns

A string of characters with metacharacters converted to their escaped form.

## Example

```csharp
SELECT SQLNET::Regex_Escape('test(*.*)')
```

