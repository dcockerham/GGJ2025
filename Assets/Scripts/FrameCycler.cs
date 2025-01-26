using UnityEngine;

public class FrameCycler : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float minLength = 1.0f;
    [SerializeField] private float maxLength = 4.0f;
    float cycleTimer;
    protected SpriteRenderer m_Sprite;
    int currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Sprite = GetComponent<SpriteRenderer>();
        if (sprites.Length != 0)
        {
            currentIndex = Random.Range(0, sprites.Length);
            m_Sprite.sprite = sprites[currentIndex];
        }
        cycleTimer = Random.Range(minLength, maxLength);

    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Length != 0)
        {
            cycleTimer -= Time.deltaTime;
            if (cycleTimer < 0.0f)
            {
                cycleTimer = Random.Range(minLength, maxLength);
                if (++currentIndex >= sprites.Length)
                {
                    currentIndex = 0;
                }
                m_Sprite.sprite = sprites[currentIndex];
            }
        }
    }
}
