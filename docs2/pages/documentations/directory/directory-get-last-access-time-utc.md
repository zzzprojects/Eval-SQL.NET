# Directory_GetLastAccessTimeUtc

`Directory_GetLastAccessTimeUtc` returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

```csharp
Directory_GetLastAccessTimeUtc (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain access date and time information.

## Returns

A DateTime object that is set to the date and time the specified file or directory was last accessed. This value is expressed in UTC time.

## Example

```csharp
SELECT SQLNET::Directory_GetLastAccessTimeUtc('C:\Logs')
```

