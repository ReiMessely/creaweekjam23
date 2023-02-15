using UnityEngine;
using UnityEngine.UI;

public class UI_Info : MonoBehaviour
{
    public GameObject infoPanel;

    private bool infoPanelActive = false;

    private void Start()
    {
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        if (infoPanelActive && Input.GetMouseButtonDown(0))
        {
            infoPanel.SetActive(false);
            infoPanelActive = false;
            Time.timeScale = 1;
        }
    }

    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanelActive);
        infoPanelActive = !infoPanelActive;
        Time.timeScale = infoPanelActive ? 0 : 1;
    }
}
