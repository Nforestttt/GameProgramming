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

    public AudioClip portalSound;

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
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        AudioManager.Instance.PlaySFX(portalSound);

        yield return new WaitForSeconds(0.3f);

        SceneTransitionManager.Instance.targetSpawnPoint =
            destinationSpawnPoint;

        SceneTransitionManager.Instance.LoadLocation(destination);
    }
}
