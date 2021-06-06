
Hi Josh I briefly summarized some details about my work.

-This framework is build to support both API and UI testing in BDD format
-First two snerario are to test APIs
-Last scenario to report a defect in API testing, report is at the project level bugreport.xls, there is a screenshot from manual Postman screen in xls file
-There is no UI tests
-All my resuble methods are in AppPages.BasePage. There are some methods not used but can be used for future implementations
-AppPages.Driver for UI test to create a singleton approach web driver
-AppPages.AllPage where I have private page objects with public getters to implement Page Object Model
-I created a physical class for each physical page of application so that I keep only one copy of each locator here and reuse wherever required
 this is for easy maintanence	
-Html report of the last run will be created in ..\ContractSecurityBddApiTests\bin\Debug\netcoreapp3.1 and can be exported to Team City / Jenkins tabs
 I will provide a copy in project level as well as index.html and a jpeg copy
-I prefer mapping response directly to a physical class - all response objects and post payload objects are in AppPages.ApiObjects
-BDD scenarios are in Features.VulneribilityTagsFeature file
-C# scripts linked to each step of scenario areStepDefinitions.VulneribilityTagsTestsSteps.cs
-To reproduce the bug, developer can use the steps in the excel report and the html report shows each passing and failing step. We attach here a screen shut of the error inctance in UI test.

Looking forward to joining team !
thank you

Ibrahim


