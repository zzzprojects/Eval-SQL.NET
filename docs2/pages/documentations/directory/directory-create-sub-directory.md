# Directory_CreateSubDirectory

`Directory_CreateSubDirectory` creates a subdirectory or subdirectories on the specified path. 

```csharp
Directory_CreateSubDirectory 
    @path NVARCHAR (MAX), 
    @subDirectory NVARCHAR (MAX)
```

## Parameters

 - **path**: The directory path.
 - **subDirectory**: The name of sub directory to create.

## Example

```csharp
EXEC Directory_CreateSubDirectory @path = 'C:\Temp', @subDirectory = 'SubDir' 
```

