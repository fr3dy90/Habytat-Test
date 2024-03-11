using UnityEngine;
using UnityEngine.UI;

public class LoaderView : MonoBehaviour
{
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private Image _loaderImage;

   public void HardFade(float alphaValue, bool interactions, float fillValue)
   {
      _canvasGroup.interactable = interactions;
      _canvasGroup.blocksRaycasts = interactions;
      _loaderImage.fillAmount = fillValue;
      _canvasGroup.alpha = alphaValue;
   }
   
   public void SetProgress(float _progress)
   {
      _loaderImage.fillAmount = _progress;
   }
   
   public void SetAlpha(float _alpha)
   {
      _canvasGroup.alpha = _alpha;
   }
}
