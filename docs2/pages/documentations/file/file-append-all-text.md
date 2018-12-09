# File_AppendAllText

`File_AppendAllText` opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, it creates a file, writes the specified string to the file, then closes the file.

```csharp
File_AppendAllText 
	@path NVARCHAR (MAX),
	@content NVARCHAR (MAX)
```

## Parameters

 - **path**: The file to append the specified string to.
 - **content**: The string to append to the file.

## Example

```csharp
EXEC File_AppendAllText @path = 'C:\Temp\MyTest.txt', @content = 'This is extra text'
```

