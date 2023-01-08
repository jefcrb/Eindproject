using Eindproject.Components.Enemies;
using Eindproject.Components.HeroComponents;
using Eindproject.Components.HeroComponents.Physics;
using Eindproject.Components.LevelDesign;
using Eindproject.Input;
using Eindproject.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Eindproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D archer_texture;
        private Texture2D bow_texture;
        private Texture2D arrow_texture;
        private Texture2D enemyGround_texture;
        private Texture2D enemyGround2_texture;
        private Texture2D enemyAir_texture;
        private Texture2D tilemap_texture;
        private Texture2D background;
        private SpriteFont font;

        private Archer archer;
        private EnemyHandler enemyHandler;
        private MenuHandler menuHandler;
        private BlockGenerator blockGen;
        private EnemyGenerator enemyGen;

        private int difficulty = 1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic 
            base.Initialize();
            archer = new Archer(archer_texture, bow_texture, arrow_texture, new KeyboardReader());
            blockGen = new BlockGenerator(tilemap_texture);
            menuHandler = new MenuHandler(new Dictionary<string, Menu>()
            {
                { "StartMenu", new StartMenu(font, new KeyboardReader()) },
                { "GameOverMenu", new GameOverMenu(font, new KeyboardReader()) },
                { "VictoryMenu", new VictoryMenu(font, new KeyboardReader()) }
            });

            enemyHandler = new EnemyHandler();
            NextLevel();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            archer_texture = Content.Load<Texture2D>("cat_sprite");
            bow_texture = Content.Load<Texture2D>("bow_sprite");
            enemyGround_texture = Content.Load<Texture2D>("enemy_ground");
            enemyGround2_texture = Content.Load<Texture2D>("enemy_ground2");
            enemyAir_texture = Content.Load<Texture2D>("enemy_air");
            tilemap_texture = Content.Load<Texture2D>("tilemap");
            background = Content.Load<Texture2D>("background");
            font = Content.Load<SpriteFont>("font");
            arrow_texture = new Texture2D(GraphicsDevice, 1, 1);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !GameMaster.HasStarted)
                GameMaster.HasStarted = true;

            // TODO: Add your update logic here
            archer.Update(gameTime);
            menuHandler.Update(gameTime);

            if (GameMaster.IsPaused && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                NextLevel();
                GameMaster.HasStarted = true;
            }

            if (GameMaster.GameOver || !GameMaster.HasStarted || GameMaster.HasWon || GameMaster.IsPaused)
                return;

            enemyHandler.Update(gameTime);
            CollisionDetection.Detect();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(background, new Rectangle(0, 0, 928, 500), Color.White);

            archer.Draw(_spriteBatch);
            enemyHandler.Draw(_spriteBatch);
            blockGen.Draw(_spriteBatch);
            menuHandler.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void NextLevel()
        {
            enemyGen = new EnemyGenerator(new List<Texture2D>()
            {
                enemyGround_texture,
                enemyGround2_texture,
                enemyAir_texture
            }, GameMaster.LevelCount);

            enemyHandler.AddEnemies(enemyGen.Generate());
        }
    }
}