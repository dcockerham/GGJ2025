using UnityEngine;

public class MovementPlasticBall : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    private float speed = 1f;
    private float max_speed = 1f;

    // speed control variables to change between crowd, air, and ground speed
    [SerializeField] private float crowd_max_speed = 10.0f;
    [SerializeField] private float crowd_speed = 5.0f;
    [SerializeField] private float crowd_damping = 5.0f;

    [SerializeField] private float ground_max_speed = 25.0f;
    [SerializeField] private float ground_speed = 20.0f;
    [SerializeField] private float ground_damping = 1.0f;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	m_Rigidbody = GetComponent<Rigidbody2D>();
	speed = ground_speed;
	max_speed = ground_max_speed;
	m_Rigidbody.linearDamping = ground_damping;
    }

    // Update is called once per frame
    void Update()
    {
	float moveInput = Input.GetAxis("Horizontal") * speed;

	if (moveInput != 0)
	{
		m_Rigidbody.AddForce(Vector2.right * moveInput);
	}

	if (m_Rigidbody.linearVelocity.magnitude > max_speed)
	{
		m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * max_speed;
	}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.tag == "Crowd")
	    {
		    speed = crowd_speed;
		    max_speed = crowd_max_speed;
		    m_Rigidbody.linearDamping = crowd_damping;
	    }
    }

    void OnTriggerExit2D(Collider2D other)
    {
	    if (other.gameObject.tag == "Crowd")
	    {
		    speed = ground_speed;
		    max_speed = ground_max_speed;
		    m_Rigidbody.linearDamping = ground_damping;
	    }
    }

}
