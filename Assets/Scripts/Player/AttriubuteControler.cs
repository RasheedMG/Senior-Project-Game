using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttriubuteControler : MonoBehaviour
{


    public float Max_Health {get; private set;}  //How much the player can have when fully repaired.
    public float Current_Health {get; private set;}    //How much the player can withstand before dying.
    public float Maximum_Shield { get; private set; }            //The maximum amount of shield that can be generated.
    public float Current_Shield { get; private set; }           //How much damage is mitigated before damage is dealt to the player’s health.
    public float Shield_Regeneration_Rate { get; private set; }  //How fast the shield regenerates per second.
    public float Shield_Regeneration_Delay { get; private set; } //How many seconds before the shield starts regenerating after taking damage.
    public float Armor { get; private set; }                     //How much damage is reduced before taking damage to health.
    public float Weapon_Power { get; private set; }              //The multiplier to the damage dealt by weapons.
    public float Weapon_Fire_rate { get; private set; }          //The multiplier to the firing rate of weapons.
    public float Weapon_Accuracy { get; private set; }           //The multiplier to the accuracy of weapons.
    public float Weapon_Range { get; private set; }            //The multiplier to the range of weapons.
    public float Weapon_Explosion_Radius { get; private set; }   //The multiplier to the blast radius of specific weapons.
    public float Weapon_Knockback { get; private set; }          //how much knockback the car experiences when firing weapons.
    public float Weapon_Maximum_Ammunition { get; private set; } //The multiplier to the maximum ammunition of each weapon.
    public float Weapon_Pierce { get; private set; }             //How many cars does a bullet go through.
    public float Top_Speed { get; private set; }                //The maximum speed the car can move.
    public float Acceleration { get; private set; }             //How fast the car can gain speed when continuously moving.
    public float Max_Jump_Height { get; private set; }           //How much maximum height the first jump can clear.
    public float Number_of_Jumps { get; private set; }           //How many jumps the player can do consecutively.
    public float Dodge_Cooldown { get; private set; }            //how much time the player needs to wait before being able to dodge again.
    public float Dodge_Distance { get; private set; }            //how much distance the car shifts sideways during a dodge.
    public float Car_Handling { get; private set; }              //How much friction the tires have with the ground.
    public float Collection_Range { get; private set; }          //the distance at which the car will collect items from the ground.
    public float Global_Ability_Cooldown { get; private set; }   //The multiplier to the cooldown of all abilities.
    public float Maximum_consumable { get; private set; }       //The multiplier to the maximum held amount for each consumable.
}
