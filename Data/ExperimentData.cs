namespace ABLE_API.Data
{
    public class ExperimentData
    {
        public Guid UserId { get; set; }
        public required string ExperimentName { get; set; }
        public ExperimentStatus Status { get; set; }
        public required string Variant { get; set; }
    }

    public enum ExperimentStatus
    {
        Assigned,
        Exposed,
        Clicked
    }
}
