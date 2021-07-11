using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColoredBlock", menuName = "GameData/Create/ColoredBlockData")]
public class ColoredBlock : BlockData
{
    public List<Sprite> LayerSprites;
    public List<Sprite> BaseSprites;
    public Color BaseColor;
    public int Score;
}
