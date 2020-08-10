using UnityEngine;

public class BedroomSceneController : SceneController {

    public Transform player;

    // Use this for initialization
    public override void Start () {
        base.Start();

        if (prevScene == "HomeScene") {
            player.position = new Vector2(0f, -5f);
            Camera.main.transform.position = new Vector3(-3f, -3f, -10f);
        }
    }

}