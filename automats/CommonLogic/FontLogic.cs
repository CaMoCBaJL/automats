namespace CommonLogic
{
    public class FontLogic
    {
        public const double widthScaleCoef = 1;

        public const double heightScaleCoef = 1.5;

        public const int columnWidth = 60;

        const int maxWidth = 20;

        const int maxHeight = 30;

        static int letterWidth = maxWidth / 2;

        static int letterHeight = 2*maxHeight / 3;


        public static void ReduceLetterWidth()
        {
            if (letterWidth > 1)
                letterWidth--;
        }

        public static void ReduceLetterHeight()
        {
            if (letterHeight > 2)
                letterHeight--;
        }

        public static void EnlargeLetterWidth()
        {
            if (letterWidth < maxWidth)
                letterWidth++;
        }

        public static void EnlargeLetterHeight()
        {
            if (letterHeight < maxHeight)
                letterWidth += 2;
        }

        public static int LetterWidth => letterWidth;

        public static int LetterHeight => letterHeight;
    }
}