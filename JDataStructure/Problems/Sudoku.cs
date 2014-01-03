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

            int id = 1;
            while (_defaultList.Contains(id))
                id++;

            while (id <= 81)
            {
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

                    id--;
                    while (_defaultList.Contains(id))
                        id--;

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
                    grid[row, col] = pList[0];
                    id++;

                    while (_defaultList.Contains(id))
                        id++;
                }

                //founnd a solution
            }

            Show(grid);
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

            return ls;
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
