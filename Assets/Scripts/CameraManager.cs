using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float prevOrthographicSize;
    private float targetOrthographicSize;

    // Start is called before the first frame update
    void Start()
    {
        prevOrthographicSize = Camera.main.orthographicSize;
        targetOrthographicSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize += 0.2f;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 0.0f, targetOrthographicSize);

        Vector3 pos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(pos.x, Camera.main.orthographicSize - prevOrthographicSize, pos.z);
    }

    public void ZoomOut()
    {
        prevOrthographicSize = Camera.main.orthographicSize;
        targetOrthographicSize = Camera.main.orthographicSize * 2f;
    }

    public bool IsZoomingOut()
    {
        if (Camera.main.orthographicSize < targetOrthographicSize)
        {
            return true;
        }

        return false;
    }
}
