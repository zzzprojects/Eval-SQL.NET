# String_EndsWith

`String_EndsWith` determines whether the end of the source string instance matches a target string.

```csharp
String_EndsWith (
	@source NVARCHAR (MAX), 
	@target NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

  - **source**: The source string.
  - **target**: The string to compare to the substring at the end of the source string.

## Returns

 `true` if the target matches the end of the source string; otherwise, `false`.

## Example

```csharp
SELECT SQLNET::String_EndsWith('This is a string.', 'string.')
```

# String_EndsWith4k

It is equivalent to `String_EndsWith` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_EndsWith4k (
	@source NVARCHAR (4000), 
	@target NVARCHAR (4000)
	)
RETURNS BIT
```

## Example

```csharp
SELECT SQLNET::String_EndsWith4k('This is a string.', 'string.')
```