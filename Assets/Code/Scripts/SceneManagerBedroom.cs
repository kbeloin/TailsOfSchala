using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBedroom : MonoBehaviour {

    public Transform player;
		private Animator animator;
    private GameManager gm;

    // Use this for initialization
    public void Start () {

        // Get the GameManager so that we can access its variables
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (gm.prevScene == "LivingRoom") {
            player.position = new Vector2(-2.5f, -2.5f);
						animator.Play("Base Layer.idleUp");
            Camera.main.transform.position = new Vector3(-3f, -3f, -10f);
        }
    }

}
