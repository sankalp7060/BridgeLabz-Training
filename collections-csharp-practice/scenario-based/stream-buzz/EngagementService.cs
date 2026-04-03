using System.Collections.Generic;

public class EngagementService : IEngagementService
{
    // Register creator
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    // Count weeks meeting threshold
    public Dictionary<string, int> GetTopPostCounts(
        List<CreatorStats> records,
        double likeThreshold
    )
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < records.Count; i++)
        {
            CreatorStats creator = records[i];
            int count = 0;

            for (int j = 0; j < creator.WeeklyLikes.Length; j++)
            {
                if (creator.WeeklyLikes[j] >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    // Calculate average of ALL weekly likes
    public double CalculateAverageLikes()
    {
        double sum = 0;
        int totalCount = 0;

        for (int i = 0; i < CreatorStats.EngagementBoard.Count; i++)
        {
            double[] likes = CreatorStats.EngagementBoard[i].WeeklyLikes;

            for (int j = 0; j < likes.Length; j++)
            {
                sum += likes[j];
                totalCount++;
            }
        }

        if (totalCount == 0)
            return 0;

        return sum / totalCount;
    }
}
