using System.Globalization;

List<string> lines = new();
using (StreamReader reader = new(args[0]))
    while (!reader.EndOfStream)
        lines.Add(reader.ReadLine() ?? "");


new List<bool>() { false, true }.ForEach(b => solve(b));
void solve(bool part2)
{
    long areaDoubled = 0;
    long pathLen = 0;
    (long x, long y) coord = (0, 0);
    foreach (string line in lines.Skip(0))
    {
        var ls = line.Split(' ');
        
        string s = ls[0];
        string val = part2?ls[2][2..7]:ls[1];
        string dirdir = ls[2][7..8];

        if (part2) s = dirdir switch
        {
            "3" => "U",
            "1" => "D",
            "2" => "L",
            "0" => "R",
        };
        (long x, long y) dir = s switch
        {
            "U" => (-1, 0),
            "D" => (1, 0),
            "L" => (0, -1),
            "R" => (0, 1),
        };

        long len = long.Parse(val, part2?NumberStyles.HexNumber:NumberStyles.Integer);

        dir = (dir.x * len, dir.y * len);
        var prev = coord;
        coord = (coord.x + dir.x, coord.y + dir.y);

        areaDoubled += (prev.x * coord.y) - (coord.x * prev.y);
        pathLen += len;
    }
    Console.WriteLine($"Part{(part2?2:1)}:\t {((Math.Abs(areaDoubled) / 2.0) + (pathLen / 2.0)) + 1}");
}