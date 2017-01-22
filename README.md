# Azure B2C integration in Web Forms 

This sample shows how to integrate Azure B2C in web forms application using that performs identity management with Azure AD B2C. It assumes you have some familiarity with Azure AD B2C. If you'd like to learn all that B2C has to offer, start with our documentation at aka.ms/aadb2c.

The app is a simple web application that performs sign-in, sign-up, edit-profile and sign-out functions with sign-in and signUp policies.  

##### Please note that this functionality is still in "preview"

## How To Run This Sample

Getting started is simple! To run this sample you will need:

- Visual Studio 2015
- An Azure subscription (a free trial is sufficient)

### Step 1:  Clone or download this repository

From your shell or command line:

`git clone https://github.com/Zen3InfoSolutions/B2C-WebForms-DotNet.git` 

### Step 2: Get your own Azure AD B2C tenant

You can also modify the sample to use your own Azure AD B2C tenant.  First, you'll need to create an Azure AD B2C tenant by following [these instructions](https://azure.microsoft.com/documentation/articles/active-directory-b2c-get-started).

### Step 3: Create your own policies

This sample uses three types of policies: a sign-in policy, a sign-up policy & profile editing policy.  Create one policy of each type by following [the instructions here](https://azure.microsoft.com/documentation/articles/active-directory-b2c-reference-policies).  You may choose to include as many or as few identity providers as you wish.

If you already have existing policies in your Azure AD B2C tenant, feel free to re-use those.  No need to create new ones just for this sample.

### Step 4: Create your own application

Now you need to create your own application in your B2C tenant, so that your app has its own Application ID.  You can do so following [the generic instructions here](https://azure.microsoft.com/documentation/articles/active-directory-b2c-app-registration).  Be sure to include the following information in your app registration:

- Enable the **Web App/Web API** setting for your application.
- Add **two** rediect_uris for your app.  Their values should take the form 
    - `http://localhost:58851/`
- Copy the Application ID generated for your application, so you can use it in the next step.

### Step 5: Configure the sample to use your Azure AD B2C tenant

Now you can replace the app's default configuration with your own.  

##### In the B2C-WebForms solution

open the web.config file and replace the client, tenant and policy names

```xml
    <add key="ida:Tenant" value="<<tenant-name>>" />
    <add key="ida:ClientId" value="<<applicationid>>" />
    <add key="ida:AadInstance" value="https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}" />
    <add key="ida:RedirectUri" value="http://localhost:58851/" />
    <add key="ida:SignUpPolicyId" value="<<signup-policy-name>>" />
    <add key="ida:SignInPolicyId" value="<<signin-policy-name>>" />
    <add key="ida:UserProfilePolicyId" value="<<editprofile-policy-name>>" />
```
### Step 6:  Run the sample

open the B2C-WebForms.sln in visual studio 2015. Right click on B2C-WebForms project and choose Set as Startup Project.

If there are issues with nuget package restore in B2C-WebForms project, open Package Manager Console and run

	Update-Package -Reinstall

Clean and rebuild the solution, and run it.  You can now sign up / sign in /edit profile to your application using the accounts you configured in your respective policies.
