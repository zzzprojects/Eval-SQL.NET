# File_SetLastAccessTime

`File_SetLastAccessTime` sets the date and time the specified file was last accessed.

```csharp
File_SetLastAccessTime
	@path NVARCHAR (MAX),
	@lastAccessTime DATETIME
```

## Parameters

 - **path**: The file for which to set the access date and time information.
 - **lastAccessTime**: A DateTime containing the value to set for the last access date and time of path. This value is expressed in local time.

## Example

```csharp
EXEC File_SetLastAccessTime @path = 'C:\Temp\MyTest.txt', @lastAccessTime = '2018-12-05'
```

