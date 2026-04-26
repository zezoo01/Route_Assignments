namespace ShopMaster.Exercises;

public class Exercise5_PrintQueue
{
    public static void Run()
    {
        Console.WriteLine("\nExercise 5: Print Queue Simulator \n");

        // Create Queue and enqueue 5 documents
        Queue<string> printQueue = new Queue<string>();
        printQueue.Enqueue("Report.pdf");
        printQueue.Enqueue("Invoice.pdf");
        printQueue.Enqueue("Letter.docx");
        printQueue.Enqueue("Resume.pdf");
        printQueue.Enqueue("Photo.jpg");

        // 1. Print queue contents and Count
        Console.WriteLine($"Queue  : {string.Join(", ", printQueue)}");
        Console.WriteLine($"Count  : {printQueue.Count}");

        // 2. Peek — see next without removing
        Console.WriteLine($"\nNext to print (Peek) : {printQueue.Peek()}");

        // 3. Dequeue each document and print
        Console.WriteLine("\nProcessing queue:");
        while (printQueue.Count > 0)
            Console.WriteLine($"  Printing: {printQueue.Dequeue()}");

        // 4. TryDequeue on empty queue
        bool success = printQueue.TryDequeue(out string? doc);
        Console.WriteLine($"\nTryDequeue on empty queue : success={success}, value={doc ?? "null"}");
    }
}
