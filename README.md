# External asset management in Sitecore
External Asset Management in Sitecore is an open source module guiding you about how to plug an external asset library into Sitecore.

## Integration with AWS-based asset library
The current module implementation assumes that the external asset library is based on [Amazon Web Services](https://docs.aws.amazon.com/general/latest/gr/Welcome.html) and shows all nuances in that regard. All specific AWS settings are defined in the config file:
- AssetManagement.Host
- AssetManagement.SearchUrl
- AssetsManagement.RegionName - AWS region
- AssetsManagement.ServiceName
- AssetsManagement.ContentType - content-type header
- AssetsManagement.SignedHeaders
- AssetsManagement.Algorithm - a signing algorithm to be used to hash the payload
- AssetManagement.AccessKey
- AssetManagement.SecretKey

If you plan integrating with any other external system then the general approach will remain the same.


# Contribution
Hope you found this module useful, your contributions and suggestions will be very much appreciated. Please submit a pull request.
