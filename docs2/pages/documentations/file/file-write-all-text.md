# File_WriteAllText

`File_WriteAllText` Creates a new file, write the contents to the file, and then closes the file. If the target file already exists, it is overwritten.

```csharp
File_WriteAllText 
	@path NVARCHAR (MAX),
	@contents NVARCHAR (MAX)
```

## Parameters

 - **path**: The file to write to.
 - **contents**: The string to write to the file.

## Example

```csharp
EXEC File_WriteAllText @path = 'C:\Temp\MyTest.txt', @contents = 'This is a text'
```

