using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

List<BasicOperation> operations = new List<BasicOperation>();
string json = "history.json";

bool exit = false;
    while (!exit)
    {
        Console.WriteLine("Select calculation operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Show transaction history");
        Console.WriteLine("6. Clear transaction history");
        Console.WriteLine("7. Exit");

    string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddOperation("+");
                break;
            case "2":
                AddOperation("-");
                break;
            case "3":
                AddOperation("*");
                break;
            case "4":
                AddOperation("/");
                break;
            case "5":
                ShowHistory();
                break;
            case "6":
                ClearHistory();
                break;
            case "7":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid operation selection.");
                break;
        }
    }
void AddOperation(string operationType)
{
    Console.Write("Enter the first number: ");
    double num1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter the second number: ");
    double num2 = Convert.ToDouble(Console.ReadLine());

    double result = 0;
    switch (operationType)
    {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            if (num2 != 0)
                result = num1 / num2;
            else
                Console.WriteLine("Division by zero is not possible.");
            break;
        default:
            Console.WriteLine("Invalid operation type.");
            break;
    }

    BasicOperation mathOperation = new BasicOperation(num1, num2, operationType, result);
    operations.Add(mathOperation);

    Console.WriteLine($"Result: {result}");
    Console.WriteLine();

    SaveHistoryToJson();
}

void ShowHistory()
{
    List<BasicOperation> history = BasicOperation.LoadHistoryFromJson(json);
    BasicOperation.ShowHistory(history);
}

void SaveHistoryToJson()
{
    BasicOperation.SaveHistoryToJson(operations, json);
    Console.WriteLine("Transaction history has been saved to the JSON file.");
}
void ClearHistory()
{
    BasicOperation.ClearHistory(json);
}