# File_Decrypt

`File_Decrypt` decrypts a file that was encrypted by the current account using the [File_Encrypt](/file_encrypt) procedure.

```csharp
File_Decrypt 
	@path NVARCHAR (MAX)
```

## Parameters

 - **path**: A path that describes a file to decrypt.

## Example

```csharp
EXEC File_Decrypt @path = 'C:\Temp\MyTest.txt'
```

