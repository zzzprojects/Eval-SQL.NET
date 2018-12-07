# Directory_GetCreationTimeUtc

`Directory_GetCreationTimeUtc` returns the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.

```csharp
Directory_GetCreationTimeUtc (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The path of the directory.

## Returns

A DateTime object set to the creation date and time for the specified directory. This value is expressed in UTC time.

## Example

```csharp
SELECT SQLNET::Directory_GetCreationTimeUtc('C:\Logs')
```

