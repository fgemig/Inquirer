﻿namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string _answer;
        public Input(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
        }

        public override string Answer()
        {
            return _answer;
        }

        public override void Ask()
        {
            int[] pos = null;
            do
            {
                if(pos != null)
                    consoleRender.Clean(0, pos[0]);

                pos = RenderNew();

                _answer = GetUserAnswer();

            } while (!IsValidAnswer(_answer));
            
            consoleRender.Newline();
        }
        
        protected virtual string GetUserAnswer()
        {
           return consoleRender.ReadLine();
        }

        public override string[] GetQuestion()
        {
            return new[] { message };
        }

        public override int[,] Render()
        {
            return consoleRender.RenderMultipleMessages(GetQuestion());
        }
        
        public int[] RenderNew()
        {
            return consoleRender.Render(GetQuestion(), new string[]{});
        }
    }
}
