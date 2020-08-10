using UnityEngine;

public class HomeSceneController : SceneController {

    public Transform player;

    // Use this for initialization
    public override void Start () {
        base.Start();

				Debug.Log(prevScene);

        if (prevScene == "FarmOutdoorScene") {
            player.position = new Vector2(0f, 3f);
            Camera.main.transform.position = new Vector3(0f, 3f, -10f);
        }
    }

}