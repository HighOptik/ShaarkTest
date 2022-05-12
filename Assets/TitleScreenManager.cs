using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class TitleScreenManager : MonoBehaviour
{
    public CanvasGroup controls;
    bool controlsActive;
    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().DOFade(1, 1);
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Controls()
    {
        controlsActive = !controlsActive;
        controls.DOFade(controlsActive ? 1 : 0, 1);
        controls.interactable = controlsActive;
        controls.blocksRaycasts= controlsActive;
    }
}
