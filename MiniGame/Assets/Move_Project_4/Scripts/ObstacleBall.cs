using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBall : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rigid;
    private bool isReverse;
    private float speed;
    private Move4GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
        rigid = GetComponent<Rigidbody2D>();
        speed = Random.Range(0f, 4f);
        gameManager = GameObject.Find("GameManager").GetComponent<Move4GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(this.transform.position.y - target.transform.position.y, this.transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (isReverse == true)
        {
            rigid.AddForce(transform.up * 0.5f, ForceMode2D.Impulse);
        } else
        {
            rigid.AddForce(-transform.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Umb")
        {
            isReverse = true;
            gameManager.ballCount += 1;
        } else if (collision.gameObject.tag == "Player")
        {
            gameManager.ballCount -= 1;
            Destroy(this.gameObject);
        }
    }
}
