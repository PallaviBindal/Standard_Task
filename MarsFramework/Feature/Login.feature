Feature: Login
Check if login funtionality work

@LoginTag
Scenario: Login user as valid credentials 
Given I navigate to url 
When  I enter username and password and click button
Then  I should be able to see home page 