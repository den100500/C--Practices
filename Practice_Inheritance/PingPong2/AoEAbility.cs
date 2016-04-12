namespace PingPong2
{
    public class AoEAbility : Ability
    {
        public int Radius { get; }

        public override void Apply(Selection selection)
        {
            ActiveCoolDown = CoolDown;
            for (int i = 0; i < ((AreaSelection)selection).SelectedUnits.Count; i++) {
                Unit target = ((AreaSelection)selection).SelectedUnits[i];
                if (targetType == TargetType.Allies && Team.AreAllies(Owner, target) ||
                    targetType == TargetType.Enemies && Team.AreEnemies(Owner, target))
                    target.AbilityEffects.Add(Effect, Duration);
            }
        }
    }
}