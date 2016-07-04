using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace aStarDemo
{
    class TileGraph : Graph<Vector2>
    {
        public TileGraph(int rows, int collums)
            : base()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int ii = 0; ii < collums; ii++)
                {
                    Verties.Add(new Node<Vector2>(new Vector2(i, ii)));
                    if (GetNode(new Vector2(i - 1, ii - 1)) != null)
                    {
                        this.AddEdge(GetNode(new Vector2(i, ii)), GetNode(new Vector2(i - 1, ii - 1)), true);
                    }
                    if (GetNode(new Vector2(i, ii - 1)) != null)
                    {
                        this.AddEdge(GetNode(new Vector2(i, ii)), GetNode(new Vector2(i, ii - 1)), false);
                    }
                    if (GetNode(new Vector2(i - 1, ii)) != null)
                    {
                        this.AddEdge(GetNode(new Vector2(i, ii)), GetNode(new Vector2(i - 1, ii)), false);
                    }
                    if (collums - 1 > ii && i > 0)
                    {
                        this.AddEdge(GetNode(new Vector2(i, ii)), GetNode(new Vector2(i - 1, ii + 1)), true);
                    }

                }
            }
        }

        public Node<Vector2> GetNode(Vector2 value)
        {
            for (int i = 0; i < Verties.Count; i++)
            {
                if (Verties[i].Value == value)
                {
                    return Verties[i];
                }
            }
            return null;
        }
        public List<Tile> GetTileNeighbors(Tile[,] tiles, Vector2 index)
        {
            Vector2 temp;
            if (GetNode(index) != null)
            {
                List<Tile> returnList = new List<Tile>();
                for (int i = 0; i < GetNode(index).Neighbors.Count; i++)
                {
                    temp = GetNode(index).Neighbors[i].Value;
                    returnList.Add(tiles[(int)temp.X, (int)temp.Y]);
                }
                return returnList;
            }
            return new List<Tile>();
        }

        public void Search(Tile[,] tiles)
        {
            Game1.searching = true;
            //dfsSearch(tiles, GetStartCord(tiles));

            Vector2 start = GetStartCord(tiles);
            queue = new Queue<Tile>();
            queue.Enqueue(tiles[(int)start.X, (int)start.Y]);
            bfsSearch(tiles);

            //Game1.searching = false;
        }
        private Queue<Tile> queue;
        public void bfsSearch(Tile[,] tiles)
        {
            if (queue.Count > 0)
            {
                Tile current = queue.Dequeue();
                List<Tile> currentNeighbors = GetTileNeighbors(tiles, current.Coord);
                for (int i = 0; i < currentNeighbors.Count; i++)
                {
                    if (currentNeighbors[i].State == TileState.NoState)
                    {
                        queue.Enqueue(currentNeighbors[i]);
                        currentNeighbors[i].State = TileState.SearchedTile;
                    }
                    
                }
                
            }
        }
        public bool dfsSearch(Tile[,] tiles, Vector2 current)
        {

            Vector2 testEnd = GetEndCord(tiles);
            List<Tile> currentNeighbors = this.GetTileNeighbors(tiles, current);
            if (current == GetEndCord(tiles))
            {
                tiles[(int)current.X, (int)current.Y].State = TileState.PathTile;
                return true;
            }
            for (int i = 0; i < currentNeighbors.Count; i++)
            {
                if (currentNeighbors[i].State == TileState.EndTile)
                {
                    return true;
                }
                else if (currentNeighbors[i].State == TileState.NoState)
                {
                    currentNeighbors[i].State = TileState.SearchedTile;
                    bool test = dfsSearch(tiles, currentNeighbors[i].Coord);
                    if (!test)
                    {
                        return false;
                    }
                    else
                    {
                        currentNeighbors[i].State = TileState.PathTile;
                        return true;
                    }
                }
                
            }
            return false;
        }


        public Vector2 GetStartCord(Tile[,] tiles)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int ii = 0; ii < tiles.GetLength(1); ii++)
                {
                    if (tiles[i, ii].State == TileState.StartTile)
                    {
                        return new Vector2(i, ii);
                    }
                }
            }
            return Vector2.Zero;
        }

        public Vector2 GetEndCord(Tile[,] tiles)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int ii = 0; ii < tiles.GetLength(1); ii++)
                {
                    if (tiles[i, ii].State == TileState.EndTile)
                    {
                        return new Vector2(i, ii);
                    }
                }
            }
            return Vector2.Zero;
        }

        public float getG(Tile startTile, Tile endTile, Tile currentTile)
        {
            return 0;//make this work
        }
        public float getH(Tile startTile, Tile endTile, Tile currentTile)
        {
            return 0;//make this work
        }
        public float getCost(Tile startTile, Tile endTile, Tile currentTile)
        {
            return getG(startTile, endTile, currentTile) + getH(startTile, endTile, currentTile);
        }
        
    }
}


