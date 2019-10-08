# Directory_DeleteAll

`Directory_DeleteAll` deletes a directory from a specified path including subdirectories, and files.

```csharp
Directory_DeleteAll @path NVARCHAR (MAX)
```

## Parameters

 - **path**: The directory to delete.

## Example

```csharp
EXEC Directory_DeleteAll @path = 'C:\Temp1'
```

