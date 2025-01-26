using UnityEngine;

public class ObstacleBlob : ObstacleEnemy
{
    [SerializeField] private float min_rotate_speed = 1.0f;
    [SerializeField] private float max_rotate_speed = 10.0f;
    [SerializeField] private float min_time = 1.0f;
    [SerializeField] private float max_time = 4.0f;
    private float rotate_timer;
    private float rotate_speed;

    public override void Start()
    {
        base.Start();
        rotate_speed = Random.Range(min_rotate_speed, max_rotate_speed) * (Random.Range(0, 2) * 2 - 1);
        rotate_timer = Random.Range(min_time, max_time);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotate_speed);
        rotate_timer -= Time.deltaTime;
        if (rotate_timer < 0.0f)
        {
            rotate_timer = Random.Range(min_time, max_time);
            rotate_speed *= -1;
        }
    }
}
