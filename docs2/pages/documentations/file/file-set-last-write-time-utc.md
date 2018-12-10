# File_SetLastWriteTimeUtc

`File_SetLastWriteTimeUtc` sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.

```csharp
File_SetLastWriteTimeUtc
	@path NVARCHAR (MAX),
	@lastWriteTime DATETIME
```

## Parameters

 - **path**: The file for which to set the date and time information.
 - **lastWriteTime**: A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.

## Example

```csharp
EXEC File_SetLastWriteTimeUtc @path = 'C:\Temp\MyTest.txt', @lastWriteTime = '2018-12-05'
```

