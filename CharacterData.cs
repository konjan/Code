using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour {

	public Slider HealthSlider;
	public Slider StaminaSlider;

	//Health Variables
	public float CurrentHealth;
	//This would be made static, however the maximum health CAN be increased by using items.
	public int MAX_HEALTH = 100;

	//Stamina Variables
	public float CurrentStamina;
	public static int MAX_STAMINA = 100;

	//Reduc stops Stamina from being able to regen
	private bool m_bStaminaReduc = false;
	//Max ensures Stamina is at max for the time that it is active
	private bool m_bStaminaMax = false;
	//used for both the Reduc and Max timers;
	public float m_fStaminaReducTimer = 0;
	private float m_fStaminaMaxTimer = 0;
	//set to private when the right value is found.
	public float StaminaRegenMultiplier = 2;


	//Defense Value
	//This is used in the calculation of damage
	public int m_Defense;


	// Use this for initialization
	void Start ()
	{
		VariableTextCreator.Initialize();

		CurrentHealth = MAX_HEALTH;
		CurrentStamina = MAX_STAMINA;

		HealthSlider.value = SliderPercentage(CurrentHealth, MAX_HEALTH);
		StaminaSlider.value = SliderPercentage(CurrentStamina, MAX_STAMINA);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Z) && CurrentHealth != 0)
			EditHealth(-20);
		if (Input.GetKeyDown(KeyCode.X) && CurrentStamina >= 20)
			EditStamina(-20, 3);

		if (CurrentStamina < 0)
			CurrentStamina = 0;
		else if (CurrentStamina > MAX_STAMINA)
			CurrentStamina = MAX_STAMINA;

		HealthSlider.value = SliderPercentage(CurrentHealth, MAX_HEALTH);
		StaminaSlider.value = SliderPercentage(CurrentStamina, MAX_STAMINA);

		UpdateStamina();
	}

	public void EditHealth(int health)
	{
		CurrentHealth += health;
		VariableTextCreator.CreateVT(health.ToString(), transform, new Color(1, 0, 0));
	}
	public void EditStamina(int stam, float StaminaTimer)
	{
		CurrentStamina += stam;
		VariableTextCreator.CreateVT(stam.ToString(), transform, new Color(0, 0, 1));
		Mathf.Clamp(CurrentStamina, 0, MAX_STAMINA);
		m_bStaminaReduc = true;
		m_fStaminaReducTimer = StaminaTimer;
	}

	private void UpdateStamina()
	{
		if (m_bStaminaMax)
		{
			m_bStaminaReduc = false;
			m_fStaminaReducTimer = 0;
			CurrentStamina = MAX_STAMINA;

			if (m_fStaminaMaxTimer > 0)
				m_fStaminaMaxTimer -= Time.deltaTime;
			else
				m_bStaminaMax = false;
		}
		else
		{
			if (CurrentStamina < MAX_STAMINA && !m_bStaminaReduc)
			{
				CurrentStamina += Time.deltaTime * StaminaRegenMultiplier;
			}
			else if (m_bStaminaReduc)
			{
				if (m_fStaminaReducTimer > 0)
					m_fStaminaReducTimer -= Time.deltaTime;
				else
					m_bStaminaReduc = false;
			}
		}
	}

	public float SliderPercentage(float stat, float maxstat)
    {
		return stat / maxstat;
	}
}
