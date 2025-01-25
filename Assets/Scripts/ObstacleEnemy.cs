using UnityEngine;

public class ObstacleEnemy : MonoBehaviour
{
    protected Rigidbody2D m_Rigidbody;
    protected SpriteRenderer m_Sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
