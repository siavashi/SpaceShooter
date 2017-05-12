using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.GUI;
using UnityEngine;

namespace TAMKShooter.Systems
{
	public class MenuManager : SceneManager
	{
		private LoadWindow _loadWindow;
		private PlayerSettings _playerSettingsWindow;

		public override GameStateType StateType
		{
			get { return GameStateType.MenuState; }
		}

		private void Awake()
		{
			_loadWindow = GetComponentInChildren< LoadWindow >( true );
			_loadWindow.Init( this );
			_loadWindow.Close();

			_playerSettingsWindow = 
				GetComponentInChildren< PlayerSettings >( true );
			_playerSettingsWindow.Init( this );
			_playerSettingsWindow.Close();
		}

		public void StartGame( List< PlayerData > playerDatas )
		{
			_playerSettingsWindow.Close();

			// Create a new GameData object and initialize if with playerDatas list.
			Global.Instance.CurrentGameData = new GameData()
			{
				Level = 1,
				PlayerDatas = playerDatas
			};

			// Perform a transition to in game state.
			Global.Instance.GameManager.PerformTransition(
				GameStateTransitionType.MenuToInGame );
		}

		public void OpenStartGameWindow()
		{
			_playerSettingsWindow.Open();
		}

		public void OpenLoadWindow()
		{
			_loadWindow.Open();
		}

		public void LoadGame( string loadFileName )
		{
			_loadWindow.Close();

			GameData loadData = Global.Instance.SaveManager.Load( loadFileName );
			Global.Instance.CurrentGameData = loadData;
			Global.Instance.GameManager.
				PerformTransition( GameStateTransitionType.MenuToInGame );
		}

		public void QuitGame ()
		{
			Application.Quit ();
		}
	}
}
