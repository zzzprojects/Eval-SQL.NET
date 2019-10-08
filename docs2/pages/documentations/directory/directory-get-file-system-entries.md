# Directory_GetFileSystemEntries

`Directory_GetFileSystemEntries` returns a list of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

```csharp
Directory_GetFileSystemEntries (
	@path NVARCHAR (MAX)),
	@searchPattern NVARCHAR (MAX)
	@searchOption
)
RETURNS TABLE ([Match] NVARCHAR (MAX) NULL)
```

## Parameters

 - **path**: The relative or absolute path to the directory to search. This string is not case-sensitive.
 - **searchPattern**: The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
 - **searchOption**: One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.

### SearchOption

You can use one of the following options.

| SearchOption          |Integer Value  | Descritpiton  |
|:----------------------|:--------------|:--------------|
|TopDirectoryOnly       | 0             | Includes only the current directory in a search operation. |
|AllDirectories         | 1             | Includes the current directory and all its subdirectories in a search operation. This option includes reparse points such as mounted drives and symbolic links in the search. |

## Returns

An list of file the file names and directory names that match the specified search criteria, or an empty list if no files or directories are found.

## Example

```csharp
SELECT * FROM Directory_GetFileSystemEntries('C:\Logs', '*.html', 1)
SELECT * FROM Directory_GetFileSystemEntries('C:\Temp', '*.pdf', 0)
```

