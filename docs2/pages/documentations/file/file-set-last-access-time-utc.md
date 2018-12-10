# File_SetLastAccessTimeUtc

`File_SetLastAccessTimeUtc` sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.

```csharp
File_SetLastAccessTimeUtc
	@path NVARCHAR (MAX),
	@lastAccessTime DATETIME
```

## Parameters

 - **path**: The file for which to set the access date and time information.
 - **lastAccessTime**: A DateTime containing the value to set for the last access date and time of path. This value is expressed in UTC time.

## Example

```csharp
EXEC File_SetLastAccessTimeUtc @path = 'C:\Temp\MyTest.txt', @lastAccessTime = '2018-12-05'
```

