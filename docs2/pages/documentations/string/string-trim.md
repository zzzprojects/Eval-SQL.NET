# String_Trim

`String_Trim` removes all leading and trailing white-space characters from the `source` string.

```csharp
String_Trim (
	@source NVARCHAR (MAX)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.

## Returns

 - The string that remains after all white-space characters are removed from the start and end of the `source` string. 
 - If no characters can be trimmed from the `source` instance, the method returns it without any changes.

## Example

```csharp
SELECT SQLNET::String_Trim('   John Doe      ')
```

# String_Trim4k

It is equivalent to `String_Trim` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Trim4k (
	@source NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_Trim4k('   John Doe      ')
```