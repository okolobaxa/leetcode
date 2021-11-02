using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace leetcode
{
    /// https://leetcode.com/problems/surrounded-regions/
    public class SurroundedRegionsProblem
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SurroundedRegionsProblem(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SurroundedRegionsTest1()
        {
            var board = new char[][]
            {
                new char[] {'X','X','X','X'},
                new char[] {'X','O','O','X'},
                new char[] {'X','X','O','X'},
                new char[] {'X','O','X','X'},
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X','X','X','X'},
                new char[] {'X','X','X','X'},
                new char[] {'X','X','X','X'},
                new char[] {'X','O','X','X'},
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest2()
        {
            var board = new char[][]
            {
                new char[] {'X'},
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X'},
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest3()
        {
            var board = new char[][]
            {
                new char[] {'X','X','X','X'},
                new char[] {'X','O','O','X'}
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X','X','X','X'},
                new char[] {'X','O','O','X'}
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest4()
        {
            var board = new char[][]
            {
                new char[] {'X','X'},
                new char[] {'X','O'},
                new char[] {'X','X'},
                new char[] {'X','O'},
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X','X'},
                new char[] {'X','O'},
                new char[] {'X','X'},
                new char[] {'X','O'},
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest5()
        {
            var board = new char[][]
            {
                new char[] {'O','X','X','O','X'},
                new char[] {'X','O','O','X','O'},
                new char[] {'X','O','X','O','X'},
                new char[] {'O','X','O','O','O'},
                new char[] {'X','X','O','X','O'}
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'O','X','X','O','X'},
                new char[] {'X','X','X','X','O'},
                new char[] {'X','X','X','O','X'},
                new char[] {'O','X','O','O','O'},
                new char[] {'X','X','O','X','O'}
            };

            Assert.Equal(result, board);
        }


        [Fact]
        public void SurroundedRegionsTest6()
        {
            var board = new char[][]
            {
                new char[] {'O','O','O'},
                new char[] {'O','O','O'},
                new char[] {'O','O','O'},
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'O','O','O'},
                new char[] {'O','O','O'},
                new char[] {'O','O','O'},
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest7()
        {
            var board = new char[][]
            {
                new char[] {'X','O','X'},
                new char[] {'X','O','X'},
                new char[] {'X','O','X'},
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X','O','X'},
                new char[] {'X','O','X'},
                new char[] {'X','O','X'},
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest8()
        {
            var board = new char[][]
            {
                new char[] {'X','O','X','O','O','O','O'},
                new char[] {'X','O','O','O','O','O','O'},
                new char[] {'X','O','O','O','O','X','O'},
                new char[] {'O','O','O','O','X','O','X'},
                new char[] {'O','X','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O'},
                new char[] {'O','X','O','O','O','O','O'}
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'X','O','X','O','O','O','O'},
                new char[] {'X','O','O','O','O','O','O'},
                new char[] {'X','O','O','O','O','X','O'},
                new char[] {'O','O','O','O','X','O','X'},
                new char[] {'O','X','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O'},
                new char[] {'O','X','O','O','O','O','O'}
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest9()
        {
            var board = new char[][]
            {
                new char[] {'O','X','O','O','O','X'},
                new char[] {'O','O','X','X','X','O'},
                new char[] {'X','X','X','X','X','O'},
                new char[] {'O','O','O','O','X','X'},
                new char[] {'X','X','O','O','X','O'},
                new char[] {'O','O','X','X','X','X'}
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[] {'O','X','O','O','O','X'},
                new char[] {'O','O','X','X','X','O'},
                new char[] {'X','X','X','X','X','O'},
                new char[] {'O','O','O','O','X','X'},
                new char[] {'X','X','O','O','X','O'},
                new char[] {'O','O','X','X','X','X'}
            };

            Assert.Equal(result, board);
        }

        [Fact]
        public void SurroundedRegionsTest10()
        {
            var board = new char[][]
            {
                new char[]{'X','X','X','X','O','O','X','X','O'},
                new char[]{'O','O','O','O','X','X','O','O','X'},
                new char[]{'X','O','X','O','O','X','X','O','X'},
                new char[]{'O','O','X','X','X','O','O','O','O'},
                new char[]{'X','O','O','X','X','X','X','X','O'},
                new char[]{'O','O','X','O','X','O','X','O','X'},
                new char[]{'O','O','O','X','X','O','X','O','X'},
                new char[]{'O','O','O','X','O','O','O','X','O'},
                new char[]{'O','X','O','O','O','X','O','X','O'}
            };

            Solve(board);
            Log(board);

            var result = new char[][]
            {
                new char[]{'X','X','X','X','O','O','X','X','O'},
                new char[]{'O','O','O','O','X','X','O','O','X'},
                new char[]{'X','O','X','O','O','X','X','O','X'},
                new char[]{'O','O','X','X','X','O','O','O','O'},
                new char[]{'X','O','O','X','X','X','X','X','O'},
                new char[]{'O','O','X','X','X','O','X','X','X'},
                new char[]{'O','O','O','X','X','O','X','X','X'},
                new char[]{'O','O','O','X','O','O','O','X','O'},
                new char[]{'O','X','O','O','O','X','O','X','O'}
            };

            Assert.Equal(result, board);
        }

        private void Log(char[][] board)
        {
            _testOutputHelper.WriteLine("");
            foreach (var line in board)
            {
                _testOutputHelper.WriteLine(string.Join("", line));
            }

            Assert.True(true);
        }

        public void Solve(char[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;

            if (m < 3 || n < 3) return;

            MarkBorders(board, m, n);
            DeMark(board);
        }

        public void MarkBorders(char[][] board, int m, int n)
        {
            for (var i = 0; i < m; i++)
            {
                if (board[i][0] == 'O')
                {
                    Travers(board, m, n, i, 0);
                }

                if (board[i][n - 1] == 'O')
                {
                    Travers(board, m, n, i, n - 1);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (board[0][i] == 'O')
                {
                    Travers(board, m, n, 0, i);
                }

                if (board[m - 1][i] == 'O')
                {
                    Travers(board, m, n, m - 1, i);
                }
            }
        }

        private bool IsValid(int m, int n, int i, int j) => i >= 0 && j >= 0 && i < m && j < n;

        private void Travers(char[][] board, int m, int n, int i, int j)
        {
            board[i][j] = '@';

            if (IsValid(m, n, i, j + 1) && board[i][j + 1] == 'O')
            {
                Travers(board, m, n, i, j + 1);
            }

            if (IsValid(m, n, i + 1, j) && board[i + 1][j] == 'O')
            {
                Travers(board, m, n, i + 1, j);
            }

            if (IsValid(m, n, i, j - 1) && board[i][j - 1] == 'O')
            {
                Travers(board, m, n, i, j - 1);
            }

            if (IsValid(m, n, i - 1, j) && board[i - 1][j] == 'O')
            {
                Travers(board, m, n, i - 1, j);
            }
        }

        public void DeMark(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '@')
                    {
                        board[i][j] = 'O';
                    }
                    else
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }
    }
}
