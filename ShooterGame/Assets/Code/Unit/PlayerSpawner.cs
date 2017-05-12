using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using UnityEngine;

namespace TAMKShooter.Level
{
	public class PlayerSpawner : MonoBehaviour
	{
		[SerializeField] private PlayerData.PlayerId _player;

		private PlayerUnits _playerUnits;

		public PlayerData.PlayerId PlayerId { get { return _player; } }

		public void Init( PlayerUnits playerUnits )
		{
			_playerUnits = playerUnits;
		}

		public void Spawn()
		{
			PlayerUnit playerUnit = _playerUnits.GetPlayerUnit( _player );
			if ( playerUnit != null )
			{
				playerUnit.Respawn( transform.position );
			}
		}
	}
}
