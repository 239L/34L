using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(menuName = "ScriptableObjects/Interact/BoxInteract", fileName = "New Box Interact")]
public class BoxInteract : Interact
{
    [SerializeField]
    BoolValue boxTouched;

    [SerializeField] int number;


    [SerializeField] BoolValue[] numbers;

    public int Number { get => number; set => number = value; }
    public BoolValue BoxTouched { get => boxTouched; set => boxTouched = value; }

    public override BoolValue getBool()
    {
        return BoxTouched;
    }

    

    void nullifyNumbers() {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i].value = false;
        }
        SoundController.playSE(SE.PRESS6);
    }
    public override void Act()
    {
        if (!BoxTouched.value)
        {
            SoundController.playSE(SE.CLICK);
            switch (number)
            {
                case 1:
                    if (numbers.Where(e => e.value == true).Count() <= 0)
                    { //если ни один не равен тру
                        BoxTouched.value = true;

                        break;
                    }
                    else
                    {

                        nullifyNumbers(); //иначе обнуляем все булы
                        BoxTouched.value = false; //и 
                        break;
                    }
                case 2:
                    if (numbers.Where(e => e.value == true).Count() == 3) { BoxTouched.value = true; break; } else { BoxTouched.value = false; nullifyNumbers(); break; }
                case 3: if (numbers[0].value) { BoxTouched.value = true; break; } else { BoxTouched.value = false; nullifyNumbers(); break; }
                case 4: if (numbers[1].value && numbers[0].value) { BoxTouched.value = true; break; } else { BoxTouched.value = false; nullifyNumbers(); break; }
                default: nullifyNumbers(); BoxTouched.value = false; break;
            }

        }
        else { SoundController.playSE(SE.PRESS4); }

    }
}
