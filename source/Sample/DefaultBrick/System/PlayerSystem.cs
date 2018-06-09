﻿using System;
using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    public sealed class PlayerSystem : AEntitySetSystem<float>
    {
        private readonly GameWindow _window;

        public PlayerSystem(GameWindow window, World world)
            : base(world.GetEntities().With<PlayerInput>().With<DrawInfo>().Build())
        {
            _window = window;
        }

        protected override void Update(float elaspedTime, ReadOnlySpan<Entity> entities)
        {
            MouseState state = Mouse.GetState(_window);

            foreach (Entity entity in entities)
            {
                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

                drawInfo.Destination.X = MathHelper.Clamp(state.X - (drawInfo.Destination.Width / 2), 0, _window.ClientBounds.Width - drawInfo.Destination.Width);
            }
        }
    }
}