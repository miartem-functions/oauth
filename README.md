# Introduction 
Authorize Azure Active Directory users access to Azure Function using [Resource Owner Password Credentials Grant](https://tools.ietf.org/html/rfc6749#section-4.3) flow. 

Azure Function is exposed through HTTP trigger and can be activated via authorized request. Expected response is:
<pre>Hi there. This is '{username}@{directory}.onmicrosoft.com'</pre>

Client application should be able to compose HTTP requests in order to get an access token and call registered API. Such tools as [Fiddler](http://www.telerik.com/fiddler) can be used to mimic client application.

# Prerequisites
1. <div>
	<p>Register API application in Azure Active Directory</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppRegistrations.PNG" width="600">
	</p>
   </div>
2. <div>
	<p>Create registration</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistration.PNG" width="200">
	</p>
   </div>
3. <div>
	<p>Copy Application ID required for deployment</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistrationApplicationID.PNG" width="600">
	</p>
   </div>
4. <div>
	<p>Copy Resource URI required for deployment</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistrationResourceURI.PNG" width="600">
	</p>
   </div>

# Deployment
1. Initiate deployment 
   
   [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmiartem-functions%2Foauth%2Fmaster%2FEXP.Functions.OAuth%2FDeployment%2Ftemplate.json) 

2. <div>
	<p>Set unique resource group name, Application ID, and Resource URI</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FCustomDeployment.PNG" width="600">
	</p>
   </div>
3. <div>
	<p>Wait for successful deployment</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FResources.PNG" width="600">
	</p>
</div>

# Configuration
1. <div>
	<p>Register Client application in Azure Active Directory</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppRegistrationsApp.PNG" width="600">
	</p>
   </div>
2. <div>
	<p>Create registration</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppRegistration.PNG" width="200">
	</p>
   </div>
3. <div>
	<p>Add permissions to access registered API</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationPermissions.PNG" width="400">
	</p>
   </div>
4. <div>
	<p>Select registered API</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationSelectAPI.PNG" width="300">
	</p>
   </div>
5. <div>
	<p>Enable access to registered API</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationEnableAccess.PNG" width="300">
	</p>
   </div>
6. <div>
	<p>Add secret key in order to be able to get an access token</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationKeys.PNG" width="400">
	</p>
   </div>
7. <div>
	<p>Add key</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationAddKey.PNG" width="400">
	</p>
   </div>
8. <div>
	<p>Copy the generated secret key in order to use it further in HTTP requests</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationCopyKey.PNG" width="400">
	</p>
   </div>
9. <div>
	<p>Grant application permissions for all accounts in current directory</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationGrantPermissions.PNG" width="400">
	</p>
   </div>
   
   >Note: you must be an administrator in order to grant the permissions for all users in current directory 


# Usage
1. <div>
	<p>Get Directory ID</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FUsageDirectoryID.PNG" width="400">
	</p>
   </div>
2. <div>
	<p>Get Client Application ID</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FUsageApplicationID.PNG" width="600">
	</p>
   </div>
3. <div>
	<p>Get API Resource URI</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FUsageResourceURI.PNG" width="600">
	</p>
   </div>

4. Get Access Token for registered API    
    **Template**    
    <pre>
    POST https://login.microsoftonline.com/{directoryID}/oauth2/token HTTP/1.1    
    Host: login.microsoftonline.com
    Content-Type: application/x-www-form-urlencoded

    grant_type=password&client_id={applicationID}&client_secret={applicationSecretKey}&resource={apiResourceURI}&username={username}&password={password}</pre>        
    >Note: keep in mind that parameters in request should be encoded
    
    **Example**
    <pre>
    POST https://login.microsoftonline.com/c474f818-1bc3-4b8d-a19b-b11d5475445f/oauth2/token HTTP/1.1
    Host: login.microsoftonline.com
    Content-Type: application/x-www-form-urlencoded

    <b>grant_type</b>=password&<b>client_id</b>=d23a34a0-af8e-4198-8720-f1b47f598607&<b>client_secret</b>=GLmk7Kaj%2B%2B5dCC15%2B6gqAFhJcmpA5qvx1xVD%2F7TD9kA%3D&<b>resource</b>=https%3A%2F%2Fmicroforms.onmicrosoft.com%2F4c7c7f6a-bcf5-4f34-ba23-70b255742947&<b>username</b>=john.doe%40microforms.onmicrosoft.com&<b>password</b>=Yalo35041</pre>

5. Call API with requested access token    
    **Template**    
    <pre>
    GET https://fn-oauth-password-api.azurewebsites.net/api/greeting HTTP/1.1
    Host: fn-oauth-password-api.azurewebsites.net
    Authorization: Bearer {access_token}</pre>        
        
    **Example**
    <pre>
    GET https://fn-oauth-password-api.azurewebsites.net/api/greeting HTTP/1.1
    Host: fn-oauth-password-api.azurewebsites.net
    Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL21pY3JvZm9ybXMub25taWNyb3NvZnQuY29tLzRjN2M3ZjZhLWJjZjUtNGYzNC1iYTIzLTcwYjI1NTc0Mjk0NyIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0L2M0NzRmODE4LTFiYzMtNGI4ZC1hMTliLWIxMWQ1NDc1NDQ1Zi8iLCJpYXQiOjE1MDc5MTQwMTgsIm5iZiI6MTUwNzkxNDAxOCwiZXhwIjoxNTA3OTE3OTE4LCJhY3IiOiIxIiwiYWlvIjoiQVNRQTIvOEZBQUFBVXNtSG1qS2JFaFhINk1HcWd0bllRNktjUlRZSGtFYjBNYU9rZm5HeW5SMD0iLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiZDIzYTM0YTAtYWY4ZS00MTk4LTg3MjAtZjFiNDdmNTk4NjA3IiwiYXBwaWRhY3IiOiIxIiwiaXBhZGRyIjoiNDYuMTI2LjE3OS4xNjciLCJuYW1lIjoiSm9obiBEb2UiLCJvaWQiOiIxY2NmMzI0Zi1hZjBjLTQ5YTYtOTVhMS02MmVjYjE1OTdmMjciLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJjX3JJS29zdWVncGxfYXFYTFVKT3plMFh5UkVNYVJEaWNBUlBIS1lQZDNJIiwidGlkIjoiYzQ3NGY4MTgtMWJjMy00YjhkLWExOWItYjExZDU0NzU0NDVmIiwidW5pcXVlX25hbWUiOiJqb2huLmRvZUBtaWNyb2Zvcm1zLm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImpvaG4uZG9lQG1pY3JvZm9ybXMub25taWNyb3NvZnQuY29tIiwidmVyIjoiMS4wIn0.zs_lx3bXgSbMZUP4xvwNkxFBBJXDLuZ0yaqEcriRsbujVS8uyj025shdAudacgNmlxnBM5sW0U02ZlkZBnT94smgx_ZqocdvQpz0rX03WJAh3pGbAM8Mp7ZSWK1BERkA9ngrj7JCmXCiIXwmBmy1ymj5NswZiKW0-kqQkeRmvZqgsyDJf3xUauFcEUW39jgYbPfZbIeiIY4chbBP_M81Q3jd1-wc2dlX0KZoJ6ggtoIDPUPZuI-jMExb1KxeDEM7XZT8bPWXqaXlHrKNmXwfhSYx0xx7MgqyUBHuidwuSKDhEfd_SFrgRJp7pVtH9Dc5OfZ7pIF2q46RuwZbbtNREw
6. Process response
    <pre>Hi there. This is 'john.doe@microforms.onmicrosoft.com'</pre>
 
# Related Articles
- [Authentication Scenarios for Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios)
- [Integrating applications with Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-integrating-applications)
- [The OAuth 2.0 Authorization Framework](https://tools.ietf.org/html/rfc6749)