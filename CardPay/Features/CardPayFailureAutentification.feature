Feature: CardPayFailureAutentification
	We are checking here that the payment is CONFIRMED, DECLINED or PENDING
	by using PANs of cards with 3-D Secure transaction.


Scenario: Payment has been Declined by issuing bank
	Given Open Payment Page
	And Enter a card number 4000000000000002
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	And User clicks Pay button
	When User clicks Emulate Failed 3-D Secure
	Then User sees that the payment is declined by issuing bank
