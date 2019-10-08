# Directory_GetCreationTime

`Directory_GetCreationTime` returns the creation date and time of a directory.

```csharp
Directory_GetCreationTime (
	@path NVARCHAR (MAX))
RETURNS DATETIME
```

## Parameters

 - **path**: The path of the directory.

## Returns

A DateTime object set to the creation date and time for the specified directory. This value is expressed in local time.

## Example

```csharp
SELECT SQLNET::Directory_GetCreationTime('C:\Logs')
```

