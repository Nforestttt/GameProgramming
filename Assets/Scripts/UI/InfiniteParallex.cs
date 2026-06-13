using UnityEngine;
using UnityEngine.UI;

public class InfiniteParallax : MonoBehaviour
{
    public float speed = 50f;

    private RectTransform imageA;
    private RectTransform imageB;

    private float width;

    void Start()
    {
        imageA = transform.GetChild(0).GetComponent<RectTransform>();
        imageB = transform.GetChild(1).GetComponent<RectTransform>();

        width = imageA.rect.width;
    }

    void Update()
    {
        MoveImage(imageA);
        MoveImage(imageB);
    }

    void MoveImage(RectTransform image)
    {
        image.anchoredPosition +=
            Vector2.left * speed * Time.deltaTime;

        if (image.anchoredPosition.x <= -width)
        {
            RectTransform other =
                image == imageA ? imageB : imageA;

            image.anchoredPosition =
                new Vector2(
                    other.anchoredPosition.x + width,
                    image.anchoredPosition.y
                );
        }
    }
}