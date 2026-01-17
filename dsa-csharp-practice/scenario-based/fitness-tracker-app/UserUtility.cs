using System;

class UserUtility : IUser
{
    public void RankUsers(User[] users)
    {
        for (int i = 0; i < users.Length - 1; i++)
        {
            bool isSwapped = false;
            for (int j = 0; j < users.Length - i - 1; j++)
            {
                if (users[j].Steps > users[j + 1].Steps)
                {
                    User t = users[j];
                    users[j] = users[j + 1];
                    users[j + 1] = t;
                    isSwapped = true;
                }
            }
            if (!isSwapped)
            {
                return;
            }
        }
    }

    public void Display(User[] users)
    {
        for (int i = 0; i < users.Length; i++)
        {
            Console.WriteLine($"Rank {i + 1}: {users[i]}");
        }
    }
}
