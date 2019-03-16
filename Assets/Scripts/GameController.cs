using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum State
    {
        Play = 1,
        ZoomingOut = 2,
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Play;
    }

    // Update is called once per frame
    void Update()
    {
        CameraManager cm = FindObjectOfType<CameraManager>();
        WallManager wm = FindObjectOfType<WallManager>();
        Ball ball = FindObjectOfType<Ball>();

        switch (state)
        {
            case State.Play:
                if (wm.IsEnd())
                {
                    ball.StopMove();
                    cm.ZoomOut();
                    wm.Destroy();
                    state = State.ZoomingOut;
                }
                break;
            case State.ZoomingOut:
                if (!cm.IsZoomingOut())
                {
                    ball.StartMove();
                    state = State.Play;
                    wm.GenerateWall();
                }
                break;
        }
    }
}
