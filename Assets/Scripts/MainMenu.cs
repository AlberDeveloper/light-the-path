using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public LevelLoader _levelLoader;
    private GameObject _selectedObj;

    public void Start()
    {
        _selectedObj = EventSystem.current.currentSelectedGameObject;
    }

    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(_selectedObj);

        _selectedObj = EventSystem.current.currentSelectedGameObject;
    }

    public void StartGame()
    {
        _levelLoader.FadeToNextLevel();
    }

    public void SelectActiveButton(GameObject transform) {
        EventSystem.current.SetSelectedGameObject(transform);
    }
}
