using UnityEngine;
using TMPro;

public class BlinkText : MonoBehaviour
{
    private TMP_Text textComponent;

    public float blinkSpeed = 2f;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        Color color = textComponent.color;

        color.a =
            Mathf.PingPong(
                Time.time * blinkSpeed,
                1f
            );

        textComponent.color = color;
    }
}