using UnityEngine;

public class ObstacleMoving : ObstacleEnemy
{
    [SerializeField] private float x_speed = 1.0f;
    [SerializeField] private float x_max_speed = 5.0f;
    //[SerializeField] private float y_speed = 0f;
    //[SerializeField] private float y_max_speed = 0f;
    [SerializeField] private float time_before_turning = 2f;
    [SerializeField] private bool is_facing_right = true;
    private float turning_timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        turning_timer = time_before_turning;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.AddForce(Vector2.right * x_speed * (is_facing_right ? 1 : -1));
        if (m_Rigidbody.linearVelocity.magnitude > x_max_speed)
        {
            m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * x_max_speed;
        }

        //m_Rigidbody.AddForce(Vector2.up * y_speed);
        //if (m_Rigidbody.linearVelocityY > y_max_speed)
        //{
        //    m_Rigidbody.linearVelocityY = m_Rigidbody.linearVelocityY * y_max_speed;
        //}

        turning_timer -= Time.deltaTime;
        if (turning_timer < 0f)
        {
            turning_timer = time_before_turning;
            is_facing_right = !is_facing_right;
            m_Sprite.flipX = !m_Sprite.flipX;
        }
    }
}
