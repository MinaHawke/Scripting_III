using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
    public string m_playerName;
    public float  m_gold;
    public float  m_wood;
    public float  m_iron;
    public float  m_stone;
    public int    m_victoryPoints;
    public int    m_battlePoints;
    
    public List<Card> m_cardList;
	public List<Item> m_itemList;
}
