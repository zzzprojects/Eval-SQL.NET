# File_GetLastAccessTimeUtc

`File_GetLastAccessTimeUtc` returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.

```csharp
File_GetLastAccessTimeUtc (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain access date and time information.

## Returns

A DateTime object set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.

## Example

```csharp
SELECT SQLNET::File_GetLastAccessTimeUtc('C:\Temp\MyTest.txt')
```

