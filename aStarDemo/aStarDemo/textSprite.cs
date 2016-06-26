using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aStarDemo
{
    public class TextSprite
    {
        private string text;
        private SpriteFont font;
        private Vector2 position;
        private Color color;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        public SpriteFont Font
        {
            get
            {
                return font;
            }
        }
        public Color TextColor
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
            }
        }
        public TextSprite(string text, Vector2 position, SpriteFont font, Color color)
        {
            this.text = text;
            this.position = position;
            this.font = font;
            this.color = color;
        }
        public void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, position, color);
        }
    }
}
