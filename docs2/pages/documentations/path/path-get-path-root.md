# Path_GetPathRoot

`Path_GetPathRoot` returns the root directory information of the specified path.

```csharp
Path_GetPathRoot (
	@path NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path from which to obtain root directory information.

## Returns

The root directory of `path`, or `null` if `path` is `null`, or an empty string if `path` does not contain root directory information.

## Example

```csharp
SELECT SQLNET::Path_GetPathRoot('MyTest.txt')
```
