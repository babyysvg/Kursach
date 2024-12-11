using Kursach;

public class Vhod
{
    public int id { get; set; }
    public double Kd { get; set; }
    public int Kr { get; set; }
    public int sigmaHP { get; set; }
    public float u { get; set; }
    public int T1 { get; set; }
    public float Shir { get; set; }
    public float Kbe { get; set; }
    public float Khb { get; set; }
    public string opora { get; set; }
    public string hardness { get; set; }
    public string typeshi { get; set; }

    // Связь с Vyhod
    public Vyhod vyhod { get; set; }
}
