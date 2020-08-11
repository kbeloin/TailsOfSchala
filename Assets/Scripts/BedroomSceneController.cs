using UnityEngine;

public class BedroomSceneController : SceneController {

    public Transform player;
		//private Animator animator;

    // Use this for initialization
    public override void Start () {
        base.Start();

        if (prevScene == "4 - HomeScene") {
            player.position = new Vector2(-2.5f, -2.5f);
						//animator.Play("Base Layer.idleUp");
            Camera.main.transform.position = new Vector3(-3f, -3f, -10f);
        }
    }

}