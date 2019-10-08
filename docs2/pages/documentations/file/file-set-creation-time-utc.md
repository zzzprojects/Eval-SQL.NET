# File_SetCreationTimeUtc

`File_SetCreationTimeUtc` sets the date and time, in coordinated universal time (UTC), that the file was created.

```csharp
File_SetCreationTimeUtc
	@path NVARCHAR (MAX),
	@creationTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain creation date and time information.
 - **creationTime**: A DateTime containing the value to set for the creation date and time of path. This value is expressed in UTC time.

## Example

```csharp
EXEC File_SetCreationTimeUtc @path = 'C:\Temp\MyTest.txt', @creationTime = '2018-12-05'
```

