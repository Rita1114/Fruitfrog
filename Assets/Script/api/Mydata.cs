using UnityEngine.UI;

[System.Serializable]
public class Mydata
{
    /* //game
     public string Name;
     public string Time;
     public string Score;

     //UI
     public int Frequency;

     //announcement
     public Text title;
     public Text content;
     public Text Version;*/

    public string id { get; set; }
    public string uid { get; set; }
    public int account_number { get; set; }
    public string iban { get; set; }
    public string bank_name { get; set; }

    public int routing_number { get; set; }
    public int swift_bic { get; set; }
}
