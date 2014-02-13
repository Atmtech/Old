namespace ATMTECH.Web.Session
{
    public interface IStateValue<T>
    {
        string Clef { get; }
        T Value { get; set; }
    }
}
