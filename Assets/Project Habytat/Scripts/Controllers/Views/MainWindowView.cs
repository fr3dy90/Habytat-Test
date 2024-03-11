using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainWindowView : MonoBehaviour
{
   [Header("Window basic")]
   public CanvasGroup _canvasGroup;
   public TextMeshProUGUI _title;
   public TextMeshProUGUI _leyend;
   public TextMeshProUGUI _confirmTxt;
   public TextMeshProUGUI _rejectTxt;

   [Header("Window Buttons")] 
   public Button _closeBtn;
   public Button _confirmBtn;
   public Button _rejectBtn;

   public void SetText(TextMeshProUGUI _text, string _str)
   {
      _text.text = _str;
   }

   public void SetButton(Button _btn, bool _isActive)
   {
      _btn.gameObject.SetActive(_isActive);
   }

   public void CleanBtn(Button _btn)
   {
      _btn.onClick.RemoveAllListeners();
   }
}
