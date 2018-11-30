# String_StartsWith

`String_StartsWith` determines whether the beginning of the `source` string instance matches the specified `target` string.

```csharp
String_StartsWith (
	@source NVARCHAR (MAX),
	@target NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

  - **source**: The source string.
  - **target**: The string to compare.

## Returns

`true` if `target` matches the beginning of the `source` string; otherwise, false. 

## Example

```csharp
SELECT SQLNET::String_StartsWith('<b>This is bold text</b>', '<b>')
```

# String_StartsWith4k

It is equivalent to `String_StartsWith` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_StartsWith4k (
	@source NVARCHAR (4000),
	@target NVARCHAR (4000)
	)
RETURNS BIT
```

## Example

```csharp
SELECT SQLNET::String_StartsWith4k('<b>This is bold text</b>', '<b>')
```