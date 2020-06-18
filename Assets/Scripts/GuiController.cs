using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    private PlayerController _playerController;
    private Text _lightedText;
    private Text _totalText;
    private Text _level;
    
    private void Start()
    {
        _lightedText = GameObject.Find("Lighted").GetComponent<Text>();
        _totalText = GameObject.Find("Total").GetComponent<Text>();
        _level = GameObject.Find("Level").GetComponent<Text>();
        _playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();

    }

    private void OnGUI()
    {
        _lightedText.text = _playerController.GetTorchedLighted().ToString();
        _totalText.text = _playerController.getTorchesToLightToOpenDoor().ToString();
        _level.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }
}