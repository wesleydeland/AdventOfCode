// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> text = System.IO.File.ReadAllLines(@"input.txt").ToList();
List<int> inputNumbers = text[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();
text.RemoveAt(0);

List<int[,]> arrays = new List<int[,]>();
int i = 0;
List<List<int>> grids = new List<List<int>>();
while (i < text.Count)
{
    if (!string.IsNullOrEmpty(text[i]))
    {
        List<int> rowNumbers = text[i].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToList();
        grids.Add(rowNumbers);
    }
    System.Console.WriteLine(grids.Count);
    i++;
}

decimal numGrids = Math.Ceiling(Decimal.Divide(grids.Count, 5));
System.Console.WriteLine(numGrids);
int winningNumber = -1;

foreach (int num in inputNumbers)
{
    if (winningNumber == -1)
    {
        for (int it = 0; it < numGrids; ++it)
        {
            List<List<int>> grid = grids.Skip(it * 5).Take(5).ToList();
            foreach (var row in grid)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (num == row[j])
                    {
                        row[j] = -1;
                    }
                }

                //check rows
                if (row.Sum() == -5)
                {
                    int gridsum = grid.Select(x => x.Where(y => !y.Equals(-1)).Sum()).Sum();
                    winningNumber = num;
                    Console.WriteLine("score = " + gridsum * winningNumber);
                    Console.WriteLine("row bingo " + num);
                    break;
                }
            }

            //check columns
            for (int j = 0; j < 5; j++)
            {
                var column = grid.Select(x => x[j]).ToList();

                if (column.Sum() == -5)
                {
                    winningNumber = num;
                    Console.WriteLine("column bingo " + num);
                    break;
                }

            }
        }
    }
    

}

Console.WriteLine("Winning number " + winningNumber);

