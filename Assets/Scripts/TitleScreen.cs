using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private string nextScene = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            SceneManager.LoadScene(nextScene);
    }
}
