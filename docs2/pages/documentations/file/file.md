# File

Provides methods for the creation, copying, deletion, moving, and opening of a single file.

| Name | Description | Example |
| :--- | :---------- | :------ |
| [File_AppendAllText(path, content)](/file-append-all-text) | Appends the specified stringto the file, creating the file if it does not already exist. | [Try it]()|
| [File_Copy(sourceFileName, destFileName, overwrite)](/file-append-all-text) | Copies an existing file to a new file. | [Try it]()|
| [File_Create(path)](/file-create) | Creates or overwrites a file in the specified path. | [Try it]()|
| [File_Decrypt(path)](/file-decrypt) | Decrypts a file that was encrypted by the current account using the [File_Encrypt](/file_encrypt) procedure. | [Try it]()|
| [File_Delete(path)](/file-delete) | Deletes the specified file. | [Try it]()|
| [File_Encrypt(path)](/file-encrypt) | Encrypts a file so that only the account used to encrypt the file can decrypt it. | [Try it]()|
| [File_GetCreationTime(path)](/file-get-creation-time) | Returns the creation date and time of the specified file or directory. |  [Try it]()|
| [File_GetCreationTimeUtc(path)](/file-get-creation-time-utc) | Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory. |  [Try it]()|
| [File_GetLastAccessTime(path)](/file-get-last-access-time) | Returns the date and time the specified file or directory was last accessed. |  [Try it]()|
| [File_GetLastAccessTimeUtc(path)](/file-get-last-access-time-utc) | Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed. |  [Try it]()|
| [File_GetLastWriteTime(path)](/file-get-last-write-time) | Returns the date and time the specified file or directory was last written to. |  [Try it]()|
| [File_GetLastWriteTimeUtc(path)](/file-get-last-write-time-utc) | Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to. |  [Try it]()|
| [File_IsExists(path)](/file-isexists) | Determines whether the specified file exists. | [Try it]()|
| [File_Move(sourceFileName, destFileName)](/file-move) | Moves a specified file to a new location, providing the option to specify a new file name. | [Try it]()|
| [File_ReadAllText(path)](/file-move) | Opens a text file, reads and returns all the text in the file, and then closes the file. | [Try it]()|
| [File_Replace(sourceFileName, destFileName, destBackupFileName, ignoreMetadataErrors)](/file-replace) | Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors. | [Try it]()|
| [File_SetCreationTime(path, creationTime)](/file-set-creation-time) | Sets the date and time the file was created. | [Try it]()|
| [File_SetCreationTimeUtc(path, creationTime)](/file-set-creation-time-utc) | Sets the date and time, in coordinated universal time (UTC), that the file was created. | [Try it]()|
| [File_SetLastAccessTime(path, lastAccessTime)](/file-set-last-access-time) | Sets the date and time the file was created. | [Try it]()|
| [File_SetLastAccessTimeUtc(path, lastAccessTime)](/file-set-last-access-time-utc) | Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed. | [Try it]()|
| [File_SetLastWriteTime(path, lastWriteTime)](/file-set-last-write-time) | Sets the date and time that the specified file was last written to. | [Try it]()|
| [File_SetLastWriteTimeUtc(path, lastWriteTime)](/file-set-last-write-time-utc) | Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to. | [Try it]()|
| [File_WriteAllText(path, contents)](/file-write-all-text) | Creates a new file, write the contents to the file, and then closes the file. If the target file already exists, it is overwritten. | [Try it]()|
