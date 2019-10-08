# String_ToTitleCase

`String_ToTitleCase` returns a converted string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).

```csharp
String_ToTitleCase (
	@source NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.

## Returns

The string converted to title case.

## Example

```csharp
SELECT SQLNET::String_ToTitleCase('wAr aNd pEaCe')
SELECT SQLNET::String_ToTitleCase('UNICEF and children')
```

# String_ToTitleCase4k

It is equivalent to `String_ToTitleCase` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_ToTitleCase4k (
	@source NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_ToTitleCase4k('wAr aNd pEaCe')
SELECT SQLNET::String_ToTitleCase4k('UNICEF and children')
```