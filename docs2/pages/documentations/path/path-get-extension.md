# Path_GetExtension

`Path_GetExtension` returns the extension of the specified path string.

```csharp
Path_GetExtension (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path string from which to get the extension.

## Returns

The extension of the specified path (including the period "."), or null, or empty string. If `path` is null, it returns null. If path does not have extension information, it returns empty string.

## Example

```csharp
SELECT SQLNET::Path_GetExtension('C:\Temp\MyTest.txt')
```
