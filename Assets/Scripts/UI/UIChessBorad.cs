using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public class UIChessBoradData : UIPanelData
	{
	}
	public partial class UIChessBorad : UIPanel
	{
		protected override async void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIChessBoradData ?? new UIChessBoradData();
			// please add init code here
			Image.transform.localScale = Vector3.zero;
			Image.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);

			Image1.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image2.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image3.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image4.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image5.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image6.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image7.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image8.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image9.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image10.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image11.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image12.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image13.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image14.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image15.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			Image16.DOFade(1, 0.2f);
			await UniTask.Delay(150);
			await UniTask.Delay(2000);
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
