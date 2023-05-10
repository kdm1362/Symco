using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    [SerializeField]
    public GameObject cat;

    private class Pi
    {
        public float rate;
        public Color color;
        public Pi(float rate, Color color)
        {
            this.rate = rate;
            this.color = color;
        }
    }

    private List<Pi> pis;
    public DrawGraph()
    {
        pis = new List<Pi>();
    }

    public void addCat(float rate, Color color)
    {
        // 새 항목을 추가하면서 100%가 넘어가는지 확인
        float amount = 0.0f;
        foreach (Pi pi in pis)
        {
            amount += pi.rate;
        }
        if (amount + rate > 1.01f)
        {
            SymcoManager.symcoDebugError("Pi Graph is overflowing");
            return;
        }

        pis.Add(new Pi(rate, color));
        draw();
        return;
    }

    private void draw()
    {
        // update에 넣지 말 것
        erease();

        float acc = 0.0f;
        foreach(var item in pis.Select((pi, index) => (pi, index)))
        {
            GameObject catInstance = Instantiate(cat);
            catInstance.transform.parent = this.transform;
            catInstance.transform.localScale = new Vector3(1, 1, 1);
            catInstance.transform.localPosition = new Vector3(0, 0, 0);
            // 구분
            catInstance.name = "CAT" + item.index;
            // 보이게 돌리기
            catInstance.transform.localRotation = Quaternion.Euler(0, 0, -(acc * 360));
            Cat catComponent = catInstance.GetComponent<Cat>();
            catComponent.setCircleColor(item.pi.color);
            catComponent.setRate(item.pi.rate);
            // 보이게 돌리는 각도 수정
            acc += item.pi.rate;
        }
        return;
    }

    private void erease()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("pigraphcat"))
        {
            // 이미 그려진 그래프 지우기
            Destroy(item);
        }
    }

    public void clearCat()
    {
        pis = new List<Pi>();
        erease();
    }

}
