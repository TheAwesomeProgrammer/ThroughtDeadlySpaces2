using System;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
	[Serializable]
	public class TextRow
	{
		private const int AttributesPerRow = 3;

		private Text _rowText;
		private int _elementsCount;

		public TextRow(Text rowText)
		{
			_rowText = rowText;
		}

		public bool TryAddText(string text, bool addNewLine = true)
		{
			if (HasReachedLimit() == false)
			{
				AddText(text, addNewLine);
				return true;
			}
			return false;
		}

		public void AddText(string text, bool addNewLine = true)
		{
			_elementsCount++;
			_rowText.text += text;
			if (addNewLine)
			{
				_rowText.text += Environment.NewLine;
			}
		}

		public void Clear()
		{
			_rowText.text = "";
			_elementsCount = 0;
		}

		private bool HasReachedLimit()
		{
			return _elementsCount >= AttributesPerRow;
		}
	}
}