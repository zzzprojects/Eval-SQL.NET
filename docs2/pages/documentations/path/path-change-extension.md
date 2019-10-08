# Path_ChangeExtension

`Path_ChangeExtension` returns a new string in which all occurrences of a specified `oldValye` Unicode character or String in the `source` string are replaced with another specified `newValue` Unicode character or String.

```csharp
Path_ChangeExtension (
	@path NVARCHAR (4000),
	@extension NVARCHAR (4000)
	)
RETURNS NVARCHAR (4000)
```

## Parameters

  - **path**: The path information to modify.
  - **extension**: The new extension (with or without a leading period). Specify `null` to remove an existing extension from `path`.

## Returns

 - The modified path information.

## Example

```csharp
SELECT SQLNET::Path_ChangeExtension('C:\Temp\MyTest.txt', '.ext')
```
