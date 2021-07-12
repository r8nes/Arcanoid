using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private float _moveX = 0f;
    private float _halfOfSpriteSizeX = 0f;
    private const float BorderPosition = 5f;


    [SerializeField] private float _speed = 5f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _halfOfSpriteSizeX = _spriteRenderer.size.x / 2;
    }

    private void FixedUpdate()
    {
        float positionX = _rb.position.x + _moveX*_speed*Time.fixedDeltaTime;
        positionX = Mathf.Clamp(positionX, (-BorderPosition + _halfOfSpriteSizeX),( BorderPosition - _halfOfSpriteSizeX));
        _rb.MovePosition(new Vector2(positionX, _rb.position.y));
    }
    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;     
    }

    private void Move(float moveX) {
        _moveX = moveX;
        Debug.Log(_moveX);
    }

    public void ResetPosition() 
    {
        _rb.position = new Vector2(0f, _rb.position.y);
    }
}
