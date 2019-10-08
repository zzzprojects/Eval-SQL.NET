# Directory_Delete

`Directory_Delete` deletes an empty directory from a specified path.

```csharp
Directory_Delete @path NVARCHAR (MAX)
```

## Parameters

 - **path**: The directory to delete.

## Example

```csharp
EXEC Directory_Delete @path = 'C:\Temp1'
```

