using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] string charName = "charName";
    [SerializeField] float charCurrHP = 30f;
    [SerializeField] float charMaxHP = 30f;
    [SerializeField] float charCurrMP = 10f;
    [SerializeField] float charMaxMP = 10f;
    // [SerializeField] float charStr = 2f;
    // [SerializeField] float charDef = 2f;
    // [SerializeField] float charInt = 2f;
    // [SerializeField] float charSpd = 2f;
    // [SerializeField] float charWil = 2f;
    // [SerializeField] float charCon = 2f;
    // [SerializeField] float charLck = 2f;
    // [SerializeField] float charEXP = 0f;
    // [SerializeField] int charLvl = 1;

    [SerializeField] public TMP_Text txt_charName;
    [SerializeField] public TMP_Text txt_charCurrHP;
    [SerializeField] public TMP_Text txt_charCurrMP;
    [SerializeField] public TMP_Text txt_charMaxHP;
    [SerializeField] public TMP_Text txt_charMaxMP;
    // [SerializeField] public TMP_Text txt_charStr;
    // [SerializeField] public TMP_Text txt_charDef;
    // [SerializeField] public TMP_Text txt_charInt;
    // [SerializeField] public TMP_Text txt_charSpd;
    // [SerializeField] public TMP_Text txt_charWil;
    // [SerializeField] public TMP_Text txt_charCon;
    // [SerializeField] public TMP_Text txt_charLck;
    // [SerializeField] public TMP_Text txt_charEXP;
    // [SerializeField] public TMP_Text txt_charLvl;

    // Start is called before the first frame update
    void Start()
    {
        txt_charName.SetText(charName);
        txt_charCurrHP.SetText(charCurrHP.ToString());
        txt_charCurrMP.SetText(charCurrMP.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
