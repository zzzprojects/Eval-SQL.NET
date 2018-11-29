# String_Contains

`String_Contains` returns a value indicating whether a specified substring occurs within this string.

```csharp
String_Contains (
	@source NVARCHAR (MAX), 
	@target NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

  - **source**: The source string.
  - **target**: The string to search within source string.

## Returns

 `true` if the target parameter occurs within the source string, or if target is the empty string (""); otherwise, `false`.

## Example

```csharp
SELECT SQLNET::String_Contains('This is a string.', 'string')
```

# String_Contains4k

It is equivalent to `String_Contains` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_Contains4k (
	@source NVARCHAR (4000), 
	@target NVARCHAR (4000)
	)
RETURNS BIT
```

## Example

```csharp
SELECT SQLNET::String_Contains4k('This is a string.', 'string')
```