using UnityEngine;

public class RoadToTownSceneController : SceneController {

    public Transform player;

    // Use this for initialization
    public override void Start () {
        base.Start();

        if (prevScene == "5 - FarmOutdoorScene") {
            player.position = new Vector2(-2f, -2.89f);
            Camera.main.transform.position = new Vector3(-2f, -2.89f, -10f);
        }

				if (prevScene == "7 - Town Scene") {
            player.position = new Vector2(91.47f, -2.89f);
            Camera.main.transform.position = new Vector3(91.47f, -2.89f, -10f);
        }
    }

}