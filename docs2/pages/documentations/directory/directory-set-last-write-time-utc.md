# Directory_SetLastWriteTimeUtc

`Directory_SetLastWriteTimeUtc` sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.
```csharp
Directory_SetLastWriteTimeUtc 
	@path NVARCHAR (MAX),
	@lastWriteTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to set the creation date and time information.
 - **lastWriteTime**: The date and time the directory was last written to. This value is expressed in local time.

## Example

```csharp
EXEC Directory_SetLastWriteTimeUtc @path = 'C:\destination', @lastWriteTime = '2018-12-05 8:00:00 AM'
```

