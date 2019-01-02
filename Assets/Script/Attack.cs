using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;

    //左手のコライダー
    private Collider LhandCollider;
    //右手のコライダー
    private Collider RhandCollider;
    //右足のコライダー
    private Collider footCollider;

    // Use this for initialization
    void Start()
    {
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();

        //左手のコライダーを取得
        LhandCollider = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
        //右手のコライダーを取得
        RhandCollider = GameObject.Find("Character1_RightHand").GetComponent<SphereCollider>();
        //右足のコライダーを取得
        footCollider = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {

        //Aを押すとjab
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Jab", true);

            //左手コライダーをオンにする
            LhandCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);
        }

        //Sを押すとHikick
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Hikick", true);
            //右足コライダーをオンにする
            footCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }

        //Dを押すとSpinkick
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Spinkick", true);
            //右足コライダーをオンにする
            footCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EarthWari();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("DamageDown", true);
        }
    }

    public void OnPressedMegaPunchButton()
    {
        EarthWari();
    }

    public void EarthWari()
    {
        animator.SetBool("Land", true);
        //右手コライダーをオンにする
        RhandCollider.enabled = true;

        //一定時間後にコライダーの機能をオフにする
        Invoke("ColliderReset", 0.3f);
    }

    private void ColliderReset()
    {
        LhandCollider.enabled = false;
        RhandCollider.enabled = false;
        footCollider.enabled = false;
    }
}