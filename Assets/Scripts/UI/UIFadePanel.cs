using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UIFadePanelData : UIPanelData
    {
        public float FadeInTime = 0.5f; // 淡入时间
        public float FadeOutTime = 0.8f; // 淡出时间
    }
    public partial class UIFadePanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIFadePanelData ?? new UIFadePanelData();
			
			
            FadeImage.DOFade(0, mData.FadeInTime);
        }

        public async UniTask FadeIn()
        {
            FadeImage.alpha = 0;
            FadeImage.DOFade(1, mData.FadeInTime);
            await UniTask.Delay((int)(mData.FadeInTime * 1000));
        }
		
        public async UniTask FadeOut()
        {
            FadeImage.DOFade(0, mData.FadeOutTime);
            await UniTask.Delay((int)(mData.FadeOutTime * 1000));
            CloseSelf();
        }
        protected override void OnOpen(IUIData uiData = null)
        {
        }
		
        protected override void OnShow()
        {
        }
		
        protected override void OnHide()
        {
        }
		
        protected override void OnClose()
        {
        }
    }
}