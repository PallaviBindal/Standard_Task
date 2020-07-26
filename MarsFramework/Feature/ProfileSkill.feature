Feature: ProfileSkill
As a seller I want to manage my profile Language Field

@AutomateAddSkill 
Scenario: A seller Add profile skill with valid inputs  
Given I click on skill button
When  I add skill
Then I should able to validate new  skill record Successfully 

@AutomateEditSkill
Scenario: A seller update profile skill details 
Given I click on skill button
When I edit my skill
Then I should be able to validate updated skill record successfully


@AutomateRemoveSkill
Scenario: A seller delete existing skill
Given I click on skill button
When I delete skill
Then I should not be able to able to see deleted skill


