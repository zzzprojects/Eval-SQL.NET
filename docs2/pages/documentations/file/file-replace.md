# File_Replace

`File_Replace` replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors.

```csharp
File_Replace 
	@sourceFileName NVARCHAR (MAX),
	@destFileName NVARCHAR (MAX),
	@destBackupFileName NVARCHAR (MAX),
	@ignoreMetadataErrors BIT
```

## Parameters

 - **sourceFileName**: The name of a file that replaces the file specified by `destinationFileName`.
 - **destFileName**: The name of the file being replaced.
 - **destBackupFileName**: The name of the backup file.
 - **ignoreMetadataErrors**: `true` to ignore merge errors (such as attributes and access control lists (ACLs)) from the replaced file to the replacement file; otherwise, `false`.

## Example

```csharp
EXEC File_Replace @sourceFileName = 'C:\Temp\MyTest.txt', @destFileName = 'C:\Temp\MyNewTest.txt', @destBackupFileName = 'C:\Temp\MybackupTest.txt', @ignoreMetadataErrors = 0
```

