# Reqular Expressions

## Definition

Use Regex flexibility to overcome "LIKE" and "PATINDEX" limitations. All Regex methods are also available such as;

 - IsMatch
 - Match
 - Matches
 - Replace
 - Split

### Find rows with invalid emails


```csharp
DECLARE @regex VARCHAR(255) = '^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$'
DECLARE @customer TABLE ( Email VARCHAR(255) )

INSERT  INTO @customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )

-- "Regex" is optional, you can directly use IsMatch
DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, pattern')
                                     .ValueString('pattern', @regex).Root()

-- SELECT 'invalid.com'
SELECT  *
FROM    @customer
WHERE   @valid_email.Val('email', Email).EvalBit() = 0
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/58f2b/1' %}

### Find and insert in a table, all websites from a text



```csharp
DECLARE @websites TABLE ( Website VARCHAR(250) )
DECLARE @regex VARCHAR(255) = '(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})'
DECLARE @post VARCHAR(MAX) = 'zzz ... zzz... http://zzzprojects.com ... zzzz
. zzz... https://github.com/zzzprojects/Eval-SQL.NET ... zzzz
. zzz... zzz... https://github.com/zzzprojects/Eval-Expression.NET ... zzzz
. zzz.... zzz.... zzz... https://github.com/zzzprojects/EntityFramework-Plus ... zzzz'

-- "Regex" is optional, you can directly use Matches
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Matches(input, pattern)')
                                .ValueString('input', @post)
								.ValueString('pattern', @regex)

-- INSERT result in table
INSERT  INTO @websites
        SELECT  CAST(Value_1 AS VARCHAR(250))
        FROM    dbo.SQLNET_EvalTVF_1(@sqlnet)

-- SELECT result
-- 'http://zzzprojects.com'
-- 'https://github.com/zzzprojects/Eval-SQL.NET'
-- 'https://github.com/zzzprojects/Eval-Expression.NET'
-- 'https://github.com/zzzprojects/EntityFramework-Plus'
SELECT * FROM @websites
```
{% include component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1111' %}
