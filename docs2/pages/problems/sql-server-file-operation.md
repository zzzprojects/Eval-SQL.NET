# SQL Server File Operation

## Introduction

Reading and writing files are basic requirements for importing/exporting data through SQL server jobs. The xp_cmdshell stored procedure is often used but not a lot of developers and DBA are comfortable coding with it. The syntax makes the code often ugly, hard to develop and expensive to maintain due to the lack of good documentation, flexibility and understanding.

Some DBA don't recommend and even ban all use of the procedure xp_cmdshell from their environment due to security issues.

Eval SQL.NET allows you to use C# features and objects such as FileInfo and DirectoryInfo directly in T-SQL and improves code readability. It's the safest alternative to replace xp_cmdshell to access external resources by letting impersonate the current user context.

It's safe and easy to use.


```csharp
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => x.FullName).OrderBy(x => x).ToList();')
    .Impersonate()

-- SELECT * FROM DesktopFiles ORDER BY File.Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
```

## SQL File Operation - Better flexibility

### Problem

You need to perform file operations but SQL xp_cmdshell limits you.

 - Return multiple column result back
 - Passing parameter easier
 - Impersonation

### Solution

Eval SQL.NET lets you use C# language and makes file operations very easy to perform.


```csharp

-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @FileInfo TABLE
    (
      FilePath VARCHAR(255) ,
      FileContent VARCHAR(MAX)
    )

DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*").Select(x => new Tuple<string, string>(
                                       x.FullName, File.ReadAllText(x.FullName)))
                          .OrderBy(x => x).ToList();').Impersonate()

-- SELECT Path, FileText FROM DesktopFiles ORDER BY File.Fullname
INSERT  INTO @FileInfo
        EXEC dbo.SQLNET_EvalResultSet @sqlnet

SELECT  *
FROM    @FileInfo

```


## SQL File Operation - Better maintainability

### Problem

You need to develop a file operation but you're afraid your code will be very hard to maintain.

### Solution

Eval SQL.NET improves the maintainability by letting you use well known and well documented C# objects such as DirectoryInfo and FileInfo.


```csharp
-- REQUIRE EXTERNAL_ACCESS permission
-- BACKUP all ".txt" files created before 3 days ago
-- RETURN the number of files affected

SELECT SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string backupPath = Path.Combine(path, "Backup_" + DateTime.Now.ToString("yyyyMMdd"));

DirectoryInfo desktopDirectory = new DirectoryInfo(path);
DirectoryInfo backupDirectory = new DirectoryInfo(backupPath);

// ENSURE the directory exists
backupDirectory.Create();

// GET file to backup
var backupFiles = desktopDirectory.GetFiles("*.txt")
                                  .Where(x => x.CreationTime < DateTime.Now.AddDays(-3))
                                  .ToList();

// COPY files to backup directory
backupFiles.ForEach(x => x.CopyTo(x.FullName.Replace(path, backupPath)));

// RETURN the number of affected files
return backupFiles.Count;
').Impersonate().EvalReadAccessInt() as Result

```

## SQL File Operation - Better readability

### Problem

You need to perform file operations but the code soon becomes hard to understand and to change.

### Solution

Eval SQL.NET improves the readability by letting you use well known C# objects that wrap logic such as DirectoryInfo and FileInfo.

## SQL File Operation - Better security

### Problem

You need to perform file operations but you don't want to enable xp_cmdshell in your SQL Server.

### Solution

Eval SQL.NET lets you perform file operations and change the security context to impersonate the credential of the one who runs the T-SQL statements.

## Conclusion

Eval SQL.NET grants you easy access to external resources through the C# language in T-SQL jobs and objects.

It's a safe SQL alternative to xp_cmdshell and offers multiple advantages:

 - Improve Flexibility: Access to C# Language in SQL
 - Improve Maintainability: FileInfo and DirectoryInfo are well-known/documented objects
 - Improve Readability: C# is without a doubt easier to read than T-SQL for complex code
 - Improve Security: Impersonate user context

