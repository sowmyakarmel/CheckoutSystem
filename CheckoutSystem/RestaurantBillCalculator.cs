

public class RestaurantBillCalculator
{
    private const decimal STARTER_COST = 4.00m;
    private const decimal MAIN_COST = 7.00m;
    private const decimal DRINK_COST = 2.50m;
    private const decimal DISCOUNT_RATE = 0.30m;
    private const decimal SERVICE_CHARGE = 0.10m;


    private List<(int, int, int, int, Decimal)> orders = new List<(int, int, int, int, Decimal)>();
    private decimal billTotal = 0.0m;

    public void AddOrder(int numPeople, int numStarters, int numMains, int numDrinks, Decimal time = 20)
    {
        orders.Add((numPeople, numStarters, numMains, numDrinks, time));
    }

    public void UpdateOrder(int index, int numPeople, int numStarters, int numMains, int numDrinks, Decimal time = 20)
    {
        orders[index] = (numPeople, numStarters, numMains, numDrinks, time);
    }

    public void RemoveOrder(int index)
    {
        orders.RemoveAt(index);
    }

    public decimal CalculateBill()
    {
        decimal total = 0.0m;
        decimal foodTotal = 0.0m;


        // Calculate total for each order
        foreach (var order in orders)
        {
            decimal orderTotal = (order.Item1 * STARTER_COST) + (order.Item2 * MAIN_COST) + (order.Item3 * DRINK_COST);

            if (order.Item4 <= 19.00)
            {
                // Apply discount for drinks before 19:00
                decimal discount = order.Item3 * DRINK_COST * DISCOUNT_RATE;
                orderTotal -= discount;
            }
            foodTotal += (order.Item1 * STARTER_COST) + (order.Item2 * MAIN_COST);

            total += orderTotal;
        }
        total += foodTotal * SERVICE_CHARGE;
        billTotal = total;
        return total;
    }

    public decimal GetBillTotal()
    {
        return billTotal;
    }
}
