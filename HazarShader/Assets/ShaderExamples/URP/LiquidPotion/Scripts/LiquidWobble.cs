using System;
using UnityEngine;

namespace ShaderExamples.URP.LiquidPotion.Scripts
{
    public class Timer
    {
        public float duration;
        float counter;

    }

    public class LiquidWobble : MonoBehaviour
    {
        public Renderer renderer;

        public float spring;
        public float damping;
        
        int wobbleXId;
        int wobbleZId;

        Vector3 springPos;
        Vector3 force;

        void Awake()
        {
            wobbleXId = Shader.PropertyToID("_WobbleX");
            wobbleZId = Shader.PropertyToID("_WobbleZ");
        }

        void FixedUpdate()
        {
            /*
             * spring physics Hooke's Law
             * F = -kx - bv
             */

            Vector3 currentPos = transform.position;
            Vector3 vec = currentPos - springPos;
            force += (vec * (spring) - force * damping) * Time.fixedDeltaTime;
            springPos += force;
            
            renderer.material.SetFloat(wobbleXId, -force.z);
            renderer.material.SetFloat(wobbleZId, force.x);
        }
    }
}