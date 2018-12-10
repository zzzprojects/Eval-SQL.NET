# File_GetCreationTime

`File_GetCreationTime` returns the creation date and time of the specified file or directory.

```csharp
File_GetCreationTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The file or directory for which to obtain creation date and time information.

## Returns

A DateTime object set to the creation date and time for the specified file or directory. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::File_GetCreationTime('C:\Temp\MyTest.txt')
```

