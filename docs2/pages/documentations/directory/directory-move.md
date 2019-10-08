# Directory_Move

`Directory_Move` moves a file or a directory and its contents to a new location.

```csharp
Directory_Move 
	@sourceDirName NVARCHAR (MAX), 
	@destDirName NVARCHAR (MAX)
```

## Parameters

 - **sourceDirName**: The path of the file or directory to move.
 - **destDirName**: The path to the new location for `sourceDirName`. If `sourceDirName` is a file, then `destDirName` must also be a file name.

## Example

```csharp
EXEC Directory_Move @sourceDirName = 'C:\source', @destDirName = 'C:\destination'
```

