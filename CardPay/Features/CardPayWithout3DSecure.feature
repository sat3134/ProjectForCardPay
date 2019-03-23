Feature: CardPayWithout3DSecure
	We are checking here that the payment is CONFIRMED, DECLINED or PENDING
	by using PANs of cards without 3-D Secure transaction.

Scenario: Payment has the CONFIRMED status
	Given Open Payment Page 
	And Enter a card number 4000000000000077
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	When User clicks Pay button
	Then User sees that the payment status is Success 

Scenario: Payment has the DECLINED status
	Given Open Payment Page
	And Enter a card number 5555555555554477
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	When User clicks Pay button
	Then User sees that the payment status is Decline 

Scenario: Payment has the PENDING status
	Given Open Payment Page
	And Enter a card number 4000000000000051
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	When User clicks Pay button
	Then User sees that the payment status is Info 