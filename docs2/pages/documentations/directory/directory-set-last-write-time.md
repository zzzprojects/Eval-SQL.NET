# Directory_SetLastWriteTime

`Directory_SetLastWriteTime` sets the date and time the specified file or directory was last written to.

```csharp
Directory_SetLastWriteTime 
	@path NVARCHAR (MAX),
	@lastWriteTime DATETIME
```

## Parameters

 - **path**: The file or directory for which to set the creation date and time information.
 - **lastWriteTime**: The date and time the directory was last written to. This value is expressed in local time.

## Example

```csharp
EXEC Directory_SetLastWriteTime @path = 'C:\destination', @lastWriteTime = '2018-12-05'
```

