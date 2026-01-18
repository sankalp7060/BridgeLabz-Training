public class LLMiddleNode
{
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null)
            return null;
        ListNode s = head;
        ListNode f = head;
        while (f != null && f.next != null)
        {
            s = s.next;
            f = f.next.next;
        }
        return s;
    }
}
