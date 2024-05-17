Feature: This test suite runs language related test scenarios

 

Scenario Outline: 1. Verify user is able to add languages with language level
Given User logs into Mars application
When User adds '<language>' language with '<language level>' language level into the languages list
Then The '<language>' language with '<language level>' language level should be added to languages list

Examples: 
| language | language level |
| English  | Fluent         |
| Hindi    | Basic          |

	

Scenario: 2. Verify User is able to update an existing language with a new language level
Given User logs into Mars application
When User adds '<language>' language with '<language level>' language level into the languages list
When User updates the '<language>' language with '< new language level>' language level from the languages list
Then The language level for '<language>' language should be updated to '<new language level>'

Examples: 
| language | language level | new language level |
| French   | Fluent         | Basic              |



Scenario: 3. Verify user is able to delete an existing known language
Given User logs into Mars application
When The User deletes the language '<language>'
Then The language '<language>' should not be visible on the profile page

Examples: 
| language |
| English  |
| Hindi    |

Scenario Outline: 5. Verify user attempting to add a language already present in the known languages list
Given User logs into Mars application
When User adds '<language>' language with '<language level>' language level into the languages list
And User adds language '<language>' with '<language level>' language level that is already displayed in languages list
Then The language '<language>' should not be added again in the languages list

Examples: 
| language | language level |
| Hindi    | Basic         |



Scenario Outline: 6. Verify if user is able to add the language in the Languages section under Profile page with invalid data
Given User logs into Mars application
When User adds '' language with '<language level>' language level into the languages list
Then '<language>' should not be added and error message should be displayed

Examples: 
| language | language level |
|          | Basic          |
| ABC      |                |
|          |                |
|    !@@@@      |   Basic             |