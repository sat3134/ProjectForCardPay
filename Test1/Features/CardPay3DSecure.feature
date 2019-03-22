Feature: CardPay3DSecure
	We are checking here that the payment is CONFIRMED, DECLINED or PENDING
	by using PANs of cards with 3-D Secure transaction.

Scenario: Payment has the CONFIRMED status
	Given Open Payment Page 
	And Enter a card number 4000000000000002
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	And User clicks Pay button
	When User clicks Emulate 3-D Secure
	Then User sees that the payment status is Success

Scenario: Payment has the DECLINED status
	Given Open Payment Page
	And Enter a card number 5555555555554444
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	And User clicks Pay button
	When User clicks Emulate 3-D Secure
	Then User sees that the payment status is Decline

Scenario: Payment has the PENDING status
	Given Open Payment Page
	And Enter a card number 4000000000000044
	And Enter a CardHolder name
	And Select the expired month
	And Select the expired year
	And Enter three digits of CVV
	And User clicks Pay button
	When User clicks Emulate 3-D Secure
	Then User sees that the payment status is Info 