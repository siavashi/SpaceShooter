using TAMKShooter.Configs;

namespace TAMKShooter.Systems.States
{
	public class GameOverState : GameStateBase
	{
		public override string SceneName
		{
			get { return Config.GameOverSceneName; }
		}

		public GameOverState()
		{
			State = GameStateType.GameOverState;
			AddTransition( GameStateTransitionType.GameOverToMenu, GameStateType.MenuState );
		}
	}
}