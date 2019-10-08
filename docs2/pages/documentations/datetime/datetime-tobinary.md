# DateTime_ToBinary

`DateTime_ToBinary` serializes the `currDate` object to a 64-bit binary value that subsequently can be used to recreate the DateTime object.

```csharp
DateTime_ToBinary (
	@currDate DATETIME
	)
RETURNS BIGINT
```

## Parameters

 - **currDate**: The current datetime object.

## Returns

A 64-bit signed integer that encodes the `DateTime.Kind` and `DateTime.Ticks` properties.

## Example

```csharp
DECLARE @var BIGINT
SELECT @var = SQLNET::DateTime_ToBinary('2015-5-25')
SELECT SQLNET::DateTime_FromBinary(@var)
```

