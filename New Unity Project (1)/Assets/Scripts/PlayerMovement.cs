﻿using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController2D Controller;
        public Animator Animator;


        float horizontalMove = 0f;
        public float runSpeed = 40f;
        public bool Jump = false;
        public bool crouch = false;
        public AudioSource jumpSound;

        // Update is called once per frame
        void Update()
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jumpSound.Play();
                Jump = true;
                Animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("crouch"))
            {
                crouch = false;
            } else if (Input.GetButtonUp("crouch"))
            {
                crouch = true;
            }
        }

        public void OnLanding()
        {
            Animator.SetBool("IsJumping", false);
        }

        public void OnCrouching(bool isCrouching)
        {
            Animator.SetBool("IsCrouching", isCrouching);
        }

        void FixedUpdate()
        {
            //Moves our character
            Controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, Jump);
            Jump = false;
        }
    }
}
