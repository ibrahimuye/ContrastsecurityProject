@regression
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
	
	

