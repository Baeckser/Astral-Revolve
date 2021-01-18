using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Energy_Bar : MonoBehaviour
{
    public Slider energy_Bar;

    public float maxEnergy = 100;
    public float currentEnergy;

    public WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public Coroutine regen;
    public Coroutine recharge;
    /*public enum EnergyState
    {
        IdleState, ConsumingState, RefreshState
    }
    public EnergyState state;*/

    public static Energy_Bar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energy_Bar.maxValue = maxEnergy;
        energy_Bar.value = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseEnergy(float amount)
    {
        if(currentEnergy - amount >= 5f)
        {
              currentEnergy -= amount;
              energy_Bar.value = currentEnergy;

              if (regen != null)
                  StopCoroutine(regen);

              regen = StartCoroutine(RegenEnergy());
        }
        else
        {
              currentEnergy -= amount;
              energy_Bar.value = currentEnergy;

              if (recharge != null)
                  StopCoroutine(recharge);

              recharge = StartCoroutine(RechargeEnergy());
              Debug.Log("Not enough energy");
         }

        /*if (state == EnergyState.IdleState)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = EnergyState.ConsumingState;

            }
        }
        if (state == EnergyState.ConsumingState)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                state = EnergyState.IdleState; 
            }
            if (currentEnergy <= 0)
            {
                state = EnergyState.RefreshState;

            }

            Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (speed * boost)));
            Energy_Bar.instance.UseEnergy(Time.deltaTime * 50);
        }
        if (state == EnergyState.RefreshState)
        {
            if (currentEnergy >= 100)
            {
                state = EnergyState.IdleState;

            }
            currentEnergy += maxEnergy / 25f;
            energy_Bar.value = currentEnergy;
        }*/
    }
    
    public IEnumerator RegenEnergy()
    {
            
            yield return new WaitForSeconds(1.5f);
           
        while (currentEnergy > 5f)
        {
                currentEnergy += maxEnergy / 25f;
                energy_Bar.value = currentEnergy;
                yield return regenTick;
        }
        regen = null;
    }
    public IEnumerator RechargeEnergy()
    {
            
            yield return new WaitForSeconds(3f);
            
            while (currentEnergy < 5)
            {
                Debug.Log("Recharging!");
                currentEnergy += maxEnergy / 100f;
                energy_Bar.value = currentEnergy;
                yield return regenTick;

            }
        regen = null;   
    }
     
}
