# Path_GetRandomFileName

`Path_GetRandomFileName` returns a random folder name or file name.

```csharp
Path_GetRandomFileName ()
RETURNS NVARCHAR (4000)
```

## Returns

A random folder name or file name.

## Example

```csharp
SELECT SQLNET::Path_GetRandomFileName()
```
