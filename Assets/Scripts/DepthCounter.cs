using UnityEngine;
using TMPro;

public class DepthCounter : MonoBehaviour
{
    int depth_count;
    TMP_Text m_TextComponent;
    GameObject playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        playerObject = GameObject.Find("PlayerMark");
    }

    // Update is called once per frame
    void Update()
    {
        depth_count = 100 - (int)playerObject.transform.position.y;
        m_TextComponent.text = "DEPTH: " + depth_count;
    }
}
