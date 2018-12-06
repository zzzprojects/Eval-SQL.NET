# DateTime

Represents an instant in time, typically expressed as a date and time of day.

| Name | Description | Example |
| :--- | :---------- | :------ |
| [DateTime_AddDays(currDate, value)](/datetime-add-days) | Returns a new DateTime that adds the specified number of days to the `currDate`. | [Try it]()|
| [DateTime_AddMonths(currDate, value)](/datetime-add-months) | Returns a new DateTime that adds the specified number of months to the `currDate`. | [Try it]()|
| [DateTime_AddYears(currDate, value)](/datetime-add-years) | Returns a new DateTime that adds the specified number of years to the `currDate`. | [Try it]()|
| [DateTime_Age(startDate, endDate)](/datetime-age) | Returns an age in number of years between `startDate` and `endDate`. | [Try it]()|
| [DateTime_DayOfWeek(currDate)](/datetime-dayofweek) | Returns the day of the week represented by `currDate`. | [Try it]()|
| [DateTime_DayOfYear(currDate)](/datetime-dayofyear) | Returns the day of the year represented by `currDate`. | [Try it]()|
| [DateTime_DaysInMonth(year, month)](/datetime-days-in-month) | Returns the number of days in the specified month and year. | [Try it]()|
| [DateTime_FromBinary(dateData)](/datetime-from-binary) | Deserializes a 64-bit binary value and recreates an original serialized DateTime object. | [Try it]()|
| [DateTime_FromFileTime(fileTime)](/datetime-from-file-time) | Converts the specified Windows file time to an equivalent local time. | [Try it]()|
| [DateTime_FromFileTimeUtc(fileTime)](/datetime-from-file-time-utc) | Converts the specified Windows file time to an equivalent UTC time. | [Try it]()|
| [DateTime_FromOADate(fileTime)](/datetime-from-oadate) | Converts the specified Windows file time to an equivalent UTC time. | [Try it]()|
| [DateTime_IsDaylightSavingTime(currDate)](/datetime-isdaylight-saving-time) | Indicates whether `currDate` instance of DateTime is within the daylight saving time range for the current time zone. | [Try it]()|
| [DateTime_IsLeapYear(year)](/datetime-isleap-year) | Returns an indication whether the specified year is a leap year. | [Try it]()|
| [DateTime_Now()](/datetime-now) | Returns a DateTime object that is set to the current date and time on this computer, expressed as the local time. | [Try it]()|
| [DateTime_Ticks(currDate)](/datetime-ticks) | Returns the number of ticks that represent the date and time of the `currDate` instance. | [Try it]()|
| [DateTime_ToBinary()](/datetime-totobinary) | Serializes the current DateTime object to a 64-bit binary value that subsequently can be used to recreate the DateTime object. | [Try it]()|
| [DateTime_Today()](/datetime-today) | Returns a DateTime object that is set to the today's date and the time component set to 00:00:00. | [Try it]()|
| [DateTime_ToFileTime()](/datetime-tofile-time) | Converts the value of the current DateTime object to a Windows file time. | [Try it]()|

