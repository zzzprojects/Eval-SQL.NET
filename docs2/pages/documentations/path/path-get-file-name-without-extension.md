# Path_GetFileNameWithoutExtension

`Path_GetFileNameWithoutExtension` returns the file name and extension of the specified path string without the extension.

```csharp
Path_GetFileNameWithoutExtension (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path string from which to obtain the file name and extension.

## Returns

The path string minus the last period (.) and all characters following it.

## Example

```csharp
SELECT SQLNET::Path_GetFileNameWithoutExtension('C:\Temp\MyTest.txt')
```
