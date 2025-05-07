using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using QFramework;
using QFramework.Example;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectAssets.Scripts.Game.System
{
    public interface ISwitchSceneSystem : ISystem
    {
        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="sceneName"></param>
        UniTask  SwitchSceneAsync(string sceneName);
        Action OnSceneLoaded { get; set; }
    }

    public class SwitchSceneSystem : AbstractSystem, ISwitchSceneSystem
    {
        private string _nowSwitchSceneName;

        protected override void OnInit()
        {
            // //场景加载完回调
            // SceneManager.sceneLoaded += (arg0, mode) =>
            // {
            //     if (_nowSwitchSceneName == arg0.path)
            //     {
            //         LoadSceneRight();
            //     }
            // };
        }

        private void LoadSceneRight()
        {
        }

        public async UniTask SwitchSceneAsync(string sceneName)
        {
            _nowSwitchSceneName = sceneName;
            await UIKit.OpenPanelAsync<UIFadePanel>(UILevel.PopUI).ToUniTask();
            await UIKit.GetPanel<UIFadePanel>().FadeIn();
            await UniTask.Delay(2000);
            await LoadScene(sceneName);
            await UniTask.Delay(2000);
            await UIKit.GetPanel<UIFadePanel>().FadeOut();
            OnSceneLoaded?.Invoke();
        }

        public Action OnSceneLoaded { get; set; }

        private async UniTask LoadScene(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;
            await UniTask.WaitUntil(() => operation.progress >= 0.9f);
            operation.allowSceneActivation = true;
        }
    }
}