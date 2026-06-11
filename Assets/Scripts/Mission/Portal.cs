using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //传送门获取，并进行触发
    public GameLocation destination;

    public string destinationSpawnPoint;

    //传送门是否被触发
    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = false;
    }

    private void Update()
    {
        if (!playerInside)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //这里后面直接替换，到了这个门就触发提示框，然后按E就打开，点击yes 就可以输出
            SceneTransitionManager.Instance.targetSpawnPoint =
                destinationSpawnPoint;

            SceneTransitionManager.Instance.LoadLocation(
                destination);
        }
    }
}
