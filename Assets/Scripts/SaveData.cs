[System.Serializable]
public class SaveData
{
    public int resources;
    public int rate;
    public int level;
    public int cache;
    public bool[] mineUpgrades = new bool[9];
    public int[] unitLocal;
    public int[] weaponHealth;
    public int[] baseHealth;
}
