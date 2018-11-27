# String_CompareCurrentCulture

`String_CompareCurrentCulture` compares two specified String objects using culture-sensitive sort rules and the current culture, and returns an integer that indicates their relative position in the sort order.

```csharp
String_CompareCurrentCulture (
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
SELECT SQLNET::String_CompareCurrentCulture('case', 'Case')
SELECT SQLNET::String_CompareCurrentCulture('encyclopædia', 'encyclopaedia')
```

# String_CompareCurrentCulture4k

It is equivalent to `String_CompareCurrentCulture` except no NVARCHAR(MAX) parameters; it can be used when input data will never be over 4000 characters as this function offers better performance.

```csharp
String_CompareCurrentCulture4k (
	@strA NVARCHAR (4000), 
	@strB NVARCHAR (4000)
	)
RETURNS INT
```

## Example

```csharp
SELECT SQLNET::String_CompareCurrentCulture4k('case', 'Case')
SELECT SQLNET::String_CompareCurrentCulture4k('encyclopædia', 'encyclopaedia')
```