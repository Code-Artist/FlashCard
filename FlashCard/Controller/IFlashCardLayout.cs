using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCard
{
    internal interface IFlashCardLayout
    {
        FlashCardController Controller { get; set; }
        void InitializeControls();
        void GetNextCard();
        void KeyPressed(object sender, char key);
        void Close();
    }
}
