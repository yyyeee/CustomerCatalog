Feature: Customer list
	In order to contact customers
	As a user
	I want to be able to see customers on list

@customerList
Scenario: See list of customers
	Given The following customers exist
| Name           | Status     | CreationTime |
| Customer1      | Prospective | 27.03.2018 11:00       |
| Customer2		 | Current    | 21.02.2018 12:00    |
| Customer3		 | NonActive     | 17.03.2018 11:22   |
	Given a webpage
	When I open the list of customers
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| Customer1      | Prospective | 27.03.2018 11:00       |
| Customer2		 | Current    | 21.02.2018 12:00    |
| Customer3		 | Non-active     | 17.03.2018 11:22   |

	
@customerList
Scenario: Filter list of customers by name
	
@customerList
Scenario: Sort by name list of customers
	
@customerList
Scenario: Sort filtered list of customers
