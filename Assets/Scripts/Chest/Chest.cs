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

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact(
    GameObject interactor)
    {
        if (opened)
            return;

        opened = true;

        sr.color = Color.gray;

        SpawnLoot();
    }

    void SpawnLoot()
    {
        Debug.Log(
        $"Spawn {fruitCount} fruits");

        for (
        int i = 0;
        i < fruitCount;
        i++)
        {
            int index =
            Random.Range(
            0,
            fruitPrefabs.Length);

            Vector2 offset =
            Random.insideUnitCircle
            * spawnRadius;

            Instantiate(
            fruitPrefabs[index],
            (Vector2)
            transform.position
            + offset,
            Quaternion.identity);

            Debug.DrawRay(
            transform.position,
            offset,
            Color.red,
            2f);
        }
    }
}