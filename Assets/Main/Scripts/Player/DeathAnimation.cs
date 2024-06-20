using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] Animator _animatorDeath;

    // Start is called before the first frame update
    private void Awake()
    {
        _animatorDeath.Play("Death");
    }

}
