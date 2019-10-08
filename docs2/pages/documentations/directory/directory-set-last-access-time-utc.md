# Directory_SetLastAccessTimeUtc

`Directory_SetLastAccessTimeUtc` sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

```csharp
Directory_SetLastAccessTimeUtc 
	@path NVARCHAR (MAX),
	@lastAccessTime DATETIME
```

## Parameters

 - **path**: The path of the directory.
 - **lastAccessTime**: An object that contains the value to set for the access date and time of `path`. This value is expressed in UTC time.

## Example

```csharp
EXEC Directory_SetLastAccessTimeUtc @path = 'C:\destination', @lastAccessTime = '2018-12-05 8:00:00 AM'
```

