# String_PadLeft

`String_PadLeft` returns a new string that right-aligns the characters in the `source` string by padding them on the left with a specified `paddingChar` Unicode character, for a specified total length.

```csharp
String_PadLeft (
	@source NVARCHAR (MAX),
	@totalWidth INT, 
	@paddingChar NVARCHAR (1)
	)
RETURNS NVARCHAR (MAX)
```

## Parameters

  - **source**: The source string.
  - **totalWidth**: The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.
  - **paddingChar**: A Unicode padding character.

## Returns

 - A new string that is equivalent to the `source` string, but right-aligned and padded on the left with as many paddingChar characters as needed to create a length of `totalWidth`. 
 - If `totalWidth` is less than the length of the `source` string, the method returns a reference to the existing instance. 
 - If `totalWidth` is equal to the length of the `source` string, the method returns a new string that is identical to the `source` string.

## Example

```csharp
SELECT SQLNET::String_PadLeft('This is a String.', 20, '.')
SELECT SQLNET::String_PadLeft('This is a String.', 10, '.')
```

# String_PadLeft4k

It is equivalent to `String_PadLeft` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_PadLeft4k (
	@source NVARCHAR (4000),
	@totalWidth INT, 
	@paddingChar NVARCHAR (1)
	)
RETURNS NVARCHAR (4000)
```

## Example

```csharp
SELECT SQLNET::String_PadLeft4k('This is a String.', 20, '.')
SELECT SQLNET::String_PadLeft4k('This is a String.', 10, '.')
```