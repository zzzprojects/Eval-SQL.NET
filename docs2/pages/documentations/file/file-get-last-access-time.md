# File_GetLastAccessTime

`File_GetLastAccessTime` returns the date and time the specified file or directory was last accessed.

```csharp
File_GetLastAccessTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain access date and time information.

## Returns

A DateTime object set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::File_GetLastAccessTime('C:\Temp\MyTest.txt')
```

