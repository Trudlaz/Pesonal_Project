using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    [Header("움직이는 플랫폼 기본 데이터")]
    public Transform startPos;
    public Transform endPos;

    public Transform desPos;

    public float moveSpeed;


    private void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * moveSpeed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
