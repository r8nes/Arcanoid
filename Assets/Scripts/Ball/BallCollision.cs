using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private float _lastPositionX;
    [SerializeField] private BallMove _ball;
    [SerializeField] private BallSound _ballSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ballSound.PlaySoundCollision();
        float ballPositionX = transform.position.x;

        if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
        {
            if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1)
            {
                float collisionPointX = collision.contacts[0].point.x;
                float playerCenterPosition = playerMove.gameObject.transform.position.x;
                float difference = playerCenterPosition - collisionPointX;
                float direction = collisionPointX < playerCenterPosition ? -1 : 1;
                _ball.AddForce(direction * Mathf.Abs(difference));
            }
        }
        _lastPositionX = ballPositionX;

        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.ApplyDamage();
        }

        if (collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
        {
            blockComposite.ApplyDamage(collision.contacts[0].point);
        }
    }
}
