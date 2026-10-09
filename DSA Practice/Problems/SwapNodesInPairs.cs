namespace DSA_Practice.Problems;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next)
    {
        val = x;
        this.next = next;
    }
}

public class SwapNodesInPairs
{
    public ListNode swapPairs(ListNode head) {
        // Your code goes here
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode first = head;
        ListNode second = null;
        ListNode prev = dummy;
        while(first != null && first.next != null){
            second = first.next;

            prev.next = second;
            first.next = second.next;
            second.next = first;

            prev = first;
            first = first.next;
        }
        return dummy.next;
    }
}
