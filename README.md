# External asset management in Sitecore
External Asset Management in Sitecore is an open source module guiding you about how to plug an external asset library into Sitecore, so that you can easily select a desired image in Sitecore Experience Editor.

## Configuration
Prior to registering the external services in Sitecore one should implement a mechanism of accessing & processing the external assets. This solution consists of two classes:
- **ExternalService** for communication with the external service and searching for images;
- **ExternalImageProcessor** for resizing and cropping images.

## Integration with AWS-based asset library
The current module implementation assumes that the external asset library is based on [Amazon Web Services](https://docs.aws.amazon.com/general/latest/gr/Welcome.html) and shows all nuances in that regard. All specific AWS settings are defined in the config file:
- **AssetManagement.Host** - a hostname; 
- **AssetManagement.SearchUrl** - a search service link;
- **AssetsManagement.RegionName** - an AWS region;
- **AssetsManagement.ServiceName** - a name of AWS API Gateway component service for API execution;
- **AssetsManagement.ContentType** - a content-type header;
- **AssetsManagement.SignedHeaders** - a list of signed headers;
- **AssetsManagement.Algorithm** - a signing algorithm to be used to hash the payload;
- **AssetManagement.AccessKey** - an access key;
- **AssetManagement.SecretKey** - a secret key.

If you plan integrating with any other external system then the general approach will remain the same.


# Contribution
Hope you found this module useful, your contributions and suggestions will be very much appreciated. Please submit a pull request.
