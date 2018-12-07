# Directory_Exists

`Directory_Exists` determines whether the given path refers to an existing directory on disk.

```csharp
Directory_Exists (
	@path NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

 - **path**: The path to test.

## Returns

`true` if path refers to an existing directory; `false` if the directory does not exist or an error occurs when trying to determine if the specified directory exists.

## Example

```csharp
SELECT SQLNET::Directory_Exists('C:\Temp')
```

