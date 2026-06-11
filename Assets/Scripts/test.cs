using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("°´ÏÂ¿Õ¸ñ¼ü");
            GetComponent<Animator>()
                .SetTrigger("T98");
        }
    }
}
