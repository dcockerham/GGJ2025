using UnityEngine;

public class MovementPlasticBall : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float max_speed = 25.0f;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	m_Rigidbody = GetComponent<Rigidbody2D>();    
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

	/*if (Input.GetKey("d")) 
	{
		m_Rigidbody.AddForce(Vector2.right * speed);	
	}
	if (Input.GetKey("a"))
	{
		m_Rigidbody.AddForce(Vector2.left * speed);
	}*/
    }
}
