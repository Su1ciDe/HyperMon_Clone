using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
	private Animator animator;
	private readonly Dictionary<AnimationType, int> hashDictionary = new Dictionary<AnimationType, int>();

	private void Awake()
	{
		animator = GetComponent<Animator>();

		if (animator)
			SetupAnimationHashes();
	}

	private void SetupAnimationHashes()
	{
		var names = Enum.GetNames(typeof(AnimationType));
		var values = Enum.GetValues(typeof(AnimationType));

		for (int i = 0; i < Enum.GetNames(typeof(AnimationType)).Length; i++)
			hashDictionary.Add((AnimationType)values.GetValue(i), Animator.StringToHash(names[i]));
	}

	public void SetTrigger(AnimationType type)
	{
		animator.SetTrigger(hashDictionary[type]);
	}

	public void SetBool(AnimationType type, bool value)
	{
		animator.SetBool(hashDictionary[type], value);
	}

	public void SetInt(AnimationType type, int value)
	{
		animator.SetInteger(hashDictionary[type], value);
	}

	public void SetFloat(AnimationType type, float value)
	{
		animator.SetFloat(hashDictionary[type], value);
	}
}