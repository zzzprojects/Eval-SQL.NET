# File_Encrypt

`File_Encrypt` encrypts a file so that only the account used to encrypt the file can decrypt it.

```csharp
File_Encrypt 
	@path NVARCHAR (MAX)
```

## Parameters

 - **path**: A path that describes a file to encrypt.

## Example

```csharp
EXEC File_Encrypt @path = 'C:\Temp\MyTest.txt'
```

