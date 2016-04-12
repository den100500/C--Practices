using System;

namespace BaseProject
{
    public class Stats
    {
        public int MaxHealth { get; private set; }
        public int MaxMana { get; private set; }
        public int CurrentHealth { get; private set; }
        public int CurrentMana { get; private set; }
        public int HealthRegenPerSecond { get; private set; }
        public int ManaRegenPerSecond { get; private set; }
        public int MovementSpeed { get; private set; }
        public int Damage { get; private set; }
        public double AttackRange { get; private set; }
        public int DamageReduction { get; private set; }

        public Stats() { }

        public Stats(Stats source)
        {
            MaxHealth = source.MaxHealth;
            MaxMana = source.MaxMana;
            CurrentHealth = source.CurrentHealth;
            CurrentMana = source.CurrentMana;
            HealthRegenPerSecond = source.HealthRegenPerSecond;
            ManaRegenPerSecond = source.ManaRegenPerSecond;
            MovementSpeed = source.MovementSpeed;
            Damage = source.Damage;
            AttackRange = source.AttackRange;
            DamageReduction = source.DamageReduction;
        }

        public static Stats operator +(Stats op1, Stats op2)
        {
            Stats sum = new Stats();
            sum.MaxHealth = op1.MaxHealth + op2.MaxHealth;
            sum.MaxMana = op1.MaxMana + op2.MaxMana;
            sum.CurrentHealth = op1.CurrentHealth + op2.CurrentHealth;
            sum.CurrentMana = op1.CurrentMana + op2.CurrentMana;
            sum.HealthRegenPerSecond = op1.HealthRegenPerSecond + op2.HealthRegenPerSecond;
            sum.ManaRegenPerSecond = op1.ManaRegenPerSecond + op2.ManaRegenPerSecond;
            sum.MovementSpeed = op1.MovementSpeed + op2.MovementSpeed;
            sum.Damage = op1.Damage + op2.Damage;
            sum.AttackRange = op1.AttackRange + op2.AttackRange;
            sum.DamageReduction = op1.DamageReduction + op2.DamageReduction;
            return sum;
        }

        public void Correct()
        {
            MaxHealth = Math.Max(0, MaxHealth);
            MaxMana = Math.Max(0, MaxMana);
            CurrentHealth = Math.Max(0, CurrentHealth);
            CurrentMana = Math.Max(0, CurrentMana);
            HealthRegenPerSecond = Math.Max(0, HealthRegenPerSecond);
            ManaRegenPerSecond = Math.Max(0, ManaRegenPerSecond);
            MovementSpeed = Math.Max(0, MovementSpeed);
            Damage = Math.Max(0, Damage);
            AttackRange = Math.Max(0, AttackRange);
        } 
    }
}