using UnityEngine;

public class Chest :
MonoBehaviour,
IInteractable
{
    bool opened = false;

    SpriteRenderer sr;

    public GameObject[]
    fruitPrefabs;

    void Start()
    {
        sr =
        GetComponent
        <SpriteRenderer>();
    }

    public void Interact(
    GameObject interactor)
    {
        if (opened)
            return;

        opened = true;

        sr.color =
        Color.gray;

        SpawnLoot();
    }

    void SpawnLoot()
    {
        Debug.Log("Spawn Loot");
        Debug.Log(fruitPrefabs.Length);
        //Debug.DrawRay(transform.position, offset, Color.red, 2f);
        int count = 2;
      // Random.Range(1, 2);

        for (
        int i = 0;
        i < count;
        i++)
        {
            int index =
            Random.Range(
            0,
            fruitPrefabs.Length);

            Vector2 offset =
            Random.insideUnitCircle
            * 1.5f;

            Instantiate(
            fruitPrefabs[index],
            (Vector2)
            transform.position
            + offset,
            Quaternion.identity);

            //µ÷ÊÔÉú³É
            Debug.DrawRay(transform.position, offset, Color.red, 2f);
        }
    }
}