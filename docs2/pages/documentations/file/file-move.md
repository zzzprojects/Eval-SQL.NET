# File_Move

`File_Move` moves a specified file to a new location, providing the option to specify a new file name.

```csharp
File_Move 
	@sourceFileName NVARCHAR (MAX),
	@destFileName NVARCHAR (MAX)
```

## Parameters

 - **sourceFileName**: The name of the file to move.
 - **destFileName**: The new path and name for the file.

## Example

```csharp
EXEC File_Move @sourceFileName = 'C:\Temp\MyTest.txt', @destFileName = 'C:\Temp\MyNewTest.txt'
```

