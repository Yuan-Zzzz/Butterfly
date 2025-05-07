using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:94146e78-22ad-49f6-9903-842f7205d869
	public partial class UIFadePanel
	{
		public const string Name = "UIFadePanel";
		
		[SerializeField]
		public UnityEngine.CanvasGroup FadeImage;
		
		private UIFadePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			FadeImage = null;
			
			mData = null;
		}
		
		public UIFadePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIFadePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIFadePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
