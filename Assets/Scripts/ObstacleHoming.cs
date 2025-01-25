using UnityEngine;

public class ObstacleHoming : ObstacleEnemy
{
    [SerializeField] private float speed = 1.0f;
    //[SerializeField] private float max_speed = 2.0f;
    [SerializeField] private bool is_facing_right = true;
    GameObject playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        playerObject = GameObject.Find("PlayerMark");
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move

        bool new_is_facing_right = (transform.position.x < playerObject.transform.position.x) ? true : false;

        if (new_is_facing_right != is_facing_right)
        {
            is_facing_right = !is_facing_right;
            m_Sprite.flipX = !m_Sprite.flipX;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, step);
    }
}
