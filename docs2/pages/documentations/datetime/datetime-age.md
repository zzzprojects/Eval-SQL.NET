# DateTime_Age

`DateTime_Age` returns an age in number of years between `startDate` and `endDate`.

```csharp
DateTime_Age (
	@startDate DATETIME, 
	@endDate DATETIME
	)
RETURNS FLOAT (53)
```

## Parameters

  - **startDate**: The start datetime object.
  - **endDate**: The end datetime object.

## Returns

An age in number of years between `startDate` and `endDate`.

## Example

```csharp
SELECT SQLNET::DateTime_Age('2002-05-25', '2018-12-01')
```

