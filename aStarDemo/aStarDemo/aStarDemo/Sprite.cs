using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aStarDemo
{
    class Sprite
    {
        private Texture2D image;
        private Vector2 position;
        private Color tint;
        private Rectangle sourceRectangle;
        private float rotation;
        private Vector2 orgin;
        private Vector2 scale;
        private SpriteEffects effects;
        private float layerDepth;

        public Texture2D Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                sourceRectangle = new Rectangle(0, 0, HitBox.Width, HitBox.Height);
            }
        }

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

        public Color Tint
        {
            get
            {
                return tint;
            }
            set
            {
                tint = value;
            }
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        public Vector2 Orgin
        {
            get
            {
                return orgin;
            }
            set
            {
                orgin = value;
            }
        }

        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        public SpriteEffects Effects
        {
            get
            {
                return effects;
            }
            set
            {
                effects = value;
            }
        }

        public float Depth
        {
            get
            {
                return layerDepth;
            }
            set
            {
                layerDepth = value;
            }
        }
        
        public float ScaleF
        {
            set
            {
                scale.X = value;
                scale.Y = value;
            }
        }

        public Rectangle SourceRectangle
        {
            get
            {
                return sourceRectangle;
            }
            set
            {
                if (value.Height > HitBox.Height)
                {
                    value.Height = HitBox.Height;
                }
                if (value.Width > HitBox.Width)
                {
                    value.Width = HitBox.Width;
                }
                sourceRectangle = value;
            }
        }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)(image.Width * scale.X), (int)(image.Height * scale.Y));
            }
        }



        public Sprite(Texture2D image, Vector2 position, Color tint)
            : this(image, position, tint, 0f)
        { }
        public Sprite(Texture2D image, Vector2 position, Color tint, float rotation)
            : this(image, position, tint, rotation, Vector2.Zero)
        { }
        public Sprite(Texture2D image, Vector2 position, Color tint, float rotation, Vector2 orgin)
           : this(image, position, tint, rotation, orgin, Vector2.One)
        { }
        public Sprite(Texture2D image, Vector2 position, Color tint, float rotation, Vector2 orgin, Vector2 scale)
           : this(image, position, tint, rotation, orgin, scale, SpriteEffects.None)
        { }
        public Sprite(Texture2D image, Vector2 position, Color tint, float rotation, Vector2 orgin, Vector2 scale, SpriteEffects effects)
           : this(image, position, tint, rotation, orgin, scale, SpriteEffects.None, 0f)
        { }

        public Sprite(Texture2D image, Vector2 position, Color tint, float rotation, Vector2 orgin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.image = image;
            this.position = position;

            this.tint = tint;
            this.rotation = rotation;
            this.orgin = orgin;
            this.scale = scale;
            this.effects = effects;
            this.layerDepth = layerDepth;
            sourceRectangle = new Rectangle(0, 0, HitBox.Width, HitBox.Height);
        }
        
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, position, sourceRectangle, tint, rotation, orgin, scale, effects, layerDepth);
        }

        public void Update(GameTime gameTime)
        { 

        }
    }
}
