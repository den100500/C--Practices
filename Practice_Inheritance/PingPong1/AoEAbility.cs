namespace PingPong1
{
    public class AoEAbility : Ability
    {
        public int Radius { get; }

        public override void Apply(Selection selection)
        {
            ActiveCoolDown = CoolDown;
            for (int i = 0; i < ((AreaSelection)selection).SelectedUnits.Count; i++)
                ((AreaSelection)selection).SelectedUnits[i].AbilityEffects.Add(Effect, Duration);
        }
    }
}