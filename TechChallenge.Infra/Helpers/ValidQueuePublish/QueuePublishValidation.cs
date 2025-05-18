namespace TechChallenge.Infra.Helpers.ValidQueuePublish;
public static class QueuePublishValidation
{
    public static bool Validation<T>(string? queue, T? data)
    {
        if (string.IsNullOrEmpty(queue))
            return false;

        if (data is null)
            return false;

        return true;
    }

    public static bool Validation(string? queue)
    {
        if (string.IsNullOrEmpty(queue))
            return false;

        return true;
    }

    public static bool Validation<T>(T? data) where T : class
    {
        if (data is null)
            return false;

        return true;
    }
}
