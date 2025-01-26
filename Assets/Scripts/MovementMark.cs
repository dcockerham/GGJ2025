using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovementMark : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    Rigidbody2D m_Rigidbody;
    protected SpriteRenderer m_Sprite;
    public GameObject m_AttackColliderPrefab;
    [SerializeField] private float x_speed = 15.0f;
    [SerializeField] private float y_speed = 10.0f;
    [SerializeField] private float max_speed = 20.0f;
    //[SerializeField] private float y_max_speed = 15.0f;
    [SerializeField] Direction is_facing = Direction.Left;
    [SerializeField] private float attack_offset = 0.5f;

    [SerializeField] private Sprite left_sprite;
    [SerializeField] private Sprite right_sprite;
    [SerializeField] private Sprite atk_left_sprite;
    [SerializeField] private Sprite atk_right_sprite;

    bool is_attacking = false;
    float timer_attack;
    [SerializeField] private float attack_length = 0.1f;

    //[SerializeField] private float damage_bounce_strength = 5.0f;

    float left_border;
    float right_border;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Sprite = GetComponent<SpriteRenderer>();

        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        left_border = -stageDimensions.x;
        right_border = stageDimensions.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement input
        float xInput = Input.GetAxis("Horizontal") * x_speed * Time.deltaTime;
        float yInput = /*0.1f +*/ Input.GetAxis("Vertical") * y_speed * Time.deltaTime;

        if (xInput != 0)
        {
            m_Rigidbody.AddForce(Vector2.right * xInput);
        }
        if (yInput != 0)
        {
            m_Rigidbody.AddForce(Vector2.up * yInput);
        }
        if (m_Rigidbody.linearVelocity.magnitude > max_speed)
        {
            m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * max_speed;
        }

        if (xInput > 0)
        {
            is_facing = Direction.Right;
        }
        else if (xInput < 0)
        {
            is_facing = Direction.Left;
        }
        //is_facing = (xInput >= 0) ? Direction.Right : Direction.Left;


        // Handle action input
        if (Input.GetButtonDown("Jump"))
        {
            float newXPosition = transform.position.x + attack_offset * (is_facing == Direction.Right ? 1f : -1f);
            GameObject newObject = Instantiate(m_AttackColliderPrefab, 
                    new Vector3(newXPosition, transform.position.y, transform.position.z), 
                    Quaternion.identity);
            is_attacking = true;
            timer_attack = attack_length;
            Destroy(newObject, attack_length);
        }
        if (is_attacking)
        {
            timer_attack -= Time.deltaTime;
            if (timer_attack < 0)
            {
                is_attacking = false;
            }
        }


        // Handle sprite selection
        if (!is_attacking)
        {
            if (is_facing == Direction.Left)
            {
                m_Sprite.sprite = left_sprite;
            }
            else
            {
                m_Sprite.sprite = right_sprite;
            }
        }
        else
        {
            if (is_facing == Direction.Left)
            {
                m_Sprite.sprite = atk_left_sprite;
            }
            else
            {
                m_Sprite.sprite = atk_right_sprite;
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, left_border, right_border), Mathf.Max(transform.position.y, 0.0f), transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var hazard = collision.gameObject.GetComponent<ObstacleEnemy>();
        if (hazard != null)
        {
            Debug.Log("HIT!");
            //Vector3 newDir = Vector3.MoveTowards(transform.position, hazard.transform.position, 1.0f);
            //m_Rigidbody.AddForce(newDir * -damage_bounce_strength);
            string scene_name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene_name);
        }
    }
}
