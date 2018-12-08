# Directory_GetLastAccessTime

`Directory_GetLastAccessTime` returns the date and time the specified file or directory was last accessed.

```csharp
Directory_GetLastAccessTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain access date and time information.

## Returns

A DateTime object that is set to the date and time the specified file or directory was last accessed. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::Directory_GetLastAccessTime('C:\Logs')
```

