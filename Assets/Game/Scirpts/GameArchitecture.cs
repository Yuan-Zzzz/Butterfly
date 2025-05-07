using QFramework;

namespace ProjectAssets.Scripts.Game.System
{
    public class GameArchitecture : Architecture<GameArchitecture>
    {
        protected override void Init()
        {
            this.RegisterSystem<ISwitchSceneSystem>(new SwitchSceneSystem());
        }
    }
}