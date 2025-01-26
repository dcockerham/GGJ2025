using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableTransition : MonoBehaviour
{
    [SerializeField] private string NextLevel = "";
    [SerializeField] private Transform fadeOutObject;
    private bool touched;
    [SerializeField] private float fadeOutTime = 1.0f;
    private float fadeOutTimer;
    // to destroy music object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touched = false;
        fadeOutTimer = fadeOutTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (touched == true)
        {
            fadeOutTimer -= Time.deltaTime;
            float scaleChange = 40f * Time.deltaTime / fadeOutTime;
            fadeOutObject.localScale = new Vector3(fadeOutObject.localScale.x + scaleChange, fadeOutObject.localScale.y + scaleChange, fadeOutObject.localScale.z);
            if (fadeOutTimer <= 0f)
            {
                SceneManager.LoadScene(NextLevel);
            }
        }
    }

    void OnMouseDown()
    {
        touched = true;
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
