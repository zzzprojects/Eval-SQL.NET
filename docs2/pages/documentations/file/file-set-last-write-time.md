# File_SetLastWriteTime

`File_SetLastWriteTime` sets the date and time that the specified file was last written to.

```csharp
File_SetLastWriteTime
	@path NVARCHAR (MAX),
	@lastWriteTime DATETIME
```

## Parameters

 - **path**: The file for which to set the date and time information.
 - **lastWriteTime**: A DateTime containing the value to set for the last write date and time of path. This value is expressed in local time.

## Example

```csharp
EXEC File_SetLastWriteTime @path = 'C:\Temp\MyTest.txt', @lastWriteTime = '2018-12-05'
```

