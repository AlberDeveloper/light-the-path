using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    private Text _hint;
    private void Start()
    {
        _hint = transform.GetComponentInChildren<Text>();
        hideHint();
    }

    public void showHint() {
        _hint.enabled = true;
    }

    public void hideHint()
    {
        _hint.enabled = false;
    }
}
