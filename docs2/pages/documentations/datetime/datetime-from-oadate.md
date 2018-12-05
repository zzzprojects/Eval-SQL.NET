# DateTime_FromOADate

`DateTime_FromOADate` returns a DateTime equivalent to the specified OLE Automation Date.
```csharp
DateTime_FromOADate (
	@oaDate FLOAT (53)
	)
RETURNS DATETIME
```

## Parameters

 - **oaDate**: An OLE Automation Date value.

## Returns

An object that represents the same date and time as `oaDate`.

## Example

```csharp
SELECT SQLNET::DateTime_FromOADate(39456)
```

