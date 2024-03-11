using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiView : MonoBehaviour
{
    public TextMeshProUGUI _actualLevel;
    public TextMeshProUGUI _actualExp;
    public TextMeshProUGUI _actualCoins;
    
    public Image _expBar;
    public Image _lifeBar;
    
    public void SetText(TextMeshProUGUI _text, string _str)
    {
       _text.text = _str;
    }
    
    public void SetBar(Image _bar, float _value)
    {
       _bar.fillAmount = _value;
    }
}

