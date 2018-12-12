# Path_GetTempFileName

`Path_GetTempFileName` creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.

```csharp
Path_GetTempFileName ()
RETURNS NVARCHAR (4000)
```

## Returns

The full path of the temporary file.

## Example

```csharp
SELECT SQLNET::Path_GetTempFileName()
```
