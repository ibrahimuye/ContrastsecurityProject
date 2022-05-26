# ContrastsecurityProject

-This framework is build to support both API and UI testing in BDD format
-First two snerario are to test APIs
-Last scenario to report a defect in API testing, report is at the project level bugreport.xls, there is a screenshot from manual Postman screen in xls file
-There is no UI tests
-All my resuble methods are in AppPages.BasePage. There are some methods not used but can be used for future implementations
-AppPages.Driver for UI test to create a singleton approach web driver
-AppPages.AllPage where I have private page objects with public getters to implement Page Object Model
-I created a physical class for each physical page of application so that I keep only one copy of each locator here and reuse wherever required
 this is for easy maintanence	
-html report of the last run is in ..\ContractSecurityBddApiTests\bin\Debug\netcoreapp3.1 and can be exported to TeamCity tabs
 I will provide a copy in project level as well as index.html
-I prefer mapping response directly to a physical class - all response objects and post payload objects are in AppPages.ApiObjects
-BDD scenarios are in Features.VulneribilityTagsFeature file
-C# scripts linked to each step of scenario areStepDefinitions.VulneribilityTagsTestsSteps.cs


thank you

Ibrahim



Adding the scenarios in the feature file here as well.

Feature: Vulnerability Tests
	As a developer planning my upcoming work, I want to arbitrarily label vulnerabilities to indicate their relevance to other work. 
	These labels may indicate the class where the code needs to be changed or which sprint the vulnerability will be fixed within. 
	I would like the ability to enter any short string as a note so that I, 
	or others on my team, can filter the vulnerabilities list within Contrast.
		

@1
Scenario: As a developer I should be able to add a tag to a vulnerability

	Given I randomly choose a vulnerability
	When I add the name of enginner assigned as a tag
	And I wait for a while
	And I record the number of tags on this vulnerability
	And I add the assigned date as a tag
	And I wait for a while
	Then I verify the number tags increased by one on this vulnerability

@2
Scenario: Total number of unique tags should not increase after I add the same tag to two different vulnerability

	Given I randomly choose a vulnerability
	When I add the assigned date as a tag
	And I wait for a while
	And I record the number of unique tags
	And I choose another vulnerability
	And I add the same tag to the second vulnaribility
	And I wait for a while
	Then I verify the number unique tags remain same
	

@3
Scenario: I can remove a tag from a vulnerability.

	Given I randomly choose a vulnerability
	When I add the name of enginner assigned as a tag
	And I wait for a while
	And I get the list of tags on the vulnerability
	And I delete the tag on zeroth index
	And I wait for a while
	And I get the list of tags on the vulnerability
	Then I verify the tag is not linked anymore


