using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class StartWalkOnClick : MonoBehaviour
{
    private Animator m_Animator;
    private BoxCollider2D m_BoxCollider;
    private AudioSource m_AudioSource;
    private bool shouldWalk = false;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    public float speed = 1f;

    private void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (shouldWalk)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        m_Animator.SetBool("walking", true);
        m_AudioSource.clip = audioClips[1];
        m_AudioSource.loop = false;
        m_AudioSource.Play();
        StartCoroutine(StopWalking());
    }

    IEnumerator StopWalking()
    {
        yield return new WaitForSeconds(5);
        m_Animator.SetBool("walking", false);
    }

    private void StartMoving()
    {
        shouldWalk = true;
        m_BoxCollider.enabled = false;
        m_AudioSource.clip = audioClips[0];
        m_AudioSource.loop = true;
        m_AudioSource.Play();
    }

    public void StopMoving()
    {
        shouldWalk = false;
        m_BoxCollider.enabled = true;
        m_AudioSource.Stop();
    }

}
