using UnityEngine;

public class ObstacleHoming : ObstacleEnemy
{
    [SerializeField] private float speed = 1.0f;
    //[SerializeField] private float max_speed = 2.0f;
    GameObject playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        playerObject = GameObject.Find("PlayerMark");
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, step);
    }
}
