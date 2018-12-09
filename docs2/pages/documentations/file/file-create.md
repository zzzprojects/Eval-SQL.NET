# File_Create

`File_Create` creates or overwrites a file in the specified path.

```csharp
File_Create 
	@path NVARCHAR (MAX)
```

## Parameters

 - **path**: The path and name of the file to create.

## Example

```csharp
EXEC File_Create @path = 'C:\Temp\MyTest.txt'
```

