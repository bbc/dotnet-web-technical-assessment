namespace ElectionsApiApplication.Models
{
    public class ConstituencyResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SeqNo { get; set; }
        public List<PartyResult> PartyResults { get; set; } = new List<PartyResult>();
    }
}
