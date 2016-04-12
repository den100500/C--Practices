using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PingPong2
{
    public class Unit
    {
        public Guid ID { get; }
        public string Name { get; }
        public Point Position { get; private set; }
        public Team Team { get; }
        Stats BaseStats, CurrentStats;
        List<Ability> BaseAbilities;
        List<Ability> AvailableAbilities;
        public Dictionary<Stats, int> AbilityEffects;

        private void Die() { }

        public static List<Unit> GetAllUnits()
        {
            throw new NotImplementedException();
        }

        public void CalculateCurrentStats()
        {
            CurrentStats = new Stats(BaseStats);
            foreach (var effect in AbilityEffects)
                CurrentStats += effect.Key;
            if (CurrentStats.CurrentHealth <= 0 || CurrentStats.MaxHealth <= 0)
                Die();
            CurrentStats.Correct();
        }

        public void CheckForAvailableAbilities()
        {
            AvailableAbilities.Clear();
            foreach (var ability in BaseAbilities)
                if (ability.ActiveCoolDown == 0 && ability.ManaCost <= CurrentStats.CurrentMana)
                    AvailableAbilities.Add(ability);
        }

        public void Cast(Guid AbilityId)
        {
            Ability castedAbility = null;
            try
            {
                castedAbility = BaseAbilities.Single(x => x.Id == AbilityId);
            }
            catch
            {
                return;
            }
            Selection selection;
            if (castedAbility is TargetAbility)
                selection = new TargetSelection(castedAbility.targetType);
            else
                selection = new AreaSelection(((AoEAbility)castedAbility).Radius);

            castedAbility.Apply(selection);
        }

        public void AdvanceTime()
        {
            for (int i = 0; i < BaseAbilities.Count; i++)
                BaseAbilities[i].ActiveCoolDown = BaseAbilities[i].ActiveCoolDown == 0 ?
                                                    0 : BaseAbilities[i].ActiveCoolDown - 1;
            for (int i = 0; i < AbilityEffects.Count;)
            {
                var effect = AbilityEffects.ElementAt(i);
                if (effect.Value == 1)
                    AbilityEffects.Remove(effect.Key);
                else {
                    i++;
                    AbilityEffects[effect.Key]--;
                }
            }
        }
    }
}