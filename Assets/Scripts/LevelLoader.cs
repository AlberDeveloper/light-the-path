using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator _animator;
    private int _levelToLoad;


    public void FadeToNextLevel()
    {
        FadeToLevel(GetCurrentLevel() + 1);
    }

    public void FadeToLevel(int levelIndex) {
        _levelToLoad = levelIndex;
        _animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(_levelToLoad);
    }

    public int GetCurrentLevel() {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
