namespace MoladAPI.MoladObjects
{
    public class MoladRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MoladRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public bool IsInRange(DateTime date)
        {
            return date >= StartDate && date <= EndDate;
        }
    }
}
