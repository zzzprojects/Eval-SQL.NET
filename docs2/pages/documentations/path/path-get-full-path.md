# Path_GetFullPath

`Path_GetFullPath` returns the absolute path for the specified path string.

```csharp
Path_GetFullPath (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The file or directory for which to obtain absolute path information.

## Returns

The fully qualified location of `path`.

## Example

```csharp
SELECT SQLNET::Path_GetFullPath('MyTest.txt')
```
