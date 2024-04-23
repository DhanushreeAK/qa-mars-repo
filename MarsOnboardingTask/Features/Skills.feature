Feature: This test suite runs Skills test scenarios


Scenario: 1. Verify user is able to add known skills with experience level
Given User logs into Mars application
When User clicks on the Skills tab
And User adds 'C#' skill with 'Beginner' experience level into the Skills list
Then The 'C#' skill with 'Beginner' experience level should be added to Skills list

Scenario: 2. Verify user is able to update an existing Skill with new experience level
Given User logs into Mars application
When User clicks on the Skills tab
And User edits the 'C#' skill with 'Intermediate' experience level 
Then The experience level for 'C#' skill should be updated to 'Intermediate'

Scenario: 3. Verify user is able to delete an existing Skill
Given User logs into Mars application
When User clicks on the Skills tab
And User deletes the skill 'C#'
Then The skill 'C#' should be deleted successfully

Scenario: 4. Verify if user is able to add the already existing skill in the Skills section under Profile page 
Given User logs into Mars application
When User clicks on the Skills tab
And User adds 'Manual Testing' skill with 'Expert' experience level into the Skills list
And User adds skill 'Manual Tesing' with 'Expert' experience level that is already present in their skills list
Then The skill 'Manual Testing' should not be added again in the skills list

Scenario: 5. Verify if user is able to add a skill in the Skills section under Profile page with invalid data
Given User logs into Mars application
When User clicks on the Skills tab
And User adds '' skill with 'Beginner' experience level into the Skills list
Then Invalid 'skill' should not be added and error message should be displayed