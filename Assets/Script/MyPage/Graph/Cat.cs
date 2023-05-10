using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image circle;
    [SerializeField]
    private GameObject sep0;
    [SerializeField]
    private GameObject sep1;

    public void setSepThick(float thk)
    {
        sep0.transform.localScale = new Vector3(thk, 0.5f, 1.0f);
        sep1.transform.localScale = new Vector3(thk, 0.5f, 1.0f);
    }

    public void setSepColor(Color color)
    {
        sep0.GetComponent<UnityEngine.UI.Image>().color = color;
        sep1.GetComponent<UnityEngine.UI.Image>().color = color;
    }

    public void setCircleColor(Color color)
    {
        circle.color = color;
    }

    public void setRate(float rate)
    {
        circle.fillAmount = rate;
        float rot;
        rot = -1f * rate * 360.0f;
        sep1.transform.localRotation = Quaternion.Euler(0, 0, rot);
    }
}
