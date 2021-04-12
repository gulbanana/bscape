using System;
using System.Collections.Immutable;

namespace scape
{
    public class State
    {
        public Model.Game Model { get; private set; }

        public State()
        {
            Model = new Model.Game(
                ImmutableList<string>.Empty.Add("Welcome to Scape."),
                new Model.Mob("@", 40, 12),
                new Model.Mob[]
                {
                    new Model.Mob("d", 1, 21),
                    new Model.Mob("d", 4, 6),
                    new Model.Mob("d", 11, 2),
                },
                LastKey: ""
            );
        }

        public void Key(string keyCode)
        {
            var input = keyCode switch
            {
                "KeyW" or "Numpad8" or "ArrowUp"    => new Input.Move(0, +1),
                "KeyA" or "Numpad4" or "ArrowLeft"  => new Input.Move(-1, 0),
                "KeyS" or "Numpad2" or "ArrowDown"  => new Input.Move(0, -1),
                "KeyD" or "Numpad6" or "ArrowRight" => new Input.Move(+1, 0),
                "Space" or "Numpad5" => new Input.Wait(),
                _ => default(Input)
            };

            switch (input)
            {
                case Input.Wait:
                    Log("You wait.");
                    break;

                case Input.Move m:
                    Exec(new Command.MoveTo(Model.Player, Model.Player.X+m.DX, Model.Player.Y+m.DY));
                    break;
            }

            Model = Model with { LastKey = keyCode };
        }

        void Exec(Command cmd)
        {
            switch (cmd)
            {
                // XXX assumes player
                case Command.MoveTo m:
                    Model = Model with {
                        Player = Model.Player with {
                            X = Math.Clamp(m.X, 1, 78),
                            Y = Math.Clamp(m.Y, 1, 22)
                        }
                    };
                    break;
            }
        }

        void Log(string line) => Model = Model with { Log = Model.Log.Add(line) };
    }
}