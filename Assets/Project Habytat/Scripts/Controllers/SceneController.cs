using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MainWindowController _controller;

    [SerializeField] private string[] title;
    [TextArea] [SerializeField] private string[] paragrapht;
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnShowWindow(title[0], paragrapht[0], false, false, true, null, "Continue", () => OnUpdateText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal virtual void OnInit()
    {
        
    }

    private void OnUpdateText()
    {
        _controller.OnRefreshWindow(title[1], paragrapht[1], false, false, true, null, "Continue", () => OnUpdateMyText());
    }

    private void OnUpdateMyText()
    {
        _controller.OnRefreshWindow(title[2], paragrapht[2], true, false, false);
    }
}
