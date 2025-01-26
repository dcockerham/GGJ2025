using UnityEngine;

public class ObstacleEnemy : MonoBehaviour
{
    [SerializeField] private bool is_killable = true;
    protected Rigidbody2D m_Rigidbody;
    protected SpriteRenderer m_Sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Sprite = GetComponent<SpriteRenderer>();
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (is_killable)
        {
            Destroy(gameObject);
        }
    }
}
