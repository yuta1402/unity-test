using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject topWall;
    public GameObject sideWall;

    public float WallSize = 0.25f;

    public List<GameObject> walls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateWall();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateWall()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        GameObject top = Instantiate(topWall, transform.position, transform.rotation);
        top.transform.localScale = new Vector3(width, WallSize, 1.0f);
        top.transform.position = new Vector3(0f, height/2 - WallSize/2, 1.0f) + cam.transform.position;

        GameObject left = Instantiate(sideWall, transform.position, sideWall.transform.rotation);
        left.transform.localScale = new Vector3(height, WallSize, 1.0f);
        left.transform.position = new Vector3(-width/2 + WallSize/2, 0f, 1.0f) + cam.transform.position;

        GameObject right = Instantiate(sideWall, transform.position, sideWall.transform.rotation);
        right.transform.localScale = new Vector3(height, WallSize, 1.0f);
        right.transform.position = new Vector3(+width/2 - WallSize/2, 0f, 1.0f) + cam.transform.position;

        walls.Add(top);
        walls.Add(left);
        walls.Add(right);
    }

    public bool IsEnd()
    {
        if (right.GetComponent<Wall>().isEnd)
        {
            return true;
        }

        return false;
    }

    public void Destroy()
    {
        Destroy(top);
        Destroy(left);
        Destroy(right);
    }
}
