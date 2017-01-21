
1. Create a function app using the App Service Plan.  This is required to [load certificates](https://github.com/Azure/azure-webjobs-sdk-script/issues/1032).
2. Copy all the libs into a shared directory
3. Upload management certificate public key to subscription and public/private key (pfx) to the App Service certificates

```
WEBSITE_LOAD_CERTIFICATES = * or CSV list of thumbprints
certificate-<subscription-id> = management certificate thumbprint
```
