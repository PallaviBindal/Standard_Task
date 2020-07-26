Feature: Add a profile
	As a seller on this portal
	I want to manage my profile effectively


@AddAvailability
Scenario:1 Add availability
	Given I click on Availabilty button
	When I add availability 
	Then I should be able to read pop up 


@ChangePassword
Scenario:2 Change password
	Given Click on Change Password button
    When I  provide all  the details
	Then  I should be ableto see change password 

	@SearchSkill
	Scenario:3 Search Skills
	Given Enter skill 
	When I filter the search result
	Then I should be able to see skills 


	@AddDescription
	Scenario:4 Add Description upto 600 characters
	Given I click on description
	When I have entered description using 600 characters and click on save button
	Then I should be able to see the pop up message again

	@AddEarnTarget
Scenario:5 Add earn target 
	Given I click on earn target button
	When I add earn target 
	Then I should be able to read pop up 

	@AddHours 
Scenario:6 Add hours 
	Given I click on hours  button
	When I add hours 
	Then I should be able to read pop up







