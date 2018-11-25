using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Atributos Principais do Player")]
    public float speed;
    public float jumpforce;
    public int health;
    public int key;

    [Header("Atributos diversos")]
    public bool invunerable;
    public float invencibleTime;
    private bool facingRight = true;
    private SpriteRenderer sprite;

    public float radius;
    public LayerMask layerGround;
    [SerializeField] bool onGround = false;

    private Rigidbody2D rb2d;
    public Transform groundCheck;

    private Animator anim;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.currentState != GameState.GAMEPLAY)
        {
            rb2d.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            anim.SetFloat("Speed", Mathf.Abs(0));
            return;
        }
        else
        {
            rb2d.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        MovePlayer();
        JumpPlayer();
    }

    void MovePlayer()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * speed * Time.deltaTime, rb2d.velocity.y);

        if (move > 0 && facingRight == false)
        {
            FlipPlayer();
        }
        else if (move < 0 && facingRight == true)
        {
            FlipPlayer();
        }
    }

    void JumpPlayer()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerGround);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpforce));
        }
        anim.SetBool("Pulando", !onGround);
        anim.SetFloat("velY", rb2d.velocity.y);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    public void DamagePlayer()
    {
        invunerable = true;
        health--;
        if (health > 0)
        {
            StartCoroutine(Damage());
        }

        else if (health <= 0)
        {
            health = 0;
            UIManager.instance.LoseGameUI();
        }
    }

    IEnumerator Damage()
    {
        sprite.enabled = false;
        for (float i = 0; i < invencibleTime; i += 0.1f)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        invunerable = false;
        sprite.enabled = true;
    }
}
