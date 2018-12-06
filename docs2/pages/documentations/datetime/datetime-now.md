# DateTime_Now

`DateTime_Now` returns a DateTime object that is set to the current date and time on this computer, expressed as the local time.

```csharp
DateTime_Now()
RETURNS DATETIME
```

## Returns

A DateTime object whose value is the current local date and time.

## Example

```csharp
SELECT SQLNET::DateTime_Now()
```

