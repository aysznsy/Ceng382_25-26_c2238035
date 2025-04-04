public class ClassInformationModel
{
    private static int _idCounter = 0;

    public int Id { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public int StudentCount { get; set; }
    public string Description { get; set; } = string.Empty;

    public ClassInformationModel()
    {
        Id = ++_idCounter;
    }
}
