namespace PingPong1
{
    public class TargetAbility : Ability
    {
        public bool SelfCast { get; }

        public override void Apply(Selection selection)
        {
            ActiveCoolDown = CoolDown;
            if (((TargetSelection)selection).SelectedUnit == null)
            {
                Owner.AbilityEffects.Add(Effect, Duration);
            }
            else
            {
                ((TargetSelection)selection).SelectedUnit.AbilityEffects.Add(Effect, Duration);
            }
        }
    }
}