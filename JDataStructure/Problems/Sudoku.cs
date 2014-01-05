using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.Problems
{
    public class Sudoku
    {
        int SIZE = 9;
        public Sudoku()
        {
        }

        public int[,] Solve(int[,] grid)
        {
            //dictionary store all the possible moves
            Dictionary<int, List<int>> _dict = new Dictionary<int, List<int>>();
            List<int> _defaultList = new List<int>();

            //init _dict
            for (int i = 1; i <= SIZE * SIZE; i++)
            {
                _dict.Add(i, null);
            }
            //init _defaultList to ignore default position
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    if (grid[i, j] > 0)
                        _defaultList.Add(GetId(i, j));     

            //analyze priority squares
            List<int> pSquare = GetPriorityIDs(grid);

            int idx = 0;
            int id = pSquare[idx];
            
            while (_defaultList.Contains(id))
                idx++;
            long times = 0;
            while (idx < 81)
            {
                times++;
                id = pSquare[idx];

                int[] pos = GetPos(id);
                int row = pos[0]; 
                int col = pos[1];
                
                if (_dict[id] == null) 
                    _dict[id] = GetPossibleNumbers(grid, row, col);
                List<int> pList = _dict[id];

                //backtrack
                if (pList.Count == 0)
                {
                    //Console.WriteLine("id={0} - row {1} col {2}", id, row, col);
                    //Show(grid);
                    //Console.ReadLine();
                    _dict[id] = null;

                    idx--;
                    while (_defaultList.Contains(pSquare[idx]))
                        idx--;
                    id = pSquare[idx];

                    int[] prevPos = GetPos(id);
                    int invalidNu = grid[prevPos[0], prevPos[1]];

                    if (_dict[id].Contains(invalidNu))
                        _dict[id].Remove(invalidNu);
                    grid[row, col] = 0;
                }
                else
                {
                    //Console.WriteLine("id={0} - row {1} col {2}", id, row, col);
                    //Show(grid);
                    //Console.ReadLine();
                    //assize random number:
                    Random rand = new Random();
                    grid[row, col] = pList[rand.Next(0, pList.Count)];
                    //grid[row, col] = pList[0];
                    idx++;

                    if (idx < pSquare.Count)
                    {
                        while (_defaultList.Contains(pSquare[idx]))
                        {
                            idx++;
                            if (idx >= pSquare.Count)
                                break;
                        }
                    }
                }
            }

            Show(grid);
            Console.WriteLine("times:{0}", times);
            return grid;
        }

        private int[] GetPos(int id)
        {
            int row = (int)(id / SIZE);

            if (id == row * SIZE)
                row--;

            int col = (id - 1) % SIZE;
            return new int[] { row, col};
        }

        private int GetId(int row, int col)
        {
            return SIZE * row + col + 1;
        }

        private List<int> GetPriorityIDs(int[,] grid)
        {
            List<int> result = new List<int>();

            //dictionary stores square id and no of possible case
            Dictionary<int, int> iDict = new Dictionary<int, int>();
            for (int id = 1; id <= 81; id++)
            {
                int[] pos = GetPos(id);
                int tr = pos[0];
                int tc = pos[1];

                List<int> tmp = GetPossibleNumbers(grid, tr, tc);
                iDict.Add(id, tmp.Count);
                result.Add(id);
            }

            //sort bubble will do
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    int k = result[j];
                    int k1 = result[j + 1];
                    if (iDict[k] > iDict[k1])
                    {
                        int tmp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = tmp;
                    }
                }
            }

            foreach (int tmp in result)
            {
                Console.WriteLine("id:{0} cnt:{1}", tmp, iDict[tmp]);
            }
            return result;
        }

        private List<int> GetPossibleNumbers(int[,] grid, int row, int col)
        {
            List<int> ls = GetL();

            for (int i = 0; i < SIZE; i++)
            {
                if (i != col)
                {
                    if (ls.Contains(grid[row, i]))
                        ls.Remove(grid[row, i]);
                }       
            }

            for (int j = 0; j < SIZE; j++)
            {
                if (j != row)
                {
                    if (ls.Contains(grid[j, col]))
                        ls.Remove(grid[j, col]);
                }
            }

            int id = GetId(row, col);
            List<int> zones = GetZones(id);
            foreach (int i in zones)
            {
                if (i == id) continue;

                int[] pos = GetPos(i);
                int tmp = grid[pos[0], pos[1]];

                if (tmp > 0)
                {
                    if (ls.Contains(tmp))
                        ls.Remove(tmp);
                }
            }


            return ls;
        }

        private List<int> GetZones(int id)
        {
            List<int> result = new List<int>();

            int[] pos = GetPos(id);
            int row = pos[0] % 3;
            int col = pos[1] % 3;

            int rootId = id - col - 9 * row;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.Add(rootId + j + 9 * i);
                }
            }
            return result;
        }

        private List<int> GetL()
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= SIZE; i++)
                result.Add(i);
            return result;
        }

        private void ShowList(List<int> ls)
        {
            foreach (int i in ls)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        public void Show(int[,] grid)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write("{0} ", grid[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
