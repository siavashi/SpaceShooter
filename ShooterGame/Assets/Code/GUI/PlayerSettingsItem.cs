using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
	public class PlayerSettingsItem : MonoBehaviour
	{
		[SerializeField] private PlayerData.PlayerId _id;
		[SerializeField] private Text _playerIdText;

		private ControllerSelector _controllerSelector;
		private PlayerUnitSelector _playerUnitSelector;

		public InputManager.ControllerType Controller
		{
			get { return _controllerSelector.Controller; }
		}

		public PlayerUnit.UnitType UnitType
		{
			get { return _playerUnitSelector.SelectedUnitType; }
		}

		public PlayerData.PlayerId PlayerId { get { return _id; } }

		public void Init()
		{
			_controllerSelector =
				GetComponentInChildren< ControllerSelector >( true );
			_controllerSelector
				.Init( _id, InputManager.ControllerType.KeyboardWasd );

			_playerUnitSelector =
				GetComponentInChildren< PlayerUnitSelector >( true );
			_playerUnitSelector.Init(_id);

			_playerIdText.text = string.Format( "Player {0}", (int) _id );
		}
	}
}
