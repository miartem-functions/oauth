# Introduction 
Authorize Azure Active Directory users access to Azure Function using [Resource Owner Password Credentials Grant](https://tools.ietf.org/html/rfc6749#section-4.3) flow.

# Prerequisites
1. <div>
	<p>Register API application in Azure Active Directory</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FAppRegistrations.PNG" width="600" title="Custom Deployment">
	</p>
   </div>
2. <div>
	<p>Create registration</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistration.PNG" width="200" title="Custom Deployment">
	</p>
   </div>
3. <div>
	<p>Copy Application ID required for deployment</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FApiRegistrationApplicationID.PNG" width="400" title="Custom Deployment">
	</p>
   </div>
# Deployment
1. Initiate deployment 
   
   [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmiartem-functions%2Foauth%2Fmaster%2FEXP.Functions.OAuth%2FDeployment%2Ftemplate.json) 

2. <div>
	<p>Set unique resource group name and Application ID</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FCustomDeployment.PNG" width="600" title="Custom Deployment">
	</p>
   </div>
3. <div>
	<p>Wait for successful deployment</p>
	<img src="EXP.Functions.OAuth%2FDeployment%2FDocumentation%2FImages%2FResources.PNG" width="600" title="Resources">
	</p>
</div>

# Configuration
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)

# Usage
# Related Articles
- [Authentication Scenarios for Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios)
- [The OAuth 2.0 Authorization Framework](https://tools.ietf.org/html/rfc6749)