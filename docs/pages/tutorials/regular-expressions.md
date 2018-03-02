---
permalink: regular-expressions
---

## Definition

Use Regex flexibility to overcome "LIKE" and "PATHINDEX" limitations. All Regex methods are also available such as;

 - IsMatch
 - Match
 - Matches
 - Replace
 - Split

### Find rows with invalid email

<div class="sqlfiddle">
                <pre class="schema">
CREATE TABLE customer ( Email VARCHAR(255) )

INSERT  INTO customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )
                </pre>
                <pre class="sql">
DECLARE @regex VARCHAR(255) = '^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$'


-- "Regex" is optional, you can directly use IsMatch
DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, pattern')
                                     .ValueString('pattern', @regex).Root()

-- SELECT 'invalid.com'
SELECT  *
FROM    customer
WHERE   @valid_email.Val('email', Email).EvalBit() = 0
                </pre>
</div>

### Find and insert in a table, all website from a text

<div class="sqlfiddle">
                <pre class="schema">
                </pre>
                <pre class="sql"> 
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

-- 'http://zzzprojects.com'
-- 'https://github.com/zzzprojects/Eval-SQL.NET'
-- 'https://github.com/zzzprojects/Eval-Expression.NET'
-- 'https://github.com/zzzprojects/EntityFramework-Plus'
        SELECT  CAST(Value_1 AS VARCHAR(250)) as websites
        FROM    dbo.SQLNET_EvalTVF_1(@sqlnet)
                </pre>
</div>
