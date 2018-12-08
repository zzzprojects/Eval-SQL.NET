# Directory_SetCreationTime

`Directory_SetCreationTime` sets the creation date and time for the specified file or directory.

```csharp
Directory_SetCreationTime 
	@path NVARCHAR (MAX),
	@creationTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to set the creation date and time information.
 - **creationTime**: The date and time the file or directory was last written to. This value is expressed in local time.

## Example

```csharp
EXEC Directory_SetCreationTime @path = 'C:\destination', @creationTime = '2018-12-05'
```

