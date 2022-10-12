[System.Serializable]
public class SaveData
{
    public int resources;
    public int rate;
    public int level;
    public int cache;
    public bool[] mineUpgrades = new bool[9];
    public bool[] isOccupied = new bool[40];
    public int[] unitType = new int[40];
    public float[] weaponHealth = new float[40];
    public int[] baseHealth;
}
