# Directory_GetAllFileSystemEntries

`Directory_GetAllFileSystemEntries` returns the names of all files and subdirectories in a specified path.

```csharp
Directory_GetAllFileSystemEntries (
	@path NVARCHAR (MAX))
RETURNS TABLE ([Match] NVARCHAR (MAX) NULL)
```

## Parameters

 - **path**: The relative or absolute path to the directory to search. This string is not case-sensitive.

## Returns

A list of the names of files and subdirectories in the specified directory, or an empty list if no files or subdirectories are found.

## Example

```csharp
SELECT * FROM Directory_GetAllFileSystemEntries('C:\Logs')
```

