# File_Copy

`File_Copy` copies an existing file to a new file. 

```csharp
File_Copy 
	@sourceFileName NVARCHAR (MAX),
	@destFileName NVARCHAR (MAX),
	@overwrite BIT
```

## Parameters

 - **sourceFileName**: The file to copy.
 - **destFileName**: The name of the destination file. This cannot be a directory.
 - **overwrite**: `true` if the destination file can be overwritten; otherwise, `false`.

## Example

```csharp
EXEC File_Copy @sourceFileName = 'C:\Temp\MyTest.txt', @destFileName = 'C:\Temp\MyTest1.txt', @overwrite = 1
```

