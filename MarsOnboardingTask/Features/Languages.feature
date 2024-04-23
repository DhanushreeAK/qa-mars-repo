Feature: This test suite runs language related test scenarios

 

Scenario: 1. Verify user is able to add languages with language level
Given User logs into Mars application
When User adds 'French' language with 'Basic' language level into the languages list
Then The 'French' language with 'Basic' language level should be added to languages list

Scenario: 2. Verify User is able to update an existing language with a new language level
Given User logs into Mars application
When User updates the 'French' language with 'Fluent' language level from the languages list
Then The language level for 'French' language should be updated to 'Fluent'

Scenario: 3. Verify user is able to delete an existing known language
When The User deletes the language 'French'
Then The language 'French' should not be visible on the profile page

Scenario: 5. Verify user attempting to add a language already present in the known languages list
When User adds 'Hindi' language with 'Basic' language level into the languages list
And User adds language 'Hindi' with 'Basic' language level that is already displayed in languages list
Then The language 'Hindi' should not be added again in the languages list

Scenario: 6. Verify if user is able to add the language in the Languages section under Profile page with invalid data 
When User adds '' language with 'Fluent' language level into the languages list
Then 'Language' should not be added and error message should be displayed