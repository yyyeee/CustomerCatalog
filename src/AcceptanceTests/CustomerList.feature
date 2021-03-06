﻿Feature: Customer list
	In order to contact customers
	As a user
	I want to be able to manage customers on list

@customerList
Scenario: See list of customers
	Given The following customers exist
| Name           | Status     | CreationTime |
| Customer1      | 1 | 2018-03-27 11:00       |
| Customer2		 | 2    | 2018-02-21 12:00    |
| Customer3		 | 3     | 2018-03-17 11:22   |
	When I open the list of customers
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| Customer1      | Prospective | Mar 27th 18       |
| Customer3		 | Non-active     | Mar 17th 18   |
| Customer2		 | Current    | Feb 21st 18    |

	
@customerList
Scenario: Filter list of customers by name
	Given The following customers exist
| Name           | Status     | CreationTime |
| Customer1      | 1 | 2018-03-27 11:00       |
| Customer2		 | 2    | 2018-02-21 12:00    |
| Customer3		 | 3     | 2018-03-17 11:22   |
	When I open the list of customers
	When I filter the list by name with value 'Customer1'
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| Customer1      | Prospective | Mar 27th 18       |
	
@customerList
Scenario: Sort by name list of customers
	Given The following customers exist
| Name           | Status     | CreationTime |
| Customer1      | 1 | 2018-03-27 11:00       |
| Customer2		 | 2    | 2018-02-21 12:00    |
| Customer3		 | 3     | 2018-03-17 11:22   |
	When I open the list of customers
	When I sort by name
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| Customer1      | Prospective | Mar 27th 18       |
| Customer2		 | Current    | Feb 21st 18    |
| Customer3		 | Non-active     | Mar 17th 18   |
	
@customerList
Scenario: Sort filtered list of customers
	Given The following customers exist
| Name           | Status     | CreationTime |
| Customer2		 | 2    | 2018-02-21 12:00    |
| Customer1      | 1 | 2018-03-27 11:00       |
| Test		 | 3     | 2018-03-17 11:22   |
	When I open the list of customers
	When I sort by name
	When I filter the list by name with value 'Customer'
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| Customer1      | Prospective | Mar 27th 18       |
| Customer2		 | Current    | Feb 21st 18    |

@customerList
Scenario: Add customer to list