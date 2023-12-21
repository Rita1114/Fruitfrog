using UnityEngine.UI;

[System.Serializable]
public class Mydata
{
    //game
    public string Name { get; set; }
    public string Time { get; set; }
    public string Score { get; set; }

    //UI
    public int Frequency { get; set; }

    //announcement
    public Text title { get; set; }
    public Text content { get; set; }
    public Text Version { get; set; }
}
