Feature: Profilecertification
As a seller I want to manage my profile Certification Field

@AutomateAddCertification
Scenario: A seller Add profile Certification with valid inputs  
Given I click on certification
When  I add certification
Then I should able to validate new certification record Successfully 

@AutomateEditCertification
Scenario: A seller update profile certification details 
Given I click on certification
When I edit my certification
Then I should be able to validate updated  certification record successfully


@AutomateRemoveCertification
Scenario: A seller delete existing certification
Given I click on certification
When I delete certification
Then I should not be able to able to see deleted certification


