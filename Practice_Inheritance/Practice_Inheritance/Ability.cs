using System;

namespace BaseProject
{
    public class Ability
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int ManaCost { get; }
        public int Duration { get; }
        public int CoolDown { get; }
        public int ActiveCoolDown { get; set; }
        public Stats Effect { get; }
        public bool SelfCast { get; }
        public Unit Owner { get; }
    }
}