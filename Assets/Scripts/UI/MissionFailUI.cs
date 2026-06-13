using UnityEngine;

public class MissionFailUI : MonoBehaviour
{
    public static MissionFailUI Instance;

    private Animator animator;
    private bool showing = false;

    private void Awake()
    {
        Instance = this;

        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        if (showing) return;
        showing = true;
        gameObject.SetActive(true);

        animator.SetTrigger("Show");
    }

    public void Hide()
    {
        showing = false;

        gameObject.SetActive(false);
    }
}