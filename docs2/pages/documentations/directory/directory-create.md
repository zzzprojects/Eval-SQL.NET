# Directory_Create

`Directory_Create` creates all directories and subdirectories in the specified path unless they already exist.

```csharp
Directory_Create @path NVARCHAR (MAX)
```

## Parameters

 - **path**: The directory to create.

## Example

```csharp
EXEC Directory_Create @path = 'C:\Temp'
```

