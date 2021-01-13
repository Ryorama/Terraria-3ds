using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
	public class SpriteBatch : GraphicsResource
	{
		private GraphicsDevice graphicsDevice;

		private SpriteSortMode sortMode;

		Vector2 texCoordTL = new Vector2(0, 0);
		Vector2 texCoordBR = new Vector2(0, 0);
		Rectangle tempRect = new Rectangle(0, 0, 0, 0);
		private bool beginCalled;
		private int numSprites;

		private const int MAX_SPRITES = 2048;
		private const int MAX_VERTICES = MAX_SPRITES * 4;
		private const int MAX_INDICES = MAX_SPRITES * 6;

		private static readonly float[] axisDirectionX = new float[]
		{
			-1.0f,
			1.0f,
			-1.0f,
			1.0f
		};
		private static readonly float[] axisDirectionY = new float[]
		{
			-1.0f,
			-1.0f,
			1.0f,
			1.0f
		};
		private static readonly float[] axisIsMirroredX = new float[]
		{
			0.0f,
			1.0f,
			0.0f,
			1.0f
		};
		private static readonly float[] axisIsMirroredY = new float[]
		{
			0.0f,
			0.0f,
			1.0f,
			1.0f
		};


		public SpriteBatch(GraphicsDevice graphicsDevice)
		{
			if (graphicsDevice == null)
			{
				throw new ArgumentException("graphicsDevice");
			}

			beginCalled = false;

			// TODO: Complete member initialization
			this.graphicsDevice = graphicsDevice;
		}

		public void Begin()
		{
			Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);

			if (beginCalled)
			{
				throw new InvalidOperationException(
					"Begin has been called before calling End" +
					" after the last call to Begin." +
					" Begin cannot be called again until" +
					" End has been successfully called."
				);
			}
			beginCalled = true;
		}

		public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix transformMatrix)
		{
			/*
						// defaults
						_sortMode = sortMode;
						_blendState = blendState ?? BlendState.AlphaBlend;
						_samplerState = samplerState ?? SamplerState.LinearClamp;
						_depthStencilState = depthStencilState ?? DepthStencilState.None;
						_rasterizerState = rasterizerState ?? RasterizerState.CullCounterClockwise;

						_effect = effect;

						_matrix = transformMatrix;


						if (sortMode == SpriteSortMode.Immediate) {
							//setup things now so a user can chage them
							Setup();
						}
			*/
		}

		public void Begin(SpriteSortMode sortMode, BlendState blendState)
		{
			Begin(sortMode, blendState, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);
		}

		public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState)
		{
			Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, null, Matrix.Identity);
		}

		public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect)
		{
			Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, Matrix.Identity);
		}

		internal void End()
		{
		}

		internal void Draw(Texture2D texture2D, Vector2 position, Nullable<Rectangle> source, Color color, float p, Vector2 Origin, float p_2, SpriteEffects spriteEffects, float p_3)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, source, color.ToVector4(), Origin, spriteEffects));
		}

		//TODO: Draw stretching
		internal void Draw(Texture2D texture2D, Nullable<Rectangle> source, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		//Draw texture section
		internal void Draw(Texture2D texture2D, Vector2 position, Nullable<Rectangle> source, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		//TODO:
		internal void Draw(Texture2D texture, Nullable<Rectangle> source, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effect, float depth)
		{
			/*
						if (sourceRectangle.HasValue) {
							tempRect = sourceRectangle.Value;
						} else {
							tempRect.X = 0;
							tempRect.Y = 0;
							tempRect.Width = texture.Width;
							tempRect.Height = texture.Height;				
						}

						texCoordTL.X = tempRect.X / (float)texture.Width;
						texCoordTL.Y = tempRect.Y / (float)texture.Height;
						texCoordBR.X = (tempRect.X + tempRect.Width) / (float)texture.Width;
						texCoordBR.Y = (tempRect.Y + tempRect.Height) / (float)texture.Height;

						if ((effect & SpriteEffects.FlipVertically) != 0) {
							float temp = texCoordBR.Y;
							texCoordBR.Y = texCoordTL.Y;
							texCoordTL.Y = temp;
						}
						if ((effect & SpriteEffects.FlipHorizontally) != 0) {
							float temp = texCoordBR.X;
							texCoordBR.X = texCoordTL.X;
							texCoordTL.X = temp;
						}
			*/
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		//TODO:
		internal void Draw(Texture2D texture, Nullable<Rectangle> source, Rectangle? sourceRectangle, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		internal void Draw(Texture2D texture2D, Vector2 position, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, null, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		internal void DrawString(SpriteFont font, string value, Vector2 position, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueString(new DrawStringCall(font, value, position, color.ToVector4()));
		}

		private void CheckBegin(string method)
		{
			if (!beginCalled)
			{
				throw new InvalidOperationException(
					method + " was called, but Begin has" +
					" not yet been called. Begin must be" +
					" called successfully before you can" +
					" call " + method + "."
				);
			}
		}

		public void DrawString(
			SpriteFont spriteFont,
			StringBuilder text,
			Vector2 position,
			Color color
		)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			DrawString(
				spriteFont,
				text,
				position,
				color,
				0.0f,
				Vector2.Zero,
				Vector2.One,
				SpriteEffects.None,
				0.0f
			);
		}

		public void DrawString(
			SpriteFont spriteFont,
			StringBuilder text,
			Vector2 position,
			Color color,
			float rotation,
			Vector2 origin,
			float scale,
			SpriteEffects effects,
			float layerDepth
		)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			DrawString(
				spriteFont,
				text,
				position,
				color,
				rotation,
				origin,
				new Vector2(scale),
				effects,
				layerDepth
			);
		}

		public void DrawString(
			SpriteFont spriteFont,
			StringBuilder text,
			Vector2 position,
			Color color,
			float rotation,
			Vector2 origin,
			Vector2 scale,
			SpriteEffects effects,
			float layerDepth
		)
		{
			/* FIXME: This method is a duplicate of DrawString(string)!
			 * The only difference is how we iterate through the StringBuilder.
			 * We don't use ToString() since it generates garbage.
			 * -flibit
			 */
			CheckBegin("DrawString");
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (text.Length == 0)
			{
				return;
			}
			effects &= (SpriteEffects)0x03;

			/* We pull all these internal variables in at once so
			 * anyone who wants to use this file to make their own
			 * SpriteBatch can easily replace these with reflection.
			 * -flibit
			 */
			Texture2D textureValue = spriteFont.textureValue;
			List<Rectangle> glyphData = spriteFont.glyphData;
			List<Rectangle> croppingData = spriteFont.croppingData;
			List<Vector3> kerning = spriteFont.kerning;
			Dictionary<char, int> characterIndexMap = spriteFont.characterIndexMap;

			// FIXME: This needs an accuracy check! -flibit

			// Calculate offsets/axes, using the string size for flipped text
			Vector2 baseOffset = origin;
			float axisDirX = axisDirectionX[(int)effects];
			float axisDirY = axisDirectionY[(int)effects];
			float axisDirMirrorX = 0.0f;
			float axisDirMirrorY = 0.0f;
			if (effects != SpriteEffects.None)
			{
				Vector2 size = spriteFont.MeasureString(text.ToString());
				baseOffset.X -= size.X * axisIsMirroredX[(int)effects];
				baseOffset.Y -= size.Y * axisIsMirroredY[(int)effects];
				axisDirMirrorX = axisIsMirroredX[(int)effects];
				axisDirMirrorY = axisIsMirroredY[(int)effects];
			}

			Vector2 curOffset = Vector2.Zero;
			bool firstInLine = true;
			for (int i = 0; i < text.Length; i += 1)
			{
				char c = text[i];

				// Special characters
				if (c == '\r')
				{
					continue;
				}
				if (c == '\n')
				{
					curOffset.X = 0.0f;
					curOffset.Y += spriteFont.LineSpacing;
					firstInLine = true;
					continue;
				}

				/* Get the List index from the character map, defaulting to the
				 * DefaultCharacter if it's set.
				 */
				int index;
				if (!characterIndexMap.TryGetValue(c, out index))
				{
					if (!spriteFont.DefaultCharacter.HasValue)
					{
						throw new ArgumentException(
							"Text contains characters that cannot be" +
							" resolved by this SpriteFont.",
							"text"
						);
					}
					index = characterIndexMap[spriteFont.DefaultCharacter.Value];
				}

				/* For the first character in a line, always push the width
				 * rightward, even if the kerning pushes the character to the
				 * left.
				 */
				Vector3 cKern = kerning[index];
				if (firstInLine)
				{
					curOffset.X += Math.Abs(cKern.X);
					firstInLine = false;
				}
				else
				{
					curOffset.X += spriteFont.Spacing + cKern.X;
				}

				// Calculate the character origin
				Rectangle cCrop = croppingData[index];
				Rectangle cGlyph = glyphData[index];
				float offsetX = baseOffset.X + (
					curOffset.X + cCrop.X
				) * axisDirX;
				float offsetY = baseOffset.Y + (
					curOffset.Y + cCrop.Y
				) * axisDirY;
				if (effects != SpriteEffects.None)
				{
					offsetX += cGlyph.Width * axisDirMirrorX;
					offsetY += cGlyph.Height * axisDirMirrorY;
				}

				// Draw!
				float sourceW = Math.Sign(cGlyph.Width) * Math.Max(
					Math.Abs(cGlyph.Width),
					MathHelper.MachineEpsilonFloat
				) / (float)textureValue.Width;
				float sourceH = Math.Sign(cGlyph.Height) * Math.Max(
					Math.Abs(cGlyph.Height),
					MathHelper.MachineEpsilonFloat
				) / (float)textureValue.Height;
				/* Add the character width and right-side
				 * bearing to the line width.
				 */
				curOffset.X += cKern.Y + cKern.Z;
			}
		}

		public void DrawString(
			SpriteFont spriteFont,
			string text,
			Vector2 position,
			Color color,
			float rotation,
			Vector2 origin,
			float scale,
			SpriteEffects effects,
			float layerDepth
		)
		{
			DrawString(
				spriteFont,
				text,
				position,
				color,
				rotation,
				origin,
				new Vector2(scale),
				effects,
				layerDepth
			);
		}

		public void DrawString(
			SpriteFont spriteFont,
			string text,
			Vector2 position,
			Color color,
			float rotation,
			Vector2 origin,
			Vector2 scale,
			SpriteEffects effects,
			float layerDepth
		)
		{
			/* FIXME: This method is a duplicate of DrawString(StringBuilder)!
			 * The only difference is how we iterate through the string.
			 * -flibit
			 */
			CheckBegin("DrawString");
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (text.Length == 0)
			{
				return;
			}
			effects &= (SpriteEffects)0x03;

			/* We pull all these internal variables in at once so
			 * anyone who wants to use this file to make their own
			 * SpriteBatch can easily replace these with reflection.
			 * -flibit
			 */
			Texture2D textureValue = spriteFont.textureValue;
			List<Rectangle> glyphData = spriteFont.glyphData;
			List<Rectangle> croppingData = spriteFont.croppingData;
			List<Vector3> kerning = spriteFont.kerning;
			Dictionary<char, int> characterIndexMap = spriteFont.characterIndexMap;

			// FIXME: This needs an accuracy check! -flibit

			// Calculate offsets/axes, using the string size for flipped text
			Vector2 baseOffset = origin;
			float axisDirX = axisDirectionX[(int)effects];
			float axisDirY = axisDirectionY[(int)effects];
			float axisDirMirrorX = 0.0f;
			float axisDirMirrorY = 0.0f;
			if (effects != SpriteEffects.None)
			{
				Vector2 size = spriteFont.MeasureString(text);
				baseOffset.X -= size.X * axisIsMirroredX[(int)effects];
				baseOffset.Y -= size.Y * axisIsMirroredY[(int)effects];
				axisDirMirrorX = axisIsMirroredX[(int)effects];
				axisDirMirrorY = axisIsMirroredY[(int)effects];
			}

			Vector2 curOffset = Vector2.Zero;
			bool firstInLine = true;
			foreach (char c in text)
			{
				// Special characters
				if (c == '\r')
				{
					continue;
				}
				if (c == '\n')
				{
					curOffset.X = 0.0f;
					curOffset.Y += spriteFont.LineSpacing;
					firstInLine = true;
					continue;
				}

				/* Get the List index from the character map, defaulting to the
				 * DefaultCharacter if it's set.
				 */
				int index;
				if (!characterIndexMap.TryGetValue(c, out index))
				{
					if (!spriteFont.DefaultCharacter.HasValue)
					{
						throw new ArgumentException(
							"Text contains characters that cannot be" +
							" resolved by this SpriteFont.",
							"text"
						);
					}
					index = characterIndexMap[spriteFont.DefaultCharacter.Value];
				}

				/* For the first character in a line, always push the width
				 * rightward, even if the kerning pushes the character to the
				 * left.
				 */
				Vector3 cKern = kerning[index];
				if (firstInLine)
				{
					curOffset.X += Math.Abs(cKern.X);
					firstInLine = false;
				}
				else
				{
					curOffset.X += spriteFont.Spacing + cKern.X;
				}

				// Calculate the character origin
				Rectangle cCrop = croppingData[index];
				Rectangle cGlyph = glyphData[index];
				float offsetX = baseOffset.X + (
					curOffset.X + cCrop.X
				) * axisDirX;
				float offsetY = baseOffset.Y + (
					curOffset.Y + cCrop.Y
				) * axisDirY;
				if (effects != SpriteEffects.None)
				{
					offsetX += cGlyph.Width * axisDirMirrorX;
					offsetY += cGlyph.Height * axisDirMirrorY;
				}

				// Draw!
				float sourceW = Math.Sign(cGlyph.Width) * Math.Max(
					Math.Abs(cGlyph.Width),
					MathHelper.MachineEpsilonFloat
				) / (float)textureValue.Width;
				float sourceH = Math.Sign(cGlyph.Height) * Math.Max(
					Math.Abs(cGlyph.Height),
					MathHelper.MachineEpsilonFloat
				) / (float)textureValue.Height;

				/* Add the character width and right-side
				 * bearing to the line width.
				 */
				curOffset.X += cKern.Y + cKern.Z;
			}
		}
	}
}
