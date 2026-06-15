using UnityEngine;

public class Chest :
MonoBehaviour,
IInteractable
{
    bool opened = false;

    SpriteRenderer sr;

    [Header("Loot Settings")]
    public GameObject[] fruitPrefabs;

    [Min(1)]
    public int fruitCount = 2;

    [Min(0f)]
    public float spawnRadius = 1.5f;

    [Header("Spawn Check")]
    public LayerMask obstacleLayer;

    public int maxAttempts = 20;

    [Header("Audio")]
    public AudioClip chestOpenSound;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact(GameObject interactor)
    {
        if (opened)
            return;

        opened = true;

        AudioManager.Instance.PlaySFX(chestOpenSound);

        sr.color = Color.gray;

        SpawnLoot();
    }

    void SpawnLoot()
    {
        Debug.Log($"Spawn {fruitCount} fruits");

        for (int i = 0; i < fruitCount; i++)
        {
            SpawnSingleFruit();
        }
    }

    void SpawnSingleFruit()
    {
        for (int attempt = 0;
             attempt < maxAttempts;
             attempt++)
        {
            Vector2 offset =
                Random.insideUnitCircle *
                spawnRadius;

            Vector2 spawnPos =
                (Vector2)transform.position
                + offset;

            Collider2D hit =
                Physics2D.OverlapCircle(
                    spawnPos,
                    0.2f,
                    obstacleLayer
                );

            if (hit != null)
            {
                continue;
            }

            int index =
                Random.Range(
                    0,
                    fruitPrefabs.Length
                );

            Instantiate(
                fruitPrefabs[index],
                spawnPos,
                Quaternion.identity
            );

            return;
        }

        Debug.LogWarning(
            "No valid loot position found!"
        );
    }
}