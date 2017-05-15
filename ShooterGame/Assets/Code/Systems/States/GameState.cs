using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Configs;

namespace TAMKShooter.Systems.States
{
	public class GameState : GameStateBase
	{
		public int CurrentLevelIndex { get; private set; }

		public override string SceneName
		{
			get
			{
				try
				{
					return Config.LevelNames[CurrentLevelIndex];
				}
				catch( KeyNotFoundException exception )
				{
					Debug.LogException ( exception );
					return null;
				}
			}
		}

		public GameState(int levelIndex) : base()
		{
			State = GameStateType.InGameState;
			CurrentLevelIndex = levelIndex;
			AddTransition ( GameStateTransitionType.InGameToGameOver,
				GameStateType.GameOverState );
			AddTransition ( GameStateTransitionType.InGameToMenu,
				GameStateType.MenuState );
			AddTransition ( GameStateTransitionType.InGameToInGame,
				GameStateType.InGameState );
            AddTransition(GameStateTransitionType.InGameToGameCompleted,
                GameStateType.GameCompeletedState);
        }

		public GameState() : this ( 1 ) { }

		public void LevelCompleted()
		{

            if (SceneName == "Level1")
            {
                //TODO: Add proper Transition after the level is completed
                CurrentLevelIndex++;
                Debug.Log("LevelisCompleted");
                Global.Instance.GameManager.PerformTransition(
                    GameStateTransitionType.InGameToInGame);

            }
            else if (SceneName == "Level2")
            {
                Debug.Log("GameIsCompleted");
                CurrentLevelIndex++;
                    Global.Instance.GameManager.PerformTransition(
                    GameStateTransitionType.InGameToGameCompleted);
            }
               
                
            
            
            
        }


	}
}
