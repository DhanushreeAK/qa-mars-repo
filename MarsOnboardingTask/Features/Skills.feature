Feature: This test suite runs Skills related test scenarios


Scenario Outline: 1. Verify user is able to add Skill with experience level
Given User logs into Mars application
When User clicks on the Skills tab
And User adds '<Skill>' skill with '<Experience Level>' experience level into the Skills list
Then The '<Skill>' skill with '<Experience Level>' experience level should be added to Skills list

Examples: 
| Skill | Experience Level |
|  C#  |   Beginner        |
|  Java  |   Beginner        |


Scenario Outline: 2. Verify user is able to update an existing Skill with new experience level
Given User logs into Mars application
When User clicks on the Skills tab
And User edits the '<Skill>' skill with '<Experience Level>' experience level 
Then The experience level for '<Skill>' skill should be updated to '<Experience Level>'

Examples: 
| Skill | Experience Level |
|  C#  |  Intermediate     |


Scenario Outline: 3. Verify user is able to delete an existing Skill
Given User logs into Mars application
When User clicks on the Skills tab
And User deletes the skill '<Skill>'
Then The skill '<Skill>' should be deleted successfully

Examples: 
| Skill |
|  C#   |

Scenario Outline: 4. Verify if user is able to add the already existing skill in the Skills section under Profile page 
Given User logs into Mars application
When User clicks on the Skills tab
And User adds '<Skill>' skill with '<Experience Level>' experience level into the Skills list
And User adds skill '<Skill>' with '<Experience Level>' experience level that is already present in their skills list
Then The skill '<Skill>' should not be added again in the skills list

Examples: 
| Skill          | Experience Level |
| Manual Testing | Expert           |
| Manual Testing | Expert           |



Scenario Outline: 5. Verify if user is able to add a skill in the Skills section under Profile page with invalid data
Given User logs into Mars application
When User clicks on the Skills tab
And User adds '<Skill>' skill with '<Experience Level>' experience level into the Skills list
Then Invalid '<Skill>' should not be added and error message should be displayed

Examples: 
| Skill | Experience Level |
|       | Beginner         |
|       |                  |
| ABC   |                  |
|  !!@!@#     |   Basic               |