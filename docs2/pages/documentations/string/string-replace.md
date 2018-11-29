# String_Replace

`String_Replace` returns a new string in which all occurrences of a specified `oldValye` Unicode character or String in the `source` string are replaced with another specified `newValue` Unicode character or String.

```csharp
String_Replace (
	@source NVARCHAR (MAX),
	@oldValue NVARCHAR (MAX),
	@newValue NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **oldValue**: The string to be replaced.
  - **newValue**: The string to replace all occurrences of oldValue.

## Returns

 - A string that is equivalent to the `source` string except that all instances of `oldValue` are replaced with `newValue`. 
 - If `oldValue` is not found in the current instance, the method returns the `source` string without any changes.

## Example

```csharp
SELECT SQLNET::String_Replace('1 2 3 4 5 6 7 8 9', ' ', ',')
SELECT SQLNET::String_Replace('This docment uses 3 other docments to docment the docmentation', 'docment', 'document')
```

# String_Replace4k

It is equivalent to `String_Replace` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Replace4k (
	@source NVARCHAR (4000),
	@oldValue NVARCHAR (MAX),
	@newValue NVARCHAR (MAX)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_Replace4k('1 2 3 4 5 6 7 8 9', ' ', ',')
SELECT SQLNET::String_Replace4k('This docment uses 3 other docments to docment the docmentation', 'docment', 'document')
```