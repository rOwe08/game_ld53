using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 targetPosition;
    public bool isMoving = false;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public DialogController dialogController;

    private string firstWinningMessage = "WIN";

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogController.isClosed)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && (hit.collider.CompareTag("WalkableField") || hit.collider.CompareTag("Goal")))
            {
                Vector3 tileSize = hit.collider.bounds.size;
                float tileSizeX = tileSize.x;

                float distance = Vector3.Distance(transform.position, hit.collider.transform.position);

                // Check if the movement is vertical or horizontal only
                float distanceX = Mathf.Abs(transform.position.x - hit.collider.transform.position.x);
                float distanceY = Mathf.Abs(transform.position.y - hit.collider.transform.position.y);

                if (((Mathf.Approximately(distanceX, tileSizeX) || distanceX <= tileSizeX + 0.5f) && distanceY <= 0.3f) ||
                    ((Mathf.Approximately(distanceY, tileSizeX) || distanceY <= tileSizeX + 0.5f) && distanceX <= 0.3f))
                {
                    Vector3 characterSize = GetComponent<CapsuleCollider2D>().bounds.size;
                    Vector3 adjustedPosition = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y + tileSize.y / 2 + characterSize.y / 2 - 0.2f,
                        hit.collider.transform.position.z
                    );

                    targetPosition = adjustedPosition;
                    isMoving = true;
                    animator.SetBool("IsMoving", true);
                }

                if (hit.collider.CompareTag("Goal"))
                {
                    dialogController.ShowDialog(firstWinningMessage);
                }
            }
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position.x < targetPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x > targetPosition.x)
        {
            spriteRenderer.flipX = true;
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            isMoving = false;
            animator.SetBool("IsMoving", false);
        }
    }
}
