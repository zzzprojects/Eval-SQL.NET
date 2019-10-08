# File_ReadAllText

`File_ReadAllText` 0pens a text file, reads and returns all the text in the file, and then closes the file.

```csharp
File_ReadAllText (
	@path NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
```

## Parameters

 - **path**: The file path to open for reading.

## Returns

A string containing all the text in the file.

## Example

```csharp
SELECT SQLNET::File_ReadAllText('C:\Temp\MyTest.txt')
```

