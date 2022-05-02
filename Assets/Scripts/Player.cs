using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    //TEACHER MOVEMENT
    [SerializeField]
    private float moveSpeed = 2f;

    public delegate void goalReached();
    public static event goalReached goalachieved;
    //private square squarePrefab;

    public bool loboEsta = false;

    //public Vector2 GetPosition => transform.position;

    private void Move(int x, int y)
    {
        Vector3 asd = new Vector3(x,y,0);
        Vector3 sum = transform.position + asd;

        square next = frame.GetFrameObject((int)sum.x, (int)sum.y);

            if (next.canwalk)
            {
                sum = new Vector3((int)sum.x, (int)sum.y, 0);
                Debug.Log(sum);
                Debug.Log(transform.position);
                transform.position = Vector2.MoveTowards(transform.position, sum, moveSpeed * Time.deltaTime);
            }


            //sum = new Vector3((int)sum.x,(int)sum.y, 0);
            //Debug.Log(sum);
            //Debug.Log(transform.position);
            //transform.position = Vector2.MoveTowards(transform.position, sum, moveSpeed * Time.deltaTime);
    }

    //TEACHER MOVEMENT



    private BoxCollider2D playerb;
    private bool cblock = false;
    public float speed = 10f;
    public bool _collisionblock = false;

    private square[,] frameArray;

    public Animator playeranim;
    private Vector3 moved;
    private Frame frame;


    public int tam;
    public int obst;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        playerb = this.GetComponent<BoxCollider2D>();
        frameArray = new square[1, 1];

    }

    public void setFrame(Frame frame)
    {
        this.frame = frame;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moved = new Vector3(x, y, 0);

        if (moved.x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (moved.x < 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        //square next = frame.GetFrameObject((int)x, (int)y);
        //Debug.Log("ASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASDASD");
        //Debug.Log(next.x);
        //Debug.Log(next.y);


        //if (next.canwalk)
        //{
        Move((int)x, (int)y);
        //}


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("Retry");

        }
        if (collision.gameObject.tag == "goal")
        {

            if (PlayerPrefs.GetInt("levelP") >= 2)
            {
                PlayerPrefs.SetInt("levelP", 1);
                SceneManager.LoadScene("Win");
            }
            else
            {
                PlayerPrefs.SetInt("levelP", PlayerPrefs.GetInt("levelP") + 1);
                SceneManager.LoadScene("SampleScene");
            }
        }
    }




}
