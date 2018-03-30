Feature: Customer details
	In order to have customer updated
	As a user
	I want to be able to edit customer

@customerDetails
Scenario: Edit customer details
	Given The following customers exist
| Name      | Status | CreationTime     | Id                                   |
| Customer1 | 1      | 2018-03-27 11:00 | b14bf7f2-c66d-4927-a322-42eb4f5b40e1 |
	When I open customer 'b14bf7f2-c66d-4927-a322-42eb4f5b40e1' view 
	When I change name to 'New name'
	When I change status to 'Current'
	When I click save
	When I open customers list
	Then the following customers appear in the list
| Name           | Status     | CreationTime |
| New name      | Current | Mar 27th 18       |
	
@customerDetails
Scenario: See customer details

@customerDetails
Scenario: See notes for customer

@customerDetails
Scenario: Add note for customer

@customerDetails
Scenario: Edit note for customer