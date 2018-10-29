public class Weapon
{
    public string Name { get; set; }
    public int Cost { get; set; }

    public Weapon(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return Name + " " + Cost + "$";
    }
}
