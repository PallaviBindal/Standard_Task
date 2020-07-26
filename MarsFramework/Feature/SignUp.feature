Feature: SignUp
	Check if User is able to register
@Signup
Scenario: Register User as Valid Credentials 
	Given I navigate to the URL
	And I enter First name, Last name, password, Confirm Password, email address and click on join button
	Then I should be able to register successfully
