# Path_GetTempPath

`Path_GetTempPath` returns the path of the current user's temporary folder.

```csharp
Path_GetTempPath ()
RETURNS NVARCHAR (4000)
```

## Returns

The path to the temporary folder, ending with a backslash.

## Example

```csharp
SELECT SQLNET::Path_GetTempPath()
```
