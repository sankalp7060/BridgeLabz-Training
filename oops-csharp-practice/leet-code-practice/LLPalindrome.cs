public class LLPalindrome
{
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return true;
        }
        ListNode s = head,
            f = head;
        while (f != null && f.next != null)
        {
            s = s.next;
            f = f.next.next;
        }
        ListNode t = reverseList(s);
        f = head;
        while (t != null)
        {
            if (t.val != f.val)
                return false;
            t = t.next;
            f = f.next;
        }
        return true;
    }

    public static ListNode reverseList(ListNode s)
    {
        ListNode prev = null,
            curr = s;
        while (curr != null)
        {
            ListNode t = curr.next;
            curr.next = prev;
            prev = curr;
            curr = t;
        }
        return prev;
    }
}
