Feature: Banking Operations

  Scenario Outline: A user can create an account with different initial balances 
    Given the user sends the request to create account with details '<InitialBalance>','<AccountName>', and '<Address>'
    Then I verify the status code '<statusCode>' 
    And verify the response data '<InitialBalance>','<NewBalance>','<AccountName>','<AccountNumber>' and '<Message>'

    Examples:
      |statusCode| InitialBalance | AccountName     | Address           | NewBalance | AccountNumber | Message                              |
      |  200     | 1000           | Rajesh Mittal   | Ahmedabad, Gujarat| 1000       | X123            | Account X123 created successfully   |
      |  200     | 2000           | John Doe         | New York, USA     | 2000       | Y456            | Account Y456 created successfully   |

Scenario Outline: A user can delete an account with different account IDs
    Given the user has an account with AccountID '<AccountID>'
    And verify the response data '<Data>' and '<Message>'
      
    Examples:
      | AccountID  | Data | Message |
      | X123       | null | Account deleted successfully |
      | Y456       | null | Account deleted successfully |

Scenario Outline: A user can deposit to an account with different account numbers and deposit amounts
    Given the user has an account with AccountNumber '<AccountNumber>
    And verify the response data '<AccountNumber>', '<NewBalance>' and <Message>
      
    Examples:
      | AccountNumber | Amount | NewBalance | Message                                       |
      | X123           | 1000   | 2000       | 1000$ deposited to Account X123 successfully |
      | Y456           | 500    | 1500       | 500$ deposited to Account Y456 successfully  |
Feature: User can withdraw from an account

  Scenario Outline: A user can withdraw from an account with different account numbers and withdrawal amounts
    Given the user has an account with details '<AccountNumber>' and '<Amount>'
    And on verifiication of the response data '<AccountNumber>', '<NewBalance>' and <Message>

    Examples:
      | AccountNumber | Amount | NewBalance | Message                                       |
      | X123           | 1000   | 0          | 1000$ withdrawn from Account X123 successfully |
      | Y456           | 500    | 500        | 500$ withdrawn from Account Y456 successfully  |
