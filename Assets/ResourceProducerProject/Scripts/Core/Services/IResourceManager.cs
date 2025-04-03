public interface IResourceManager
{
    void AddResource(string resourceId, int amount);
    int GetResourceCount(string resourceId);
}