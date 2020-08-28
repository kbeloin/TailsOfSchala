using UnityEngine;

public class FarmOutdoorSceneController : SceneController {

    public Transform player;

    // Use this for initialization
    public override void Start () {
        base.Start();

        if (prevScene == "4 - HomeScene") {
            player.position = new Vector2(-8.8f, 15.4f);
            Camera.main.transform.position = new Vector3(-8.8f, 15.4f, -10f);
        }

				if (prevScene == "6 - Road to Town") {
            player.position = new Vector2(38f, -43f);
            Camera.main.transform.position = new Vector3(38f, -43f, -10f);
        }
    }

}