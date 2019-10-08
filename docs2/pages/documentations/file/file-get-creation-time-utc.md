# File_GetCreationTimeUtc

`File_GetCreationTimeUtc` returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.

```csharp
File_GetCreationTimeUtc (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain creation date and time information.

## Returns

A DateTime object set to the creation date and time for the specified file or directory. This value is expressed in UTC time.

## Example

```csharp
SELECT SQLNET::File_GetCreationTimeUtc('C:\Temp\MyTest.txt')
```

