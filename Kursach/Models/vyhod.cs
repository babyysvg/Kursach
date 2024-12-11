using System.ComponentModel.DataAnnotations.Schema;

public class Vyhod
{
    public int ID { get; set; }
    public float Re { get; set; }

    // Внешний ключ для Vhod
    [ForeignKey("Vhod")]
    public int VhodId { get; set; }
    public Vhod vhod { get; set; }
}
