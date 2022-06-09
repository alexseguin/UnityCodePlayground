using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSetup : MonoBehaviour
{

    [SerializeField]
    private HatPool pool;
    
    [SerializeField]
    private GameObject hatPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pool.hats.Count; i++)
        {
            hatPrefab.GetComponent<ShopHat>().hat = pool.hats[i];
            GameObject hatObject = Instantiate(hatPrefab, transform);
            hatObject.transform.position += new Vector3 (200 * i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
