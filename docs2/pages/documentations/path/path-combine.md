# Path_Combine

`Path_Combine` combines two strings into a path.

```csharp
Path_Combine (
	@path1 NVARCHAR (4000),
	@path2 NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path1**: The first path to combine.
  - **path2**: The second path to combine.

## Returns

 - The combined paths. If one of the specified paths is a zero-length string, this method returns the other path. If `path2` contains an absolute path, this method returns `path2`.

## Example

```csharp
SELECT SQLNET::Path_Combine('C:\Temp\', 'MyTest.txt')
```
