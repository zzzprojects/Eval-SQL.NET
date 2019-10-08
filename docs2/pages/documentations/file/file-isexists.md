# File_IsExists

`File_IsExists` determines whether the specified file exists.

```csharp
File_IsExists (
	@path NVARCHAR (MAX)
	)
RETURNS BIT
```

## Parameters

 - **path**: The path of a file to check.

## Returns

`true` if path refers to an existing directory; `false` if the directory does not exist or an error occurs when trying to determine if the specified directory exists.

## Example

```csharp
SELECT SQLNET::File_IsExists('C:\Temp\MyTest.txt')
```

