namespace PingPong1
{
    public interface IAbility<in T> where T : Selection
    {
        void Apply(T selection);
    }
}