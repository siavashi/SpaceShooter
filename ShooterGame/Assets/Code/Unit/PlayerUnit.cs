using System;
using System.Collections;
using TAMKShooter.Data;
using UnityEngine;
using TAMKShooter.Configs;
using TAMKShooter.Level;
using UnityEngine.Networking;

namespace TAMKShooter
{
	public class PlayerUnit : UnitBase
	{
		public enum UnitType
		{
			None = 0,
			Fast = 1,
			Balanced = 2,
			Heavy = 3
		}

		private PlayerUnits _playerUnits;
		private PlayerSpawner _playerSpawner;

		[SerializeField] private UnitType _type;
		[SerializeField] private float _flashTime;

		public UnitType Type { get { return _type; } }
		public PlayerData Data { get; private set; }

		public override int ProjectileLayer
		{
			get
			{
				return LayerMask.NameToLayer ( Config.PlayerProjectileLayerName );
			}
		}

		public void Init( PlayerUnits playerUnits, PlayerData playerData )
		{
			Data = playerData;
			_playerUnits = playerUnits;
			_playerSpawner = _playerUnits.GetSpawnerByPlayerId( Data.Id );
			InitRequiredComponents();
			_playerSpawner.Spawn();
		}

		protected override void Die ()
		{
			// TODO: Handle dying properly!
			// Instantiate explosion effect
			// Play sound

			Data.Lives--;
			Health.Reset();

			_playerUnits.PlayerDied( this );

			if ( Data.Lives > 0 )
			{
				_playerSpawner.Spawn();
			}
			else
			{
				gameObject.SetActive( false );
			}

			base.Die ();
		}

		public void HandleInput ( Vector3 input, bool shoot )
		{
			Mover.MoveToDirection ( input );
			if(shoot)
			{
				Weapons.Shoot (ProjectileLayer);
			}
		}

		public void Respawn(Vector3 position)
		{
			if ( Data.Lives > 0 )
			{
				Position = position;
				StartCoroutine( Spawn() );
			}
		}

		private IEnumerator Spawn()
		{
			Health.IsImmortal = true;
			float respawnTime = 0;
			while ( respawnTime < Config.RespawnTime )
			{
				respawnTime += _flashTime;
				Renderer.enabled = !Renderer.enabled;
				yield return new WaitForSeconds( _flashTime );
			}

			Renderer.enabled = true;
			Health.IsImmortal = false;
		}
	}
}
