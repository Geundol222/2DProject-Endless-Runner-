using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngineInternal;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private GameObject scroller;
    [SerializeField] private Button skill;
    [SerializeField] private AudioSource running;

    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D cc;

    public UnityEvent OnJumped;
    public UnityEvent OnDied;

    private void Awake()
    {
        running = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        animator.SetFloat("RunSpeed", 1);
    }

    private void OnEnable()
    {
        StartCoroutine(ScoreCount());
    }

    public void Jump()
    {
        if (!animator.GetBool("IsJump"))
        {
            running.Pause();
            rb.velocity = Vector2.up * jumpPower;
            animator.SetBool("IsJump", true);
            animator.SetBool("IsLanding", false);
            OnJumped?.Invoke();
        }
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }

    private Coroutine skillRoutine;
    private Coroutine skillCool;

    IEnumerator SkillRoutine()
    {
        skill.gameObject.SetActive(false);
        animator.SetBool("IsSkill", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("IsSkill", false);
        rb.simulated = true;
        cc.isTrigger = false;

        skillCool = StartCoroutine(SkillCoolTime());
    }

    IEnumerator SkillCoolTime()
    {
        yield return new WaitForSeconds(5f);
        skill.gameObject.SetActive(true);
    }

    public void Skill()
    {
        running.Pause();
        rb.simulated = false;
        cc.isTrigger = true;
        skillRoutine = StartCoroutine(SkillRoutine());
    }

    private void OnSkill(InputValue value)
    {
        Skill();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            running.Play();
            animator.SetBool("IsJump", false);
            animator.SetBool("IsLanding", true);
        }
        else
        {
            Time.timeScale = 0;
            OnDied?.Invoke();
        }
    }

    IEnumerator ScoreCount()
    {
        while (true)
        {
            GameManager.Data.CurScore++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(ScoreCount());
    }
}
