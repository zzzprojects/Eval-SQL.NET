# Directory_SetCreationTimeUtc

`Directory_SetCreationTimeUtc` sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.

```csharp
Directory_SetCreationTimeUtc 
	@path NVARCHAR (MAX),
	@creationTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to set the creation date and time information.
 - **creationTime**: The date and time the file or directory was last written to. This value is expressed in UTC time.

## Example

```csharp
EXEC Directory_SetCreationTimeUtc @path = 'C:\destination', @creationTime = '2018-12-05  8:00:00 AM'
```

