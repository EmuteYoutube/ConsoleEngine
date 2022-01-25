// See https://aka.ms/new-console-template for more information

List<string> data = new List<string>();
data.Add("Welcome to our game");
data.Add("    New Game");
data.Add("    Continue");
data.Add("    Exit");
string input = "";
string outputLines = "";
int posX = 0;
int posY = 1;
bool gameRunning = true;
Thread inputThread = new Thread(() => {
    while (gameRunning)
    {
        var key = Console.ReadKey(true);
        if ((key.Key == ConsoleKey.W ) && posY >0 )
            posY -= 1;

        if ((key.Key == ConsoleKey.S ) && posY < 2)
            posY += 1;
        if(key.Key == ConsoleKey.Enter)
        {
            if (posY == 0)
            {
                Console.Title = "New Game";
            }
            if (posY == 1)
            {
                Console.Title = "Continue";
            }
            if (posY == 2)
            {
                gameRunning = false;
            }
        }
    }

});
Thread drawingThread = new Thread(() => {
    while (gameRunning)
    {
        //game logic
        if(posY == 0)
        {
            data.Clear();
            data.Add("Welcome to our game");
            data.Add("  -> New Game");
            data.Add("     Continue");
            data.Add("     Exit");
        }
        else if (posY == 1)
        {
            data.Clear();
            data.Add("Welcome to our game");
            data.Add("     New Game");
            data.Add("  -> Continue");
            data.Add("     Exit");
        }

        else if (posY == 2)
        {
            data.Clear();
            data.Add("Welcome to our game");
            data.Add("     New Game");
            data.Add("     Continue");
            data.Add("  -> Exit");
        }
        //end game logic
        var currentBuffer = "";
        foreach(var line in data)
        {
            currentBuffer += (line)+"\n";
        }
        currentBuffer += "> " + input + "\n";
        if(currentBuffer != outputLines)
        {
            Console.Clear();
            Console.Write(currentBuffer);
            outputLines = currentBuffer;
        }
        Thread.Sleep(30);
    }


});

drawingThread.Start();
inputThread.Start();
