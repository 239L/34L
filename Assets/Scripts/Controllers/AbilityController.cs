using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.Controllers
{
    public class AbilityController : MonoBehaviour
    {
        [SerializeField]
        PlayerAbility ability;
        [SerializeField]
        BarController bar;
        float cooldown;
        float active = 0f;
        [SerializeField]
        StateController player;
        [SerializeField]
        KeyCode key;
        enum AbilityState
        {
            wait,
            active,
            cooldown
        }

        AbilityState aS = AbilityState.wait;
        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {
            switch (aS)
            {
                case AbilityState.wait:
                    if (bar.getFinished())
                    {
                        bar.Activate(cooldown / ability.cooldown, false);
                    }
                    if (active < ability.active && active != 0) { active = active + Time.deltaTime / 4; }
                    if (Input.GetKey(key) && player.getState() == State.move)
                    {
                        if (active == 0f) { active = ability.active; }

                        aS = AbilityState.active;

                        ability.Activate();
                    }

                    break;
                case AbilityState.active:

                    if (active > 0)
                    {
                        if (Input.GetKey(key) && player.getState() == State.run)
                        {
                            active -= Time.deltaTime;

                        }
                        else
                        {
                            aS = AbilityState.wait;
                            cooldown = 0;
                            ability.Deactivate();
                        }
                    }
                    else
                    {
                        aS = AbilityState.cooldown;
                        cooldown = ability.cooldown;
                        active = ability.active;
                        ability.Deactivate();
                    }
                    break;
                case AbilityState.cooldown:
                    if (cooldown > 0)
                    {
                        cooldown -= Time.deltaTime;
                        bar.Activate(cooldown / ability.cooldown, true);
                    }
                    else
                    {
                        aS = AbilityState.wait;


                    }
                    break;
            }
        }
    }
}