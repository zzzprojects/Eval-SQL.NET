# Directory_GetLastWriteTime

`Directory_GetLastWriteTime` returns the date and time the specified file or directory was last written to.

```csharp
Directory_GetLastWriteTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain access date and time information.

## Returns

A DateTime object that is set to the date and time the specified file or directory was last written to. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::Directory_GetLastWriteTime('C:\Logs')
```

