using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{

    public class SpriteFont : IDisposable
    {
        #region Fields
        private string fontName;
        private float size;
		private float spacing;
        private bool useKerning;
        private string style;
        internal Texture2D textureValue;
        internal List<Rectangle> glyphData;
        internal List<Rectangle> croppingData;
        internal List<Vector3> kerning;
        internal List<char> characterMap;
        internal Dictionary<char, int> characterIndexMap;


        internal int lineSpacing;
        #endregion

        #region Properties
        public string FontName
        {
            get
            {
                return this.fontName;
            }
        }

        public float Size
        {
            get
            {
                return this.size;
            }
        }
		
        public float Spacing
        {
            get
            {
                return this.spacing;
            }
        }

        public string Style
        {
            get
            {
                return this.style;
            }
        }

        public bool UseKerning
        {
            get
            {
                return this.useKerning;
            }
        }
        #endregion

        internal SpriteFont(
            Texture2D texture,
            List<Rectangle> glyphBounds,
            List<Rectangle> cropping,
            List<char> characters,
            int lineSpacing,
            float spacing,
            List<Vector3> kerningData,
            char? defaultCharacter
        )
        {
            textureValue = texture;
            glyphData = glyphBounds;
            DefaultCharacter = defaultCharacter;
            LineSpacing = lineSpacing;
            croppingData = cropping;
            kerning = kerningData;
            characterMap = characters;

            characterIndexMap = new Dictionary<char, int>(characters.Count);
            for (int i = 0; i < characters.Count; i += 1)
            {
                characterIndexMap[characters[i]] = i;
            }
        }

        public char? DefaultCharacter
        {
            get;
            set;
        }

        public int LineSpacing
        {
            get
            {
                return lineSpacing;
            }
            set
            {
                lineSpacing = value;
            }
        }

        public SpriteFont(string fontName, float size, float spacing, bool useKerning, string style)
        {
            this.fontName = fontName;
            this.size = size;
			this.spacing = spacing;
            this.useKerning = useKerning;
            this.style = style;
        }
        internal Vector2 MeasureString(string text)
        {			
			
			UnityEngine.GUISkin skin = UnityEngine.GUISkin.CreateInstance<UnityEngine.GUISkin>();
			
			UnityEngine.Vector2 size = skin.label.CalcSize(new UnityEngine.GUIContent(text));
			return new Vector2(size.x, size.y);
        }
        public void Dispose()
        { }
    }
}
