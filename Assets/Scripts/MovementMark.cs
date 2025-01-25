using UnityEngine;
using System.Collections;

public class MovementMark : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    Rigidbody2D m_Rigidbody;
    public GameObject m_AttackColliderPrefab;
    [SerializeField] private float x_speed = 15.0f;
    [SerializeField] private float y_speed = 10.0f;
    [SerializeField] private float max_speed = 20.0f;
    //[SerializeField] private float y_max_speed = 15.0f;
    [SerializeField] Direction is_facing = Direction.Left;
    [SerializeField] private float attack_offset = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //m_AttackCollider = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement input
        float xInput = Input.GetAxis("Horizontal") * x_speed;
        float yInput = Input.GetAxis("Vertical") * y_speed;

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

        is_facing = (m_Rigidbody.linearVelocity.x >= 0) ? Direction.Right : Direction.Left;


        // Handle action input
        if (Input.GetButtonDown("Jump"))
        {
            float newXPosition = transform.position.x + attack_offset * (is_facing == Direction.Right ? 1f : -1f);
            GameObject newObject = Instantiate(m_AttackColliderPrefab, 
                    new Vector3(newXPosition, transform.position.y, transform.position.z), 
                    Quaternion.identity);
            Destroy(newObject, 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var hazard = collision.gameObject.GetComponent<ObstacleEnemy>();
        if (hazard != null)
        {
            Debug.Log("HIT!");
        }
    }
}
