using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private bool isMoving = false;
    private Vector3 targetPosition;


    private void Start()
    {
        speedPlayer = 0.2f;
    }
    void Update()
    {
        if (Input.touchCount > 0 && !isMoving)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    targetPosition = hit.point;
                    MovePlayer(targetPosition);
                }
            }
        }
    }

    void MovePlayer(Vector3 destination)
    {
        isMoving = true;
        StartCoroutine(MoveCoroutine(destination));
    }

    IEnumerator MoveCoroutine(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speedPlayer);
            yield return null;
        }
        isMoving = false;
    }
}