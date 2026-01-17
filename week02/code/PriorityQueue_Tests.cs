using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    // // 1. Dequeue doesn't remove items from the queue
    // 2. Loop condition stops at Count-1, missing the last item
    // 3. Uses >= comparison which takes last same-priority item instead of first
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: First item with highest priority should be dequeued (FIFO for same priority)
    // Defect(s) Found: 
    // 1. Uses >= comparison, so it picks the LAST item with same priority instead of first
    // 2. No tracking of insertion order for FIFO behavior
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 3);
        
        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();
        
        Assert.AreEqual("D", result1);
        Assert.AreEqual("E", result2);
    }

    [TestMethod]
    // Scenario: All items have same priority
    // Expected Result: Items should be dequeued in FIFO order
    // Defect(s) Found: 
    // 1. No FIFO tracking - with >= comparison, last item would be taken
    public void TestPriorityQueue_MultipleSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with exact message "The queue is empty."
    // Defect(s) Found: None - this requirement is correctly implemented
    public void TestPriorityQueue_DequeueEmptyThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() => 
        {
            priorityQueue.Dequeue();
        });
        
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Complex scenario mixing priorities
    // Expected Result: Dequeue should respect both priority and FIFO order
    // Defect(s) Found: 
    // 1. Multiple dequeues fail because items aren't removed from queue
    // 2. FIFO not maintained for same priority items
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 1);
        
        // Should get B (priority 3, first of priority 3)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        // Should get D (priority 3, second of priority 3)
        Assert.AreEqual("D", priorityQueue.Dequeue());
        // Should get C (priority 2)
        Assert.AreEqual("C", priorityQueue.Dequeue());
        // Should get A (priority 1, first of priority 1)
        Assert.AreEqual("A", priorityQueue.Dequeue());
        // Should get E (priority 1, second of priority 1)
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Interleaved enqueue and dequeue operations
    // Expected Result: Queue should maintain correct state after multiple operations
    // Defect(s) Found: 
    // 1. Items not removed after dequeue, so subsequent operations fail
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        
        Assert.AreEqual("B", priorityQueue.Dequeue());
        
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 1);
        
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Last item has highest priority but loop misses it
    // Expected Result: Should find and dequeue last item if it has highest priority
    // Defect(s) Found: 
    // 1. Loop condition "index < _queue.Count - 1" skips the last item
    public void TestPriorityQueue_LoopMissesLastItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 5); // Highest priority, last item
        
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result); // Will fail with original code
    }

    [TestMethod]
    // Scenario: Multiple items, last has same high priority as earlier item
    // Expected Result: Should dequeue first item with high priority (FIFO)
    // Defect(s) Found: 
    // 1. >= comparison picks last item with same priority
    public void TestPriorityQueue_SamePriorityLastItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 3);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("LastHigh", 3); // Same priority as FirstHigh
        
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("FirstHigh", result); // Should be FirstHigh, not LastHigh
    }

    // Add more test cases as needed below.
}
