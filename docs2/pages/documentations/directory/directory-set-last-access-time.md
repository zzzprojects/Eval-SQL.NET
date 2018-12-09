# Directory_SetLastAccessTime

`Directory_SetLastAccessTime` sets the date and time the specified file or directory was last accessed.

```csharp
Directory_SetLastAccessTime 
	@path NVARCHAR (MAX),
	@lastAccessTime DATETIME
```

## Parameters

 - **path**: The path of the directory.
 - **lastAccessTime**: An object that contains the value to set for the access date and time of `path`. This value is expressed in local time.

## Example

```csharp
EXEC Directory_SetLastAccessTime @path = 'C:\destination', @lastAccessTime = '2018-12-05'
```

