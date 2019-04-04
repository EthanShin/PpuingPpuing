using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace PpuingPpuing
{
    class IScreen
    {
        static public ScreenManager m_ScreenManager;

        public virtual void Init(ContentManager content) { }
        public virtual void Init(ContentManager content, string fieldName) { }
        public virtual void Init(ContentManager content, string mapName, string stageName, IScenario scenario) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
        List<Song> m_BGMS = new List<Song>();
        public List<BGM> m_Song = new List<BGM>();
    }
}
