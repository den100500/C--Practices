using System;

namespace PingPong2
{
    public abstract class Ability : IAbility<Selection>
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int ManaCost { get; }
        public int Duration { get; }
        public int CoolDown { get; }
        public int ActiveCoolDown { get; set; }
        public Stats Effect { get; }
        public Unit Owner { get; }
        public TargetType targetType { get; }

        public abstract void Apply(Selection selection);
    }
}