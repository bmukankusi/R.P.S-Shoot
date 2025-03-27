using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class UIManager : MonoBehaviour
{
    public CanvasGroup mainMenuPanel, settingsPanel, howToPlayPanel, aboutPanel;
    private CanvasGroup activePanel;

    void Start()
    {
        ShowPanel(mainMenuPanel); // Show home screen first
    }

    public void ShowPanel(CanvasGroup newPanel)
    {
        if (activePanel != null)
        {
            activePanel.DOFade(0, 0.5f).OnComplete(() =>
            {
                activePanel.gameObject.SetActive(false);
            });
        }

        newPanel.gameObject.SetActive(true);
        newPanel.DOFade(1, 0.5f);
        newPanel.interactable = true;
        newPanel.blocksRaycasts = true;

        activePanel = newPanel;
    }

    public void GoHome()
    {
        ShowPanel(mainMenuPanel);
    }
}
