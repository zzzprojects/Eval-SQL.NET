# DateTime_FromBinary

`DateTime_FromBinary` deserializes a 64-bit binary value and recreates an original serialized DateTime object.

```csharp
DateTime_FromBinary (
	@dateData BIGINT
	)
RETURNS DATETIME
```

## Parameters

 - **dateData**: A 64-bit signed integer that encodes the `DateTime.Kind` property in a 2-bit field and the `DateTime.Ticks` property in a 62-bit field.

## Returns

An object that is equivalent to the DateTime object that was serialized by the [DateTime_ToBinary()](/datetime-tobinary) method.

## Example

```csharp
DECLARE @var BIGINT
SELECT @var = SQLNET::DateTime_ToBinary('2015-5-25')
SELECT SQLNET::DateTime_FromBinary(@var)
```

