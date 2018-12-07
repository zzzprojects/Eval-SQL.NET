# Directory_GetAllFiles

`Directory_GetAllFiles` returns the names of files (including their paths) in the specified directory.

```csharp
Directory_GetAllFiles (
	@path NVARCHAR (MAX))
RETURNS TABLE ([Match] NVARCHAR (MAX) NULL)
```

## Parameters

 - **path**: The relative or absolute path to the directory to search. This string is not case-sensitive.

## Returns

An list of the full names (including paths) for the files in the specified directory, or an empty list if no files are found.

## Example

```csharp
SELECT * FROM Directory_GetAllFiles('C:\Logs')
```

