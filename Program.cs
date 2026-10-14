/* Name: Kingston Felder
Course: CSCI 1250, Section 002 
Assigment: Lab 02, Trip Caculator 
Date: September 22,2026
 Description: Calculates the fuel,food,and work hours behind one road trip
 */


// Part 1 Caculating the fuel cost 




Console.Write("What was the round trip in miles?");
int roundTripMiles = Convert.ToInt32(Console.ReadLine());

Console.Write("What was the miles per gallon of the car you are using?");
int milesPerGallon = Convert.ToInt32(Console.ReadLine() );

Console.Write("What is the cost per gallon?");
double gasPrice = Convert.ToDouble(Console.ReadLine());

//do the math

double fuelCost = FuelCost(roundTripMiles, milesPerGallon, gasPrice);




//do the output.
System.Console.WriteLine("Gallons needed: " + (roundTripMiles / (double)milesPerGallon).ToString("F2"));
System.Console.WriteLine("Fuel Cost: " + fuelCost.ToString("C"));
// Part 2 caculating the pizza needed 
Console.Write("How Many people are going to pizza party?");
int people = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many pizzas?");
int pizzas = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the cost per pizza?");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());
const int slicesPerPizza=8;
int totalSlices = pizzas * slicesPerPizza;
double slicesPerPerson = (double)totalSlices/people;
double pizzaCost = pizzas * pizzaPrice;

System.Console.WriteLine("Total Slices:" + totalSlices);
System.Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F1"));
System.Console.WriteLine("Pizza cost: "+ pizzaCost.ToString("C"));
//Caculating gross pay,taxes,and take home pay
Console.Write("How many hours did you work this week?");
int hours = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your hourly rate?");
double rate = Convert.ToDouble(Console.ReadLine());

const double taxRate = 0.18;
double grossPay = hours * rate;
double taxWithheld = grossPay * taxRate;
double takeHomePay = TakeHomePay(hours, rate, taxRate);

Console.WriteLine("Gross pay: " + grossPay.ToString("C"));
Console.WriteLine("Tax withheld: " + taxWithheld.ToString("C"));
Console.WriteLine("Take home pay: " + takeHomePay.ToString("C"));
//caculate total trip cost and work hours needed 
double tripTotal = fuelCost + pizzaCost;
double costPerPerson = tripTotal / people;
double takeHomePayPerHour = takeHomePay / hours;
double hoursYouMustWork = HoursToCover(tripTotal, takeHomePayPerHour);

System.Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
System.Console.WriteLine("Cost Per person: " + costPerPerson.ToString("C"));
System.Console.WriteLine("Take home pay per hour: " + takeHomePayPerHour.ToString("C"));
System.Console.WriteLine("Hours you must work to cover your share: " + hoursYouMustWork.ToString("F2"));
// Returns the total fuel cost for the trip.
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
// Returns the take-home pay after taxes are withheld.
static double TakeHomePay(double hours, double hourlyRate, double TaxRate)
{
    double grossPay = hours * hourlyRate;
    double taxes = grossPay * taxRate;
    return grossPay - taxes;
}    
// Returns the number of hours needed to cover the trip cost.
static double HoursToCover(double tripTotal, double takeHomePayPerHour)
{
    return tripTotal / takeHomePayPerHour;
}

// Part 2 - Employee information

String[] names = { "ada" , "Grace", "Alan","Katherine" };
double[] hoursWorked = { 22, 15, 20, 18 };
double[] hourlyRates = { 13.50, 13.50, 11.20,14.80 };
Console.WriteLine("Group members:");
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}

double totalHours = 0;
double totalTakeHome = 0;
double longestHoursToCover = 0;
for (int i = 0; i < names.Length; i++)
{ 
    double takeHome = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHome / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePayPerHour);

    totalHours += hoursWorked[i];
    totalTakeHome += takeHome;
    longestHoursToCover = Math.Max(longestHoursToCover, hoursNeeded);

    Console.WriteLine(names[i] + ":");
    Console.WriteLine(" Take-home pay: $" + takeHome.ToString("F2"));
    Console.WriteLine(" Take-home pay/hour: $" + takeHomePerHour.ToString("F2"));
    Console.WriteLine(" Hours to cover share: " + hoursNeeded.ToString("F2"));
}

Console.WriteLine();
Console.WriteLine("Group totals:");
Console.WriteLine("Total hours: " + totalHours.ToString("F2"));
Console.WriteLine("Total take-home pay: $" + totalTakeHome.ToString("F2"));
Console.WriteLine("Longest hours to cover share: " + longestHoursToCover.ToString("F2"));
