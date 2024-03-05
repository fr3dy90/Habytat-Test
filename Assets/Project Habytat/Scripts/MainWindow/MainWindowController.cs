using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    [Header("Singleton")] public static MainWindowController Instance;

    [SerializeField] private MainWindowView _view;
    private IEnumerator onShowPanel;
    private IEnumerator onShowButtons;
    private const float _zero = 0;
    private const float _one = 1;

    public void OnShowWindow(string _title, string _leyend, bool _closePanel, bool _rejectBtn, bool _confirmBtn, Action onClosePanel = null, string _txtConfirmBtn = null, Action onConfirmBtn = null, string _txtRejectmBtn = null, Action onRejectBtn = null)
    {
        _view._canvasGroup.alpha = _zero;
        _view._canvasGroup.blocksRaycasts = true;
        _view._canvasGroup.interactable = true;
        
        _view.CleanBtn(_view._closeBtn);
        _view.CleanBtn(_view._confirmBtn);
        _view.CleanBtn(_view._rejectBtn);

        _view.SetText(_view._title, _title);
        _view.SetText(_view._leyend, _leyend);
        
        _view._closeBtn.onClick.AddListener(Close);
        if (onClosePanel != null)
        {
            _view._closeBtn.onClick.AddListener(() => onClosePanel?.Invoke());
        }
        
        _view.SetText(_view._rejectTxt, _txtRejectmBtn);
        if (onRejectBtn != null)
        {
            _view._rejectBtn.onClick.AddListener(() => onRejectBtn?.Invoke());
        }
        
        _view.SetText(_view._confirmTxt, _txtConfirmBtn);
        if (onConfirmBtn != null)
        {
            _view._confirmBtn.onClick.AddListener(() => onConfirmBtn?.Invoke());
        }
        
        _view._canvasGroup.gameObject.SetActive(true);
        if (onShowPanel != null)
        {
            StopCoroutine(onShowPanel);
        }

        onShowPanel = OnShowPanel(_zero, _closePanel, _rejectBtn, _confirmBtn);
        StartCoroutine(onShowPanel);
    }
    
    public void OnRefreshWindow(string _title, string _leyend, bool _closePanel, bool _rejectBtn, bool _confirmBtn, Action onClosePanel = null, string _txtConfirmBtn = null, Action onConfirmBtn = null, string _txtRejectmBtn = null, Action onRejectBtn = null)
    {
        HideButtons(false);
        
        _view.CleanBtn(_view._closeBtn);
        _view.CleanBtn(_view._confirmBtn);
        _view.CleanBtn(_view._rejectBtn);

        _view.SetText(_view._title, _title);
        _view.SetText(_view._leyend, _leyend);
        _view.SetButton(_view._closeBtn, _closePanel);
        
        _view._closeBtn.onClick.AddListener(Close);
        if (onClosePanel != null)
        {
            _view._closeBtn.onClick.AddListener(() => onClosePanel?.Invoke());
        }
        
        _view.SetText(_view._rejectTxt, _txtRejectmBtn);
        if (onRejectBtn != null)
        {
            _view._rejectBtn.onClick.AddListener(() => onRejectBtn?.Invoke());
        }
        
        _view.SetText(_view._confirmTxt, _txtConfirmBtn);
        if (onConfirmBtn != null)
        {
            _view._confirmBtn.onClick.AddListener(() => onConfirmBtn?.Invoke());
        }

        if (onShowButtons != null)
        {
            StopCoroutine(onShowButtons);
        }

        onShowButtons = OnShowButtons(_closePanel, _rejectBtn, _confirmBtn);
        StartCoroutine(onShowButtons);
    }

    private void HideButtons(bool isActive)
    {
        _view.SetButton(_view._closeBtn, isActive);
        _view.SetButton(_view._confirmBtn, isActive);
        _view.SetButton(_view._rejectBtn, isActive);
    }
    
    IEnumerator OnShowPanel(float _start, bool _closeBtn, bool _rejectBtn, bool _confirmBtn)
    {
        float target = _start > 0f ? 0f : 1f;
        
        HideButtons(false);

        while (_start != target)
        {
            _start = Mathf.MoveTowards(_start, target, Time.deltaTime / .5f);
            _view._canvasGroup.alpha = _start;
            yield return null;
        }

        yield return new WaitForSeconds(.5f);
        if(_start > _zero)
        {
            _view.SetButton(_view._closeBtn, _closeBtn);
            _view.SetButton(_view._confirmBtn, _confirmBtn);
            _view.SetButton(_view._rejectBtn, _rejectBtn);
        }

        if (target == _zero)
        {
            _view._canvasGroup.blocksRaycasts = false;
            _view._canvasGroup.interactable = false;
            _view._canvasGroup.gameObject.SetActive(false);
        }
    }

    IEnumerator OnShowButtons(bool _closePanel, bool _rejectBtn, bool _confirmBtn)
    {
        yield return new WaitForSeconds(2f);
        _view.SetButton(_view._closeBtn, _closePanel);
        _view.SetButton(_view._rejectBtn, _rejectBtn);
        _view.SetButton(_view._confirmBtn, _confirmBtn);
    }

    private void Close()
    {
        if (onShowPanel != null)
        {
            StopCoroutine(onShowPanel);
        }

        onShowPanel = OnShowPanel(_one, false, false, false);
        StartCoroutine(onShowPanel);
    }
}