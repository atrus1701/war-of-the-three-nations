using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WarOfTheThreeNations.Character.Stats;
using WarOfTheThreeNations.StatusEffects;


namespace WarOfTheThreeNations.Character
{

	public abstract class BattleCharacter : Character
	{
	
		protected ushort level;
		protected ulong experience;
		protected HitPointsStat hp;
		protected MagicPointsStat mp;
		protected AttackStat attack;
		protected DefenseStat defense;
		protected MagicStat magic;
		protected MagicDefenseStat mdef;
		protected AccuracyStat accuracy;
		protected LuckStat luck;
		
		protected Ability[] abilities;
		
		protected Dictionary<string, StatusEffect> status_effects;
		protected bool unconcious;
		
		protected BattleCharacter( string name, ulong experience, Dictionary<string, ushort> categories, Ability[] abilities )
			:base( name )
		{
			this.level = (ushort)(experience / 1000);
			this.experience = experience;
			this.hp = new HitPointsStat( this.level, categories[HitPointsStat.name], 5 );
			this.mp = new MagicPointsStat( this.level, categories[MagicPointsStat.name], 5 );
			this.attack = new AttackStat( this.level, categories[AttackStat.name], 5 );
			this.defense = new DefenseStat( this.level, categories[DefenseStat.name], 5 );
			this.magic = new MagicStat( this.level, categories[MagicStat.name], 5 );
			this.mdef = new MagicDefenseStat( this.level, categories[MagicDefenseStat.name], 5 );
			this.accuracy = new AccuracyStat( this.level, categories[AccuracyStat.name], 5 );
			this.luck = new LuckStat( this.level, categories[LuckStat.name], 5 );
			
			this.abilities = abilities;
			
			this.status_effects = new Dictionary<string, StatusEffect>();
			this.unconcious = false;
		}
	
		public void TakeDamage( int damage )
		{
			this.hp.Current = (uint)(this.hp.Current - damage);
			
			// check if unconcious
			if( this.hp.Current <= 0 )
			{
				this.unconcious = true;
			}
		}
		
		protected abstract void CharacterUnconcious();
		
		public bool HasStatusEffect( string name )
		{
			if( this.status_effects.ContainsKey(name) ) return true;
			else return false;
		}
		
		public void AddStatusEffect( string name )
		{
			if( this.HasStatusEffect(name) )
			{
				if( this.status_effects[name].IsRenewable() )
				{
					this.status_effects[name].Renew();
				}
			}
			else
			{
				this.status_effects.Add( name, StatusEffectManager.GetStatusEffect(name, this) );
			}
		}
		
		public void RemoveStatusEffect( string name )
		{
			this.status_effects.Remove(name);
		}
		
		public Stat GetStat( string name )
		{
			if( name == HitPointsStat.name )
				return this.hp;
			else if( name == MagicPointsStat.name )
				return this.mp;
			else if( name == AttackStat.name )
				return this.attack;
			else if( name == DefenseStat.name )
				return this.defense;
			else if( name == MagicStat.name )
				return this.magic;
			else if( name == MagicDefenseStat.name )
				return this.mdef;
			else if( name == AccuracyStat.name )
				return this.accuracy;
			else if( name == LuckStat.name )
				return this.luck;


			// generate error
			return null;
		}
		
		/* Accessors */
		public uint MaxHP { get { return this.hp.Max; } }
		public uint CurrentHP { get { return this.hp.Current; } }
		public uint MaxMP { get { return this.mp.Max; } }
		public uint CurrentMP { get { return this.mp.Current; } }		
		public HitPointsStat HP { get { return this.hp; } }
		public MagicPointsStat MP { get { return this.mp; } }
		public AttackStat Attack { get { return this.attack; } }
		public DefenseStat Defense { get { return this.defense; } }
		public MagicStat Magic { get { return this.magic; } }
		public MagicDefenseStat MagicDefense { get { return this.mdef; } }
		public AccuracyStat Accuracy { get { return this.accuracy; } }
		public LuckStat Luck { get { return this.luck; } }

		
	} // BattleCharacter

} // WarOfTheThreeNations.Character

