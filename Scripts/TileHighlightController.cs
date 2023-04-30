using UnityEngine;

public class TileHighlightController : MonoBehaviour
{
    public Material defaultMaterial;
    public Material highlightedMaterial;

    private GameObject player;
    private Renderer tileRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tileRenderer = GetComponent<Renderer>();
        tileRenderer.material = defaultMaterial;
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 tilePosition = transform.position;

        float distanceX = Mathf.Abs(playerPosition.x - tilePosition.x);
        float distanceY = Mathf.Abs(playerPosition.y - tilePosition.y);

        bool isHorizontal = (distanceX <= 1.5f && distanceY <= 0.5f);
        bool isUpper = (distanceX <= 0.1f && distanceY <= 1.3f && playerPosition.y < tilePosition.y);
        bool isLower = (distanceX <= 0.1f && distanceY <= 1.3f && playerPosition.y > tilePosition.y);

        if (isHorizontal || isUpper || isLower)
        {
            tileRenderer.material = highlightedMaterial;
        }
        else
        {
            tileRenderer.material = defaultMaterial;
        }
    }
}
