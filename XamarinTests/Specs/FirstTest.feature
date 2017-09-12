Feature: TD app

Scenario: Make a measurement and send it successfully
	Given I tap "Sign Up" button
	Then I should be on "enter PIN code" page
	Given I tap "Activate" button
	And I tap "hamburger menu" button
	Then I should see "panel menu"
	Given I tap "Thrombosys module" button
	Then I should be on "Measure INR" page
	Given I tap "Measure INR" button
	And I tap "Register INR value" button
	And I tap "manually enter" button
	Given I input "611669857" as Patient BSN
	And I input "2" as Employee Id
	And I input "4" as INR value
	Given I tap "Register extra info" button
	Given I select "Medication" as "No"
	And I select "Been Bleeding" as "No"
	And I select "Medical Intervention" as "No"
	Given I tap "Ready" button
	Given I tap "Confirm and Send" button
	Then I verify if the "BSN" is "611669857"
	And I verify if the "Employee Id" is "2" 
	And I verify if the "INR value" is "4" 
	Given I tap "Submit" button
	And I tap "hamburger menu" button
	Then I should see "panel menu"
	Given I tap "Overview sent messages" button
	Then I verify if the "BSN" is "611669857" on Overview Sent Messages

