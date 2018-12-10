# File_GetLastWriteTime

`File_GetLastWriteTime` returns the date and time the specified file or directory was last written to.

```csharp
File_GetLastWriteTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain write date and time information.

## Returns

A DateTime object set to the date and time that the specified file or directory was last written to. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::File_GetLastWriteTime('C:\Temp\MyTest.txt')
```

