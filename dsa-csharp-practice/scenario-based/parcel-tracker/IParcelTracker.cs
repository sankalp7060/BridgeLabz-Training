public interface IParcelTracker
{
    void AddStage(string stage);
    void AddCheckpointAfter(string existingStage, string newStage);
    void DisplayTracking();
    bool IsParcelLost();
}
