Feature: ProfileLanguage
As a seller I want to manage my profile Language Field

@AutomateAddLanguage
Scenario: A seller Add profile language with valid inputs  
Given I click on language button
When  I add language
Then I should able to validate new record Successfully 

@AutomateEditLanguage
Scenario: A seller update profile language details 
Given I click on language button
When I edit my language
Then I should be able to validate updated record successfully

@AutomateRemoveLanguage
Scenario: A seller delete existing language
Given I click on language button
When I delete language
Then I should not be able to able to see deleted language


