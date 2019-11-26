[![GitHub release](https://img.shields.io/github/release-date/kate-orlova/external-asset-management-in-sitecore.svg?style=flat)](https://github.com/kate-orlova/external-asset-management-in-sitecore/releases/tag/MVPRelease)
[![GitHub license](https://img.shields.io/github/license/kate-orlova/external-asset-management-in-sitecore.svg)](https://github.com/kate-orlova/external-asset-management-in-sitecore/blob/master/LICENSE)
![GitHub lanmguage count](https://img.shields.io/github/languages/count/kate-orlova/external-asset-management-in-sitecore.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/external-asset-management-in-sitecore.svg?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/external-asset-management-in-sitecore.svg?style=flat)

# External asset management in Sitecore
External Asset Management in Sitecore is an open source module guiding you about how to plug an external asset library into Sitecore, so that you can easily select a desired image in Sitecore Experience Editor to enrich the end user experience.

## Configuration
Prior to registering the external services in Sitecore one should implement a mechanism of accessing & processing the external assets. This solution consists of two classes:
- **ExternalService** for communication with the external service and searching for images;
- **ExternalImageProcessor** for resizing and cropping images.

### ExternalService class
The ExternalService class implements a search method across the external to Sitecore assets and has the following signature:

```ExternalServiceSearchResponse Search(string query, int startFrom, int pageSize)```

### ExternalImageProcessor class
The ExternalImageProcessor class implements two methods for image resizing and cropping with the next signatures:

```string Resize(string url, int width, string additionalParameters)```

```string Crop(string url, int width, int height)```

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

# License
The External Asset Management in Sitecore module is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if your experience was positive. 
