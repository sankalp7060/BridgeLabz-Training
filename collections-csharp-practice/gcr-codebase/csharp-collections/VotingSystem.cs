using System;
using System.Collections.Generic;

class VotingSystem
{
    static void Main()
    {
        Dictionary<string, int> votes = new Dictionary<string, int>();
        SortedDictionary<string, int> sortedVotes;
        List<string> voteOrder = new List<string>();

        CastVote("A");
        CastVote("B");
        CastVote("A");
        CastVote("C");
        CastVote("B");

        void CastVote(string candidate)
        {
            voteOrder.Add(candidate);

            if (votes.ContainsKey(candidate))
                votes[candidate]++;
            else
                votes[candidate] = 1;
        }

        Console.WriteLine("Vote Order:");
        foreach (var v in voteOrder)
            Console.Write(v + " ");

        sortedVotes = new SortedDictionary<string, int>(votes);

        Console.WriteLine("\n\nResults:");
        foreach (var v in sortedVotes)
            Console.WriteLine(v.Key + " : " + v.Value);
    }
}
