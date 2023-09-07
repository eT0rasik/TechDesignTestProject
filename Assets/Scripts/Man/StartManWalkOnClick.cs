using System.Collections;
using UnityEngine;

public class StartManWalkOnClick : MonoBehaviour
{
    private Animator m_Animator;
    private bool shouldWalk = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (shouldWalk)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        m_Animator.SetBool("walking", true);
        StartCoroutine(StopWalking());
    }

    IEnumerator StopWalking()
    {
        yield return new WaitForSeconds(4);
        m_Animator.SetBool("walking", false);
    }

    private void StartMoving()
    {
        shouldWalk = true;
    }

    public void StopMoving()
    {
        shouldWalk = false;
    }

}
