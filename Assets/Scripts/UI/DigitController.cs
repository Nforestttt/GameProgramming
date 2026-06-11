using UnityEngine;

public class DigitController : MonoBehaviour
{
    private Animator animator;

    private int currentDigit = -1;

    //之前是测试用的，现在不测试了
    //private void Start()
    //{
    //    Debug.Log("开始了嘛嘛嘛");
    //    animator.Play("5");
    //}

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDigit(int newDigit)
    {
        // 初始化
        if (currentDigit == -1)
        {
            animator.Play(newDigit.ToString());

            currentDigit = newDigit;
            return;
        }

        // 没变化
        if (newDigit == currentDigit)
            return;

        bool isNormalCountdown =
            (newDigit == currentDigit - 1);

        bool isWrapAround =
            (currentDigit == 0 && newDigit == 9);

        // 能播放倒计时动画
        if (isNormalCountdown || isWrapAround)
        {
            string trigger =
                $"T{currentDigit}{newDigit}";

            animator.SetTrigger(trigger);
        }
        else
        {
            // 例如：
            // 0→5
            // 0→4
            // 3→9
            Debug.Log($"Direct Jump: {currentDigit} -> {newDigit}");
            animator.Play(newDigit.ToString());
        }

        currentDigit = newDigit;
    }
}