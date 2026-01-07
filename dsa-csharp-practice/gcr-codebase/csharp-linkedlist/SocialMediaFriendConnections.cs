using System;

class UserNode
{
    public int UserId;
    public string Name;
    public int Age;

    public int[] Friends;
    public int FriendCount;

    public UserNode Next;

    public UserNode(int userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
        Friends = new int[10]; // max 10 friends
        FriendCount = 0;
        Next = null;
    }
}

class SocialMedia
{
    private UserNode head;

    // Add new user
    public void AddUser(int id, string name, int age)
    {
        UserNode newNode = new UserNode(id, name, age);

        if (head == null)
        {
            head = newNode;
            return;
        }

        UserNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Find user by ID
    private UserNode FindUser(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserId == id)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    // Add friend connection
    public void AddFriend(int id1, int id2)
    {
        UserNode u1 = FindUser(id1);
        UserNode u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        u1.Friends[u1.FriendCount++] = id2;
        u2.Friends[u2.FriendCount++] = id1;

        Console.WriteLine("Friend connection added.");
    }

    // Remove friend connection
    public void RemoveFriend(int id1, int id2)
    {
        UserNode u1 = FindUser(id1);
        UserNode u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        RemoveFriendFromList(u1, id2);
        RemoveFriendFromList(u2, id1);

        Console.WriteLine("Friend connection removed.");
    }

    private void RemoveFriendFromList(UserNode user, int friendId)
    {
        for (int i = 0; i < user.FriendCount; i++)
        {
            if (user.Friends[i] == friendId)
            {
                for (int j = i; j < user.FriendCount - 1; j++)
                    user.Friends[j] = user.Friends[j + 1];

                user.FriendCount--;
                return;
            }
        }
    }

    // Mutual friends
    public void FindMutualFriends(int id1, int id2)
    {
        UserNode u1 = FindUser(id1);
        UserNode u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine("Mutual Friends:");
        for (int i = 0; i < u1.FriendCount; i++)
        {
            for (int j = 0; j < u2.FriendCount; j++)
            {
                if (u1.Friends[i] == u2.Friends[j])
                    Console.WriteLine("User ID: " + u1.Friends[i]);
            }
        }
    }

    // Display friends of a user
    public void DisplayFriends(int id)
    {
        UserNode user = FindUser(id);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine("Friends of " + user.Name + ":");
        for (int i = 0; i < user.FriendCount; i++)
            Console.WriteLine("Friend ID: " + user.Friends[i]);
    }

    // Search user
    public void SearchUser(string name)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Found: ID={temp.UserId}, Name={temp.Name}, Age={temp.Age}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("User not found.");
    }

    // Count friends
    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Name} has {temp.FriendCount} friends.");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        SocialMedia sm = new SocialMedia();

        sm.AddUser(1, "Alice", 21);
        sm.AddUser(2, "Bob", 22);
        sm.AddUser(3, "Charlie", 23);

        sm.AddFriend(1, 2);
        sm.AddFriend(1, 3);

        sm.DisplayFriends(1);
        sm.FindMutualFriends(2, 3);

        sm.SearchUser("Alice");

        sm.CountFriends();

        sm.RemoveFriend(1, 2);
        sm.DisplayFriends(1);
    }
}
