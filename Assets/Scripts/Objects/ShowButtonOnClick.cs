using UnityEngine;

public class ShowButtonOnClick : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject;

    private void OnMouseDown()
    {
        m_gameObject.SetActive(!m_gameObject.activeSelf);
    }
}
