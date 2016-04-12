namespace PingPong1
{
    public class TargetSelection : Selection
    {
        public Unit SelectedUnit { get; }

        public TargetSelection()
        {
            SelectedUnit = new Unit();
        }
    }
}