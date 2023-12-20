using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapController : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right,
    }

    public Transform playerTF;
    public GameObject startingPoint;
    private GameObject cubePrefab;
    private List<Transform> cubeList;

    public const float boundary = 3f;
    private const float nextCubeDistance = 15f;
    private const float pastCubeDistance = 10f;

    void Start()
    {
        cubePrefab = Resources.Load("Prefabs/Cube") as GameObject;
        cubeList = new List<Transform>(50)
        {
            transform.GetChild(transform.childCount - 1)
        };
        InitializeMap();
    }

    void Update()
    {
        if (IsNextCubeNeeded())
        {
            MakeNextCube();
        }
        CheckPassedCube();
    }

    private void InitializeMap()
    {
        for (int i = 0; i < 30; ++i)
        {
            MakeNextCube();
        }
    }

    private bool IsNextCubeNeeded()
    {
        Transform lastCube = cubeList[^1];
        return Vector3.Distance(lastCube.position, playerTF.position) < nextCubeDistance;
    }

    private void MakeNextCube()
    {
        Direction direction = (Direction)Random.Range(0, 2);
        Vector3 lastCubePosition = cubeList[^1].position;

        Vector3 nextPosition = lastCubePosition;
        if(direction == Direction.Right)
        {
            nextPosition += Vector3.right;
        }
        else
        {
            nextPosition += Vector3.forward;
        }

        float centerValue = (nextPosition.x + nextPosition.z) / 2f;
        Vector3 centerPosition = new Vector3(centerValue, nextPosition.y, centerValue);

        bool isFarFromCenter = Vector3.Distance(centerPosition, nextPosition) > boundary;
        Direction cubeLocation = nextPosition.x > nextPosition.z ? Direction.Right : Direction.Left;

        if (isFarFromCenter)
        {
            if(cubeLocation == Direction.Right)
            {
                nextPosition = lastCubePosition + Vector3.forward;
            }
            else
            {
                nextPosition = lastCubePosition + Vector3.right;
            }
        }

        GameObject go = Instantiate(cubePrefab, nextPosition, Quaternion.identity);
        cubeList.Add(go.transform);
    }

    private void CheckPassedCube()
    {
        Transform firstCube = cubeList[0];
        if (Vector3.Distance(firstCube.position, playerTF.position) > pastCubeDistance)
        {
            cubeList.RemoveAt(0);
            Destroy(firstCube.gameObject);
        }
    }
}
