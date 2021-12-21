using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simple2D.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public float maxSpeed = 7;

        public Collider2D collider2d;
        public bool controlEnabled = true;

        Vector2 move;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                move.y = Input.GetAxis("Vertical");
            }
            else
            {
                move.x = 0;
                move.y = 0;
            }
            base.Update();
        }

        public void Respawn()
        {
            Teleport(new Vector2(0, 0));
            controlEnabled = true;
        }

        protected override void ComputeVelocity()
        {
            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            targetVelocity = move * maxSpeed;
        }
    }
}