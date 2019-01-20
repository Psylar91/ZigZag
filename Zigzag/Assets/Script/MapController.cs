using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public GameObject playerObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform preCube = transform.GetChild(transform.childCount - 1);

        if (Vector3.Distance(preCube.position, playerObject.transform.position) < 10.0f)
        {
            GameObject cubePrefab = Resources.Load("Prefabs/Cube") as GameObject;
            Vector3 tr;
            int randnum = Random.Range(1, 3);

            if (randnum <= 1.5f)
                tr = preCube.transform.position + new Vector3(1.0f, 0, 0);
            else
                tr = preCube.transform.position + new Vector3(0, 0, 1.0f);

            GameObject go = Instantiate(cubePrefab, tr, Quaternion.identity);
            go.transform.SetParent(transform);

        }
    }
}
