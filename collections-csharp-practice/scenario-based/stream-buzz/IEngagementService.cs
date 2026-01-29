using System.Collections.Generic;

public interface IEngagementService
{
    void RegisterCreator(CreatorStats record);

    Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold);

    double CalculateAverageLikes();
}
