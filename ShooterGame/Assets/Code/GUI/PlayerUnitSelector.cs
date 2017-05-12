using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
	public class PlayerUnitSelector : MonoBehaviour
	{
		private Dropdown _dropdown;

		public PlayerData.PlayerId PlayerId { get; private set; }
		public PlayerUnit.UnitType SelectedUnitType { get; private set; }

		public void Init( PlayerData.PlayerId playerId )
		{
			PlayerId = playerId;

			_dropdown = GetComponentInChildren< Dropdown >( true );
			_dropdown.ClearOptions();
			var optionDataList = new List< Dropdown.OptionData >();
			foreach ( var value in Enum.GetValues( typeof(PlayerUnit.UnitType) ) )
			{
				if ( (PlayerUnit.UnitType) value != PlayerUnit.UnitType.None )
				{
					optionDataList.Add( new Dropdown.OptionData( value.ToString() ) );
				}
			}
			_dropdown.AddOptions( optionDataList );
			_dropdown.onValueChanged.AddListener( OnValueChanged );

			_dropdown.value = 0;
			OnValueChanged( 0 );
		}

		private void OnValueChanged( int index )
		{
			string selectionText = _dropdown.options[ index ].text;
			SelectedUnitType = (PlayerUnit.UnitType)
				Enum.Parse( typeof( PlayerUnit.UnitType ), selectionText );
		}
	}
}
