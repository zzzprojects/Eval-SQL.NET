# File_Delete

`File_Delete` deletes the specified file.

```csharp
File_Delete 
	@path NVARCHAR (MAX)
```

## Parameters

 - **path**: The name of the file to be deleted. Wildcard characters are not supported.

## Example

```csharp
EXEC File_Delete @path = 'C:\Temp\MyTest.txt'
```

