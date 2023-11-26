/*
 * CSE212 
 * (c) BYU-Idaho
 * 02-Prove - Problem 2
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
 * to post it online.  Storage into a personal and private repository (e.g. private
 * GitHub repository, unshared Google Drive folder) is acceptable.
 *
 */
public static class Priority
{
    public static void Test()
    {
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test 1
        // Scenario: Enqueue two items with different priorities.
        // Expected Result: Queue should contain items in the order they were enqueued.
        priorityQueue.Enqueue(10, 3);
        priorityQueue.Enqueue(20, 5);
        Console.WriteLine("Test 1: " + priorityQueue);

        // Test 2
        // Scenario: Dequeue an item from the non-empty queue.
        // Expected Result: The item with the highest priority (20) should be dequeued.
        int dequeuedItem = priorityQueue.Dequeue();
        Console.WriteLine($"Test 2: Dequeued item with priority {dequeuedItem}. Remaining queue: {priorityQueue}");

        // Test 3
        // Scenario: Attempt to dequeue from an empty queue.
        // Expected Result: Error message should be displayed.
        priorityQueue.Dequeue(); // This will trigger the error message.

        // Add more Test Cases As Needed Below
    }
}


public class PriorityQueue
{
    private class QueueItem
    {
        public int Data { get; set; }
        public int Priority { get; set; }
    }

    private readonly Queue<QueueItem> _queue = new Queue<QueueItem>();

    public void Enqueue(int data, int priority)
    {
        var item = new QueueItem { Data = data, Priority = priority };
        _queue.Enqueue(item);
    }

    public int Dequeue()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return -1; // Return a sentinel value or throw an exception
        }

        int maxPriority = int.MinValue;
        int maxPriorityIndex = -1;

        for (int i = 0; i < _queue.Count; i++)
        {
            var item = _queue.ElementAt(i);
            if (item.Priority > maxPriority)
            {
                maxPriority = item.Priority;
                maxPriorityIndex = i;
            }
        }

        var removedItem = _queue.ElementAt(maxPriorityIndex);
        _queue.RemoveAt(maxPriorityIndex);
        return removedItem.Data;
    }

    public override string ToString()
    {
        return string.Join(", ", _queue.Select(item => $"{item.Data}({item.Priority})"));
    }
}
