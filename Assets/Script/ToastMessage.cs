using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToastMessage : MonoBehaviour
{
    [Header("Toast")]
    public GameObject toast;
    public TMPro.TextMeshProUGUI toastText;
    public Animator toastAnim;

    private WaitForSeconds _UIDelay1 = new WaitForSeconds(2.0f);
    private WaitForSeconds _UIDelay2 = new WaitForSeconds(0.3f);

    private void Start()
    {
        toast.SetActive(false);
    }

    public void message(string message)
    {
        toastText.text = message;
        toast.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(ToastDelay());
    }

    IEnumerator ToastDelay()
    {
        toast.SetActive(true);
        toastAnim.SetBool("isOn", true);
        yield return _UIDelay1;
        toastAnim.SetBool("isOn", false);
        yield return _UIDelay2;
        toast.SetActive(false);
    }
}
