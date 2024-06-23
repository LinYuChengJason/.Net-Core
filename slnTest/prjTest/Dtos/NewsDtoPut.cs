namespace prjTest.Dtos
{
    public class NewsDtoPut
    {
        public Guid newsId { get; set; }

        public string title { get; set; } = null!;

        public string content { get; set; } = null!;

        public DateTime startDateTime { get; set; }

        public DateTime endDateTime { get; set; }

        public int click { get; set; }
    }
}
