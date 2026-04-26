namespace Assignment05
{
    public interface IBookable
    {
        bool IsBooked { get; }
        void Book();
        void Cancel();
    }
}