Feature: ManageListing
	  As a Skill Trader
      I want to edit, delete, view Services in Managelisting page 
    



@AutomateUpdateManageListing
Scenario:update Service in ManageListing
	Given I Click on Manage Listings tab on profile page 
	When I click on update icon and add new service 
	Then I should be able to see updated service 

@automateDeleteManageListingTag
Scenario:Delete Service in ManageListing
	Given I Click on Manage Listings tab on profile page 
	When I click on delete icon 
	Then I should be able to see confirmation message