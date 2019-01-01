using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;

    //左手のコライダー
    private Collider handCollider;
    //右足のコライダー
    private Collider footCollider;

    // Use this for initialization
    void Start()
    {
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();

        //左手のコライダーを取得
        handCollider = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
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
            handCollider.enabled = true;

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
            animator.SetBool("Land", true);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("DamageDown", true);
        }
    }

    private void ColliderReset()
    {
        handCollider.enabled = false;
        footCollider.enabled = false;
    }
}