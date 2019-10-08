# Path_IsPathRooted

`Path_IsPathRooted` gets a value indicating whether the specified path string contains a root.

```csharp
Path_IsPathRooted (
	@path NVARCHAR (4000)
	)
RETURNS BIT
```

## Parameters

  - **path**: The path to test.

## Returns

`true` if path contains a root; otherwise, `false`.

## Example

```csharp
SELECT SQLNET::Path_IsPathRooted('C:\Temp\MyTest.txt')
SELECT SQLNET::Path_IsPathRooted('Temp\MyTest.txt')
```
