# Introduction 
Authorize Azure Active Directory users access to Azure Function using [Resource Owner Password Credentials Grant](https://tools.ietf.org/html/rfc6749#section-4.3) flow.

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
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistrationApplicationID.PNG" width="400">
	</p>
   </div>
# Deployment
1. Initiate deployment 
   
   [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmiartem-functions%2Foauth%2Fmaster%2FEXP.Functions.OAuth%2FDeployment%2Ftemplate.json) 

2. <div>
	<p>Set unique resource group name and Application ID</p>
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
	<p>Grant application permissions for all accounts in current directory</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationGrantPermissions.PNG" width="400">
	</p>
   </div>
   
   >Note: you must be an administrator in order to grant the permissions for all users in current directory 

7. <div>
	<p>Add secrete key in order to be able to get a token</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationKeys.PNG" width="400">
	</p>
   </div>
8. <div>
	<p>Add key</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationAddKey.PNG" width="400">
	</p>
   </div>
9. <div>
	<p>Copy the generated Client application secret key in order to use it further in HTTP requests</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppConfigurationCopyKey.PNG" width="400">
	</p>
   </div>

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
    <pre>
    POST /{directoryID}/oauth2/token    
    Host: login.microsoftonline.com
    Content-Type: application/x-www-form-urlencoded

    grant_type=password&client_id={applicationID}&client_secret={applicationSecretKey}&resource={apiResourceURI}&username={username}&password={password}</pre>        
    >Note: keep in mind that parameters in request should be encoded
    
    **Example**
    <pre>
    POST /c474f818-1bc3-4b8d-a19b-b11d5475445f/oauth2/token    
    Host: login.microsoftonline.com
    Content-Type: application/x-www-form-urlencoded

    <b>grant_type</b>=password&<b>client_id</b>=d23a34a0-af8e-4198-8720-f1b47f598607&<b>client_secret</b>=cNT5AHjP0%2FIgU4XlN%2FMzVOQZyjilDp5j%2BUYx6vbi3UM%3D&<b>resource</b>=https%3A%2F%2Fmicroforms.onmicrosoft.com%2F4c7c7f6a-bcf5-4f34-ba23-70b255742947&<b>username</b>=john.doe%40microforms.onmicrosoft.com&<b>password</b>=Yalo35041</pre>
 
# Related Articles
- [Authentication Scenarios for Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios)
- [Integrating applications with Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-integrating-applications)
- [The OAuth 2.0 Authorization Framework](https://tools.ietf.org/html/rfc6749)