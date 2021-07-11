using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Screen = null;
    [SerializeField] Canvas _canvas;
    private void Awake()
    {
        if (Screen == null)
        {
            Screen = this;
            DontDestroyOnLoad(gameObject);
            _canvas.enabled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Enable(bool value)
    {
        if (value)
        {
            _canvas.enabled = value;
        }
        else
        {
            Invoke(nameof(Disable), 1f);
        }
    }

    public void Disable()
    {
        _canvas.enabled = false;
    }
}
