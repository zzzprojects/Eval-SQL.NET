# Directory_GetAllDirectories

`Directory_GetAllDirectories` returns the names of subdirectories (including their paths) in the specified directory.

```csharp
Directory_GetAllDirectories (
	@path NVARCHAR (MAX))
RETURNS TABLE ([Match] NVARCHAR (MAX) NULL)
```

## Parameters

 - **path**: The relative or absolute path to the directory to search. This string is not case-sensitive.

## Returns

A list of the full names (including paths) of subdirectories in the specified path, or an empty list if no directories are found.

## Example

```csharp
SELECT * FROM Directory_GetAllDirectories('C:\Logs')
```
