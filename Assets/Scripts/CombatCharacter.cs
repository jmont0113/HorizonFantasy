using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatCharacter : MonoBehaviour
{
    public ActionTimer actionTimer;
    public Character character;
    public List<Ability> abilities;
    public bool dead;
    public Animator animator;

    AudioSource painSound;

    ParticleSystem death;

    public bool Ready
    {
        get 
        {
            return actionTimer.Ready;
        }
    }

    private void Start()
    {
        death = GetComponent<ParticleSystem>();
        painSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            animator = transform.GetChild(0).GetComponent<Animator>();
        }
        actionTimer = GetComponent<ActionTimer>();
        character = GetComponent<Character>();
        actionTimer.Init();
        abilities = new List<Ability>(character.abilities);
        character.statsContainer.Subscribe(DeathCheck, characterHPValue);
    }

    internal void TakeDamage(int damage)
    {
        //implement all possible situational conditions specific for combat, here.
        painSound.Play();
        character.TakeDamage(damage);
        DeathCheck();
        death.Play();
    }

    public Value characterHPValue;
    public void DeathCheck()
    {
        int curHp = 0;
        character.statsContainer.Get(characterHPValue, out curHp);
        dead = curHp <= 0;
        if(dead)
        {
            animator.Play("Dead");
            painSound.Play();
            death.Play();
        }
    }

    internal void Heal(int amount)
    {
        character.Heal(amount);
    }

    public void Tick(float _tick)
    {
        if(dead == true)
        {
            return;
        }

        actionTimer.Tick(_tick);
    }

    //*TODO* redo this to be more modular and independent from script
    internal float GetFillAmount(Value trackValue)
    {
        return actionTimer.GetFillAmount(trackValue);
    }

    internal void Play(string animationName)
    {
        animator.Play(animationName);
    }


}