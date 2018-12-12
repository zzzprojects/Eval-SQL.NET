# Path_HasExtension

`Path_HasExtension` determines whether a path includes a file name extension.

```csharp
Path_HasExtension (
	@path NVARCHAR (4000)
	)
RETURNS BIT
```

## Parameters

  - **path**: The path to search for an extension.

## Returns

`true` if the characters that follow the last directory separator (\\ or /) or volume separator (:) in the path include a period (.) followed by one or more characters; otherwise, `false`.

## Example

```csharp
SELECT SQLNET::Path_HasExtension('C:\Temp\MyTest.txt')
```
