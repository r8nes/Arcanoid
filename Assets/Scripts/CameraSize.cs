using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float SizeX = 2340.0f;
    private const float SizeY = 1080.0f;

    private float _targetSizeX = 0f;
    private float _targetSizeY = 0f;

    private const float HalfSize = 200f;

    [SerializeField] private bool _isHorizontal = true;
    private void Awake()
    {
            _targetSizeX = _isHorizontal ? SizeX : SizeY;
            _targetSizeY = _isHorizontal ? SizeY : SizeX;

            CameraResize();
    }
    private void CameraResize() {
        float screenRatio = (float)Screen.height / (float)Screen.width;
        float targetRatio = _targetSizeY / _targetSizeX;

        if (screenRatio>=targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 0.955f)
    {
        Camera.main.orthographicSize = _targetSizeY /( HalfSize*differentSize);
    }
}
