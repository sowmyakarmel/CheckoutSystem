Feature: Restaurant Bill Calculation

  Scenario: Calculate bill for group of 4 people
    Given a new restaurant bill calculator
    When 4 people order 4 starters, 4 mains, and 4 drinks
    And the bill is calculated
    Then the bill total should be 58.4


  Scenario: Calculate bill for group of 2 people before 19.00, then update with 2 more people after 20.00
    Given a new restaurant bill calculator
    When 2 people order 1 starter, 2 mains, and 2 drinks before 19.00
    And the bill is calculated
    Then the bill total should be 23.3

    When 2 more people join at 20.00 and order 2 mains and 2 drinks
    And the bill is updated and calculated
    Then the updated bill total should be 43.7

  #Scenario: Calculate bill for group of 4 people, then update by removing one person's order and changing the remaining orders
  #  Given a new restaurant bill calculator
  #  When 4 people order 4 starters, 4 mains, and 4 drinks
  #  And the bill is calculated
  #  And the original bill total is stored
  #  When 1 person's order is removed and the remaining orders are changed to 3 starters, 3 mains, and 3 drinks
  #  And the bill is updated and calculated
  #  Then the updated bill total should be 43.5
  #  And the updated bill total should not be the same as the original bill total