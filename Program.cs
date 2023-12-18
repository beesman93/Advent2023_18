using static System.Globalization.NumberStyles;
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
        string s = part2?ls[2][7..8]:ls[0];
        string val = part2?ls[2][2..7]:ls[1];
        (long x, long y) dir = s switch
        {
            "U" or "3" => (-1, 0),
            "D" or "1" => (1, 0),
            "L" or "2" => (0, -1),
            "R" or "0" => (0, 1),
        };
        long len = long.Parse(val, part2?HexNumber:Integer);
        pathLen += len;
        var prev = coord;
        coord = (coord.x+dir.x*len,coord.y+dir.y*len);
        areaDoubled += (prev.x * coord.y) - (coord.x * prev.y);
    }
    Console.WriteLine($"Part{(part2?2:1)}:\t {((Math.Abs(areaDoubled) / 2.0) + (pathLen / 2.0)) + 1}");
}