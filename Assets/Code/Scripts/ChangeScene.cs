using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string toScene;
    public Vector2 toPosition;
    public Vector3 toCameraPosition;
    public Vector2 toDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(toScene, toPosition, toCameraPosition, toDirection);
        }
    }
}