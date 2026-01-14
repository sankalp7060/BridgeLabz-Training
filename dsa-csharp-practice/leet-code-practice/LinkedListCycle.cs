/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        ListNode tmp = head;

        if (head == null)
            return false;
        else if (head.next == head)
            return true;

        while (head != null && tmp != null && tmp.next != null)
        {
            tmp = tmp.next.next;
            head = head.next;
            if (head == tmp)
                return true;
        }
        return false;
    }
}
