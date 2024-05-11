using System;
using UnityEngine;

namespace ShaderExamples.DissolveShader.Scripts
{
    public class DistanceDissolveTest : MonoBehaviour
    {
        public Renderer renderer;
        public Transform target;
        public float dissolveRange = 1f;

        int dissolveDistanceId;
        int targetPositionId;

        void Awake()
        {
            dissolveDistanceId = Shader.PropertyToID("_DissolveDistance");
            targetPositionId = Shader.PropertyToID("_TargetPosition");
        }

        void Update()
        {
            renderer.material.SetFloat(dissolveDistanceId, dissolveRange);
            renderer.material.SetVector(targetPositionId, target.position);
        }
    }
}