# Path_GetDirectoryName

`Path_GetDirectoryName` returns the directory information for the specified path string.

```csharp
Path_GetDirectoryName (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path of a file or directory.

## Returns

 - Directory information for `path`, or `null` if path denotes a root directory or is `null`. Returns Empty if `path` does not contain directory information.

## Example

```csharp
SELECT SQLNET::Path_GetDirectoryName('C:\Temp\MyTest.txt')
```
