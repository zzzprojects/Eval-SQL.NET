# DateTime_ToOADate

`DateTime_ToOADate` converts the value of this instance to the equivalent OLE Automation date.

```csharp
DateTime_ToOADate (
	@currDate DATETIME
	)
RETURNS FLOAT (53)
```

## Parameters

 - **oaDate**: An OLE Automation Date value.

## Returns

A double-precision floating-point number that contains an OLE Automation date equivalent to the value of this instance.

## Example

```csharp
SELECT SQLNET::DateTime_ToOADate(39456)
```

