using UnityEngine;

public class HomeSceneController : SceneController {

    public Transform player;

    // Use this for initialization
    public override void Start () {
        base.Start();

        if (prevScene == "5 - FarmOutdoorScene") {
            player.position = new Vector2(-5.3f, -15.7f);
            Camera.main.transform.position = new Vector3(-4.6f, -11.68f, -10f);
        }
    }

}