public struct SeatLocation
{
    public char Row { get; set; }
    public int Number { get; set; }

    public SeatLocation(char row, int number)
    {
        Row = row;
        Number = number;
    }

    public override string ToString()
    {
        return $"{Row}-{Number}";
    }
}