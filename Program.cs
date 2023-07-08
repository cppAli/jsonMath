//отдельный.cs
using System;
using System.Text.Json;

public class BasicOperation
{
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public string OperationType { get; set; }
    public double Result { get; set; }

    public BasicOperation(double num1, double num2, string operationType, double result)
    {
        Num1 = num1;
        Num2 = num2;
        OperationType = operationType;
        Result = result;
    }

    public static void ShowHistory(List<BasicOperation> operations)
    {
        if (operations.Count == 0)
        {
            Console.WriteLine("Operation history is empty.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Operations history:");
        foreach (BasicOperation operation in operations)
        {
            Console.WriteLine($"{operation.Num1} {operation.OperationType} {operation.Num2} = {operation.Result}");
        }
        Console.WriteLine();
    }

    public static void SaveHistoryToJson(List<BasicOperation> operations, string filePath)
    {
        string json = JsonSerializer.Serialize(operations);
        File.WriteAllText(filePath, json);
    }

    public static List<BasicOperation> LoadHistoryFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<BasicOperation>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<BasicOperation>>(json);
    }

    public static void ClearHistory(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        Console.WriteLine("Operation history has been cleared.");
        Console.WriteLine();
    }
}



