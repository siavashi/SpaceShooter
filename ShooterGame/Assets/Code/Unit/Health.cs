using System;
using UnityEngine;

namespace TAMKShooter
{
	public class Health : MonoBehaviour, IHealth
	{
		[SerializeField]
		private int _health;

		private int _originalHealth;
		
		public int CurrentHealth
		{
			get { return _health; }
			set
			{
				if ( !IsImmortal )
				{
					_health = Mathf.Clamp( value, 0, value );
					if ( HealthChanged != null )
					{
						HealthChanged( this, new HealthChangedEventArgs( _health ) );
					}
				}
			}
		}

		public bool IsImmortal { get; set; }

		public event HealthChangedDelegate HealthChanged;

		public void Init()
		{
			_originalHealth = CurrentHealth;
			IsImmortal = false;
		}

		/// <summary>
		/// Applies damage. Returns true if health was reduced to zero.
		/// </summary>
		/// <param name="damage">Amount of damage applied</param>
		/// <returns>True, if health reduced to zero. False otherwise</returns>
		public bool TakeDamage ( int damage )
		{
			CurrentHealth -= damage;
			return CurrentHealth == 0;
		}

		public void Reset()
		{
			CurrentHealth = _originalHealth;
		}
	}
}
