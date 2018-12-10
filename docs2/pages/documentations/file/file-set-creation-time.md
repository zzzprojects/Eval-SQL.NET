# File_SetCreationTime

`File_SetCreationTime` sets the date and time the file was created.

```csharp
File_SetCreationTime
	@path NVARCHAR (MAX),
	@creationTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain creation date and time information.
 - **creationTime**: A DateTime containing the value to set for the creation date and time of path. This value is expressed in local time.

## Example

```csharp
EXEC File_SetCreationTime @path = 'C:\Temp\MyTest.txt', @creationTime = '2018-12-05'
```

