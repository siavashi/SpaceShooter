using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using System;
using System.Linq;
using TAMKShooter.Level;

namespace TAMKShooter
{
	public class PlayerUnits : MonoBehaviour
	{
		private Dictionary<PlayerData.PlayerId, PlayerUnit> _players =
			new Dictionary<PlayerData.PlayerId, PlayerUnit> ();

		private PlayerSpawner[] _playerSpawners;

		public void Init(params PlayerData[] players)
		{
			_playerSpawners = FindObjectsOfType< PlayerSpawner >();
			foreach ( var playerSpawner in _playerSpawners )
			{
				playerSpawner.Init( this );
			}

			foreach (PlayerData playerData in players)
			{
				// Get prefab by UnitType
				PlayerUnit unitPrefab =
					Global.Instance.Prefabs.
					GetPlayerUnitPrefab ( playerData.UnitType );

				if(unitPrefab != null)
				{
					// Initialize unit
					PlayerUnit unit = Instantiate ( unitPrefab, transform );
					unit.transform.position = Vector3.zero;
					unit.transform.rotation = Quaternion.identity;

					// Add player to dictionary
					_players.Add(playerData.Id, unit);

					unit.Init ( this, playerData );
				}
				else
				{
					Debug.LogError ( "Unit prefab with type " + playerData.UnitType +
						" could not be found!" );
				}
			}
		}

		public PlayerSpawner GetSpawnerByPlayerId( PlayerData.PlayerId playerId )
		{
			// Same using Linq.
			// return _playerSpawners.FirstOrDefault( s => s.PlayerId == playerId );

			PlayerSpawner spawner = null;

			foreach ( var playerSpawner in _playerSpawners )
			{
				if ( playerSpawner.PlayerId == playerId )
					spawner = playerSpawner;
			}
			return spawner;
		}

		public void UpdateMovement ( InputManager.ControllerType controller, 
			Vector3 input, bool shoot )
		{
			PlayerUnit playerUnit = null;
			foreach (var player in _players)
			{
				if(player.Value.Data.Controller == controller)
				{
					playerUnit = player.Value;
				}
			}

			if(playerUnit != null)
			{
				playerUnit.HandleInput ( input, shoot );
			}
		}

		public PlayerUnit GetPlayerUnit( PlayerData.PlayerId playerId )
		{
			return _players.ContainsKey( playerId ) 
				? _players[ playerId ] 
				: null;
		}

		public void PlayerDied( PlayerUnit playerUnit )
		{
			bool arePlayersAlive = false;
			foreach ( var player in _players.Values )
			{
				if ( player.Data.Lives > 0 )
				{
					arePlayersAlive = true;
				}
			}

			if ( !arePlayersAlive )
			{
				Global.Instance.GameManager.PerformTransition( GameStateTransitionType.InGameToGameOver );
			}
		}
	}
}

