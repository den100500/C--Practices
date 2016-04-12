using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BaseProject
{
    public class Unit
    {
        public Guid ID { get; }
        public string Name { get; }
        public Point Position { get; private set; }
        public Stats BaseStats, CurrentStats;
        public List<Ability> BaseAbilities;
        public List<Ability> AvailableAbilities;
        public Dictionary<Stats, int> AbilityEffects;

        private void Die() { }

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

        public void Cast(Guid AbilityId, Unit Target = null)
        {
            Ability castedAbility = null;
            try {
                castedAbility = BaseAbilities.Single(x => x.Id == AbilityId);
            }
            catch
            {
                return;
            }
            castedAbility.ActiveCoolDown = castedAbility.CoolDown;
            if (Target == null)
            {
                AbilityEffects.Add(castedAbility.Effect, castedAbility.Duration);
            }
            else
            {
                Target.AbilityEffects.Add(castedAbility.Effect, castedAbility.Duration);
            }
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