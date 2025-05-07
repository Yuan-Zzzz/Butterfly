using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:c419f46d-dcb1-48f6-adc8-2d45f4eb9dd8
	public partial class UIChessBorad
	{
		public const string Name = "UIChessBorad";
		
		[SerializeField]
		public UnityEngine.UI.Image Image;
		[SerializeField]
		public UnityEngine.UI.Image Image1;
		[SerializeField]
		public UnityEngine.UI.Image Image2;
		[SerializeField]
		public UnityEngine.UI.Image Image3;
		[SerializeField]
		public UnityEngine.UI.Image Image4;
		[SerializeField]
		public UnityEngine.UI.Image Image5;
		[SerializeField]
		public UnityEngine.UI.Image Image6;
		[SerializeField]
		public UnityEngine.UI.Image Image7;
		[SerializeField]
		public UnityEngine.UI.Image Image8;
		[SerializeField]
		public UnityEngine.UI.Image Image9;
		[SerializeField]
		public UnityEngine.UI.Image Image10;
		[SerializeField]
		public UnityEngine.UI.Image Image11;
		[SerializeField]
		public UnityEngine.UI.Image Image12;
		[SerializeField]
		public UnityEngine.UI.Image Image13;
		[SerializeField]
		public UnityEngine.UI.Image Image14;
		[SerializeField]
		public UnityEngine.UI.Image Image15;
		[SerializeField]
		public UnityEngine.UI.Image Image16;
		
		private UIChessBoradData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Image = null;
			Image1 = null;
			Image2 = null;
			Image3 = null;
			Image4 = null;
			Image5 = null;
			Image6 = null;
			Image7 = null;
			Image8 = null;
			Image9 = null;
			Image10 = null;
			Image11 = null;
			Image12 = null;
			Image13 = null;
			Image14 = null;
			Image15 = null;
			Image16 = null;
			
			mData = null;
		}
		
		public UIChessBoradData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIChessBoradData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIChessBoradData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
