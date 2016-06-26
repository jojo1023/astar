using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aStarDemo
{
    class Tile : Sprite
    {
        private TileState state = TileState.NoState;

        public TileState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public Vector2 Coord
        {
            get
            {
                return new Vector2(HitBox.X / HitBox.Width, HitBox.Y / HitBox.Height);
            }
        }
        private TextSprite textSprite;

        public string Text
        {
            get
            {
                return textSprite.Text;
            }
            set
            {
                textSprite.Text = value;
            }
        }
        public Tile(Texture2D image, Vector2 position, string text, SpriteFont font, Color color)
            : base(image, position, Color.White)
        {
            textSprite = new TextSprite(text, this.Position + new Vector2(this.HitBox.Width / 2 - font.MeasureString(text).X / 2, this.HitBox.Height / 2 - font.MeasureString(text).Y / 2), font, color);
        }
        public void Update(GameTime gameTime, bool moveStart, bool moveEnd)
        {

            if (!Game1.searching)
            {
                if (!(moveStart || moveEnd))
                {
                    if (state != TileState.StartTile && state != TileState.EndTile && state != TileState.ObstacleTile && InputManager.IsMouseMovedIntoBounds(HitBox))
                    {
                        InputManager.ResetLastMouseState();
                    }
                    if (InputManager.IsMouseClicked(HitBox) && state != TileState.StartTile && state != TileState.EndTile)
                    {
                        if (state == TileState.ObstacleTile)
                        {
                            state = TileState.NoState;
                        }
                        else if (state == TileState.NoState)
                        {
                            state = TileState.ObstacleTile;
                        }
                    }
                }
                else if (moveStart && InputManager.IsMouseDown(HitBox) && state != TileState.EndTile)
                {
                    state = TileState.StartTile;
                }
                else if (moveEnd && InputManager.IsMouseDown(HitBox) && state != TileState.StartTile)
                {
                    state = TileState.EndTile;
                }
                else if (InputManager.IsMouseReleased(HitBox))
                {
                    endMoveingStart = true;
                    endMoveingEnd = true;
                }
                else if (moveStart && state == TileState.StartTile)
                {
                    state = TileState.NoState;
                }
                else if (moveEnd && state == TileState.EndTile)
                {
                    state = TileState.NoState;
                }
            }
            SetColor();

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            textSprite.Draw(batch);
        }

        private bool endMoveingStart = false;
        private bool endMoveingEnd = false;
        public bool MoveStartTile(bool moveStart, bool moveEnd)
        {
            if (((state == TileState.StartTile && InputManager.IsMouseClicked(HitBox)) || moveStart) && !moveEnd && !endMoveingStart)
            {
                return true;
            }
            else if (endMoveingStart)
            {
                endMoveingStart = false;
            }
            return false;
        }

        public bool MoveEndTile(bool moveStart, bool moveEnd)
        {
            if (((state == TileState.EndTile && InputManager.IsMouseClicked(HitBox)) || moveEnd) && !moveStart && !endMoveingEnd)
            {
                return true;
            }
            else if (endMoveingEnd)
            {
                endMoveingEnd = false;
            }
            return false;
        }

        private void SetColor()
        {
            switch (state)
            {
                case (TileState.ObstacleTile):
                    Tint = Color.DarkSlateGray;
                    break;
                case (TileState.StartTile):
                    Tint = Color.Green;
                    break;
                case (TileState.EndTile):
                    Tint = Color.Red;
                    break;
                case (TileState.SearchedTile):
                    Tint = Color.Yellow;
                    break;
                case (TileState.PathTile):
                    Tint = Color.YellowGreen;
                    break;
                default:
                    Tint = Color.White;
                    break;
            }
        }
    }
}
