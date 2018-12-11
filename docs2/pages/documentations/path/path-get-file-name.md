# Path_GetFileName

`Path_GetFileName` returns the file name and extension of the specified path string.

```csharp
Path_GetFileName (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path string from which to obtain the file name and extension.

## Returns

The characters after the last directory character in `path`. If the last character of `path` is a directory or volume separator character, this method returns empty string. If `path` is `null`, this method returns `null`.

## Example

```csharp
SELECT SQLNET::Path_GetFileName('C:\Temp\MyTest.txt')
```
