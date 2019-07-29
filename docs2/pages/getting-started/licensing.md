# Licensing

## Evaluation Period
- You can evaluate the library for several months before purchasing it.
- The latest version always contains a trial that expires at the **end of the month**. 
- You can extend your trial for several months by downloading the latest version at the beginning of each month.

## How can I purchase the library?
- You can purchase the library [here](/pricing)
- Upon purchase, you will receive an email with a license name and a license key.
- Make sure to check your **SPAM** folder if you don't receive the license within 24h.

## How can I get a free license for a personal or academic purpose?
We don't offer free licenses.

However, you can benefit from all the prime features for personal or academic projects for free by downloading the trial at the beginning of every month.

## Setup License

Upon purchase completion, an email will be sent with your license key information.


```csharp
CREATE PROCEDURE SQLNET_Configuration
AS
BEGIN
	-- The procedure is automatically called when the server restart/assembly load
	-- If the assembly is already loaded, a manual execution is required
	-- EXEC SQLNET_Configuration
	DECLARE @isValid BIT = SQLNET::AddLicense('[LicenseName]', '[LicenseKey]')

	-- SELECT 1
	SELECT @isValid
END
```

_We recommend to always re-install the Eval-SQL.NET Script after enabling the license to ensure everything works if the server restarts._

You can verify if the license is valid with the following command:


```csharp
-- RETURN 1 if the license is valid.
SELECT SQLNET::AddLicense('[LicenseName]', '[LicenseKey]')

```

