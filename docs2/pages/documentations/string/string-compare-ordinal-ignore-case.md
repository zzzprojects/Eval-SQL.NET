# String_CompareOrdinalIgnoreCase

`String_CompareOrdinalIgnoreCase` compares two specified String objects using ordinal (binary) sort rules and ignoring the case of the strings, and returns an integer that indicates their relative position in the sort order.

```csharp
String_CompareOrdinalIgnoreCase (
	@strA NVARCHAR (MAX), 
	@strB NVARCHAR (MAX)
	)
RETURNS INT
```

## Parameters

  - **strA**: The first string to compare.
  - **strB**: The second string to compare.

## Returns

A 32-bit signed integer that indicates the lexical relationship between the two comparands.

| Value		| Condition	|
|:--------- |:--------- |
|Less than zero		|strA precedes strB in the sort order.|
|Zero				|strA occurs in the same position as strB in the sort order.|
|Greater than zero	|strA follows strB in the sort order.|

## Example

```csharp
SELECT SQLNET::String_CompareOrdinalIgnoreCase('case', 'Case')
SELECT SQLNET::String_CompareOrdinalIgnoreCase('Archæology', 'ARCHÆOLOGY')
```

# String_CompareOrdinalIgnoreCase4k

It is equivalent to `String_CompareOrdinalIgnoreCase` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_CompareOrdinalIgnoreCase4k (
	@strA NVARCHAR (4000), 
	@strB NVARCHAR (4000)
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::String_CompareOrdinalIgnoreCase4k('case', 'Case')
SELECT SQLNET::String_CompareOrdinalIgnoreCase4k('Archæology', 'ARCHÆOLOGY')
```