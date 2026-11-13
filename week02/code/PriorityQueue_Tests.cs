using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a low-priority item, then a higher-priority item.
    // Expected Result: Enqueue preserves insertion order, and Dequeue returns the higher-priority item.
    // Defect(s) Found: The search skipped the last item and returned "low" instead of "high". Fixed by checking every item and removing the selected item; this test now passes.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);

        Assert.AreEqual("[low (Pri:1), high (Pri:10)]", priorityQueue.ToString());
        Assert.AreEqual("high", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with equal highest priority followed by a lower-priority item.
    // Expected Result: The highest-priority items are returned first, in FIFO order, followed by the lower-priority item.
    // Defect(s) Found: Equal priorities selected the newer item first ("second high" instead of "first high"). Fixed by retaining the first item on ties and removing dequeued items; this test now passes.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first high", 5);
        priorityQueue.Enqueue("second high", 5);
        priorityQueue.Enqueue("low", 2);

        Assert.AreEqual("first high", priorityQueue.Dequeue());
        Assert.AreEqual("second high", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue the only item in the queue.
    // Expected Result: The item is returned and removed from the queue.
    // Defect(s) Found: Dequeue returned the item but left it in the queue. Fixed by removing the selected item; this test now passes.
    public void TestPriorityQueue_DequeueRemovesItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("only", 3);

        Assert.AreEqual("only", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None. The queue throws InvalidOperationException with the required message.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
