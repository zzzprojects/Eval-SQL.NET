# DateTime_UtcNow

`DateTime_UtcNow` returns a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC) time.

```csharp
DateTime_UtcNow()
RETURNS DATETIME
```

## Returns

A DateTime object whose value is the current Coordinated Universal Time (UTC) date and time.

## Example

```csharp
SELECT SQLNET::DateTime_UtcNow()
```

