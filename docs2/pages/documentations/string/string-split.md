# String_Split

`String_Split` returns a string array that contains the substrings in the `source` string that are delimited by elements of a specified `delimStr` string.

```csharp
String_Split (
	@source NVARCHAR (MAX),
	@delimStr NVARCHAR (MAX)
	)
RETURNS TABLE ([Match] NVARCHAR (MAX) NULL)
```

## Parameters

  - **source**: The source string.
  - **delimStr**: A string that is converted to character array that delimits the substrings in the `source` string, an empty array that contains no delimiters, or `null`.

## Returns

 - A string that is equivalent to the `source` string except that all instances of `oldValue` are replaced with `newValue`. 
 - If `oldValue` is not found in the `source` string, the method returns the `source` string without any changes.

## Example

```csharp
SELECT * FROM String_Split(',ONE,,TWO,,,THREE,,', ',')
SELECT * FROM String_Split('1,2,3,4;5;6;:7:8:9', ',;:')
```

# String_Split4k

It is equivalent to `String_Split` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Split4k (
	@source NVARCHAR (4000),
	@delimStr NVARCHAR (4000)
	)
RETURNS TABLE ([Match] NVARCHAR (4000) NULL)
```

## Example

```csharp
SELECT * FROM String_Split4k(',ONE,,TWO,,,THREE,,', ',')
SELECT * FROM String_Split4k('1,2,3,4;5;6;:7:8:9', ',;:')
```