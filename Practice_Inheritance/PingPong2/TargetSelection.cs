namespace PingPong2
{
    public class TargetSelection : Selection
    {
        public Unit SelectedUnit { get; }

        public TargetSelection(TargetType tType)
        {
            SelectedUnit = new Unit();
        }
    }
}