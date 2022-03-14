namespace SongsTrack.Shared.Models
{
    public class Data<T>
    {
        public ICollection<T> CurrentPageData { get; set; }
        public int TotalItemCount { get; set; }

    }
}
