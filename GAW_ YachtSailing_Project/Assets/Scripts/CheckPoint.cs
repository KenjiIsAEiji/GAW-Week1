using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform UIBord;
    [SerializeField] Text DistanceTxt;
    [SerializeField] Transform CamTrasform;
    [SerializeField] Transform boat;

    Vector3 baseScale;

    // Start is called before the first frame update
    void Start()
    {
        baseScale = UIBord.localScale / GetDistace();
    }

    // Update is called once per frame
    void Update()
    {
        float boatDistace = (UIBord.position - boat.position).magnitude;
        DistanceTxt.text = boatDistace.ToString("00.00") + "m";

        if(boatDistace <= 3.0f)
        {
            GameManager.Instance.checkPoints.Remove(this);
            GameManager.Instance.NextPoint();
            this.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        transform.localScale = baseScale * GetDistace();
        transform.LookAt(transform.position + CamTrasform.forward);
    }

    float GetDistace()
    {
        return (UIBord.transform.position - CamTrasform.transform.position).magnitude;
    }
}
