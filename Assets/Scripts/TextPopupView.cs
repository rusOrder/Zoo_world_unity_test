using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopupView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _lifeTime = 1f;

    public void Show(string text, Vector3 position)
    {
        _text.text = text;
        transform.position = position + Vector3.up;
        gameObject.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}
