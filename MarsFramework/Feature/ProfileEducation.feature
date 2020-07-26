Feature: ProfileEducation
As a seller I want to manage my profile Education Field

@AutomateAddEducation 
Scenario: A seller Add profile Education with valid inputs  
Given I click on education button
When  I add education
Then I should able to validate new education record Successfully 

@AutomateEditEducation
Scenario: A seller update profile education details 
Given I click on education button 
When I edit my education
Then I should be able to validate updated education record successfully


@AutomateRemoveEducation
Scenario: A seller delete existing education
Given I click on education button 
When I delete education
Then I should not be able to able to see deleted education
