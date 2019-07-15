# SQL Server Regex

## Introduction

Finding or replacing text in SQL is a very frequent scenario. "LIKE" and "PATINDEX" are often used but, unfortunately, are not close to be as powerful and offering the same possibilities as regular expression (Regex) does.

Eval SQL.NET lets you use and exploit fully C# regular expression features directly in T-SQL stored procedures, functions and triggers. It's possible to use regex in SQL search condition and select statement.


```csharp

DECLARE @customer TABLE ( Email VARCHAR(255) )

INSERT  INTO @customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )

DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, 
@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")')

-- SELECT 'invalid.com'
SELECT * FROM @customer WHERE @valid_email.Val('email', Email).EvalBit() = 0

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/213f9/1' %}


## SQL Regex - IsMatch

### Problem

You need to perform a rule validation or search with a condition to find valid/invalid rows but "LIKE" and "PATINDEX" limitations don't cover your requirements:

 - Find customer with invalid email
 - Find customer with invalid phone
 - Find customer with invalid website
 - Validate password

### Solution

SQL Regex IsMatch indicates whether the regular expression finds a match in the string or not.


```csharp

DECLARE @customer TABLE ( Email VARCHAR(255) )

INSERT  INTO @customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )

DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, 
@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")')

-- SELECT 'invalid.com'
SELECT * FROM @customer WHERE @valid_email.ValueString('email', Email).EvalBit() = 0

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/213f9/2' %}

## SQL Regex - Match

### Problem

You need to extract the first occurrence from a string such as user profile description:

 - Extract the first email
 - Extract the first phone
 - Extract the first website

### Solution

SQL Regex Match searches in a string for the first occurrence of the regular expression and returns the match.


```csharp

DECLARE @shortDescription VARCHAR(800) = 'zzz ... zzz... http://zzzprojects.com ... zzzz'
DECLARE @website VARCHAR(255) = NULL;

IF ( @website IS NULL )
    BEGIN
	-- IF user has not specified a website, try to get it from the short description
        SET @website = SQLNET::New('
string value = Regex.Match(shortDescription, 
"(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})").Value;

return value != "" ? value : null;
')
	                          .ValueString('shortDescription', @shortDescription)
						      .EvalString();
    END

-- return 'http://zzzprojects.com'
SELECT @website

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1012' %}


## SQL Regex - Matches

### Problem

You need to extract all occurrences from a string such as blog post:

 - Extract all emails
 - Extract all phones
 - Extract all websites

### Solution

SQL Regex Matches searches in the string for all occurrences of the regular expression and returns all the matches.


```csharp

DECLARE @post VARCHAR(800) = 'zzz ... zzz... http://zzzprojects.com ... zzzz
. zzz... https://github.com/zzzprojects/Eval-SQL.NET ... zzzz
. zzz... zzz... https://github.com/zzzprojects/Eval-Expression.NET ... zzzz
. zzz.... zzz.... zzz... https://github.com/zzzprojects/EntityFramework-Plus ... zzzz
'

DECLARE @websites TABLE ( Website VARCHAR(250) )

DECLARE @sqlnet_matchs SQLNET = SQLNET::New('
var matches = Regex.Matches(post, 
"(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})");

var list = new List<string>();
foreach(Match match in matches)
{
	list.Add(match.Value);
}

return list;
').ValueString('post', @post)


INSERT  INTO @websites
        SELECT  CAST(Value_1 AS VARCHAR(250))
        FROM    dbo.SQLNET_EvalTVF_1(@sqlnet_matchs)

-- SELECT 'http://zzzprojects.com'
-- SELECT 'https://github.com/zzzprojects/Eval-SQL.NET'
-- SELECT 'https://github.com/zzzprojects/Eval-Expression.NET'
-- SELECT 'https://github.com/zzzprojects/EntityFramework-Plus'
SELECT * FROM @websites

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/d48e7/3' %}

## SQL Regex - Replace

### Problem

You need to convert, remove or substitute a text with a specific format:

 - Convert plain url to html link
 - Remove phones
 - Substitute name in text template

### Solution

SQL Regex Replace searches for strings that match a regular expression pattern and replaces a value with a replacement string.


```csharp

DECLARE @post VARCHAR(800) = 'website: http://zzzprojects.com'

SET @post = SQLNET::New('
var input = post;
var pattern = @"(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})";
var replacement = "<a href=\"$1\">$1</a>";

return Regex.Replace(input, pattern, replacement);
').ValueString('post', @post).EvalString()

-- SELECT 'website: <a href="http://zzzprojects.com">http://zzzprojects.com</a>'
SELECT @post

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/b308e/1' %}

## SQL Regex - Split

### Problem

You need to split a string but the traditional "fn_split" method is limited and doesn't cover your scenario:

 - Use multiple delimiter
 - Keep the delimiter in value
 - Split the first X occurrences

### Solution

SQL Regex Split lets you split a string into an array of substrings using a regular expression.


```csharp

DECLARE @s VARCHAR(MAX) = '1, 2, 3; 4; 5'
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Split(input, ",|;")')

SELECT  *
FROM    dbo.SQLNET_EvalTVF_1(@sqlnet.ValueString('input', @s))

```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1069' %}

### Discussion

If you are currently using an fn_split User-Defined Functions (UDF), this benchmark will probably make you change your mind!

|Methods	|1,000 rows	|10,000 rows	|100,000 rows	|1,000,000 rows |
|:--------- |:--------- |:------------- |:------------- |:------------- |
|Eval SQL.NET	|4 ms	|13 ms	|160 ms	|1,650 ms|
fn_split (TVF)	|100 ms	|625 ms	|5,500 ms	|55,000 ms|

## Conclusion

Eval SQL.NET offers all advanced C# regular expression features in T-SQL statements and search conditions. Even more, you can use C# syntax to return from SQL what you really want and not only the regex result.

While it should never replace scenarios where pure SQL operators/functions such as "LIKE" and "PATINDEX" are sufficient, Eval SQL.NET will help you easily cover all unsupported ones.

