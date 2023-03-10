using NUnit.Framework;

namespace CheckoutSystem.Specs.StepDefinitions
{
    [Binding]
    public sealed class CheckoutProcessStepDefinitions
    {

        private RestaurantBillCalculator calculator;
        private decimal originalBillTotal;

        [Given(@"a new restaurant bill calculator")]
        public void GivenANewRestaurantBillCalculator()
        {
            calculator = new RestaurantBillCalculator();
        }

        [When(@"(.*) people order each (.*) starters, (.*) mains, and (.*) drinks")]
        public void WhenPeopleOrderEachStartersMainsAndDrinks(int numPeople, int numStarters, int numMains, int numDrinks)
        {
             calculator.AddOrder(numPeople,numStarters, numMains, numDrinks);
        }

        [When(@"(.*) people order (.*) starter, (.*) mains, and (.*) drinks before (.*)")]
        public void WhenPeopleOrderStarterMainsAndDrinksBefore(int numPeople, int numStarters, int numMains, int numDrinks, Decimal time)
        {
            calculator.AddOrder(numPeople, numStarters, numMains, numDrinks, time);
        }

        [When(@"the bill is calculated")]
        public void WhenTheBillIsCalculated()
        {
            calculator.CalculateBill();
        }

        [Then(@"the bill total should be ([\d\.]+)")]
        public void ThenTheBillTotalShouldBe(decimal expectedTotal)
        {
            Assert.AreEqual(expectedTotal, calculator.GetBillTotal());
        }

        [Given(@"the original bill total is stored")]
        public void GivenTheOriginalBillTotalIsStored()
        {
            originalBillTotal = calculator.GetBillTotal();
        }

        [When(@"(.*) more people join at (.*) and order (.*) mains and (.*) drinks")]
        public void WhenMorePeopleJoinAtAndOrderMainsAndDrinks(int numPeople, Decimal time, int numMains, int numDrinks)
        {
            calculator.AddOrder(numPeople, 0, numMains, numDrinks, time);
        }

        [When(@"(.*) people order (.*) starters, (.*) mains, and (.*) drinks")]
        public void WhenPeopleOrderStartersMainsAndDrinks(int numPeople, int numStarters, int numMains, int numDrinks)
        {
            calculator.AddOrder(numPeople, numStarters, numMains, numDrinks);
        }

        [When(@"the bill is updated and calculated")]
        public void WhenTheBillIsUpdatedAndCalculated()
        {
            originalBillTotal = calculator.CalculateBill(1);
        }
        [When(@"the bill is updated and calculated after removal")]
        public void WhenTheBillIsUpdatedAndCalculatedAfterRemoval()
        {
            originalBillTotal = calculator.CalculateBill();
        }


        [Then(@"the updated bill total should be (.*)")]
        public void ThenTheUpdatedBillTotalShouldBe(Decimal expectedTotal)
        {
            Assert.AreEqual(expectedTotal, calculator.GetBillTotal());
        }

        [When(@"(.*) person's order is removed and the remaining orders are changed to (.*) starters, (.*) mains, and (.*) drinks")]
        public void WhenPersonsOrderIsRemovedAndTheRemainingOrdersAreChangedToStartersMainsAndDrinks(int numPeople, int numStarters, int numMains, int numDrinks)
        {
            calculator.UpdateOrder(0, numPeople, numStarters, numMains, numDrinks);
        }

    }
}