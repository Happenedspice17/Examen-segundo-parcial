/* Descubre el mensaje secreto que se encuentra en la carpeta comprimida que se te haya asignado. 
   Recuerda que deberás indicar la posición en la que se encuentra oculto cada caracter. 
   Esto es, indicar la fila, columna, y número de caracter en donde se encuentra el caracter oculto.
   Indica la carpeta que te toco responder a continuación (15 pts):
*/

// La ubicación del folder en tu computadora
string path = @"I:/Mi unidad/1 Semestre/Análisis/Mensaje_secreto_2/";
// Un arreglo de string que almacena el resultado de cada letra diferente
string[] result = new string[80];
string resultComplete = "";

static string resultOfAllTexts(string path, string[] result, string resultComplete)
{
    Console.WriteLine("Procesando el resultado...\n");

    for (int numOfTxt = 1; numOfTxt < result.Length; numOfTxt++)
    {
        string filename = "letra_" + numOfTxt + ".txt";
        string[] lines = File.ReadAllLines(path + filename);

        for (int fila = 0; fila < lines.Length; fila++)
        {

            for (int col = 0; col < lines[fila].Length; col++)
            {
                // linea 650 col 372 esta la T
                // linea 550 col 758 esta la h
                char currentChar = lines[fila][col];
                bool foundChar = IsDifferentChar(lines, fila, col, currentChar);
                if (foundChar == true)
                {
                    result[numOfTxt - 1] += currentChar;
                    // Para probar que onda de donde esta exactamente en la columna segun el archivo de texto Console.WriteLine(col + 2);
                    // Para probar donnde esta en la fila y ponerlo en el print Console.WriteLine(fila + 1);
                    Console.WriteLine("Fila: " + (fila + 1) + "  Columna: " + (col + 2) + "  letra: " + result[numOfTxt - 1]);
                }
            }
        }
    }

    foreach (var item in result)
    {
        resultComplete += item;
    }

    return resultComplete;
}


// Function to check if a character is different in the same position of other lines.
static bool IsDifferentChar(string[] lines, int fila, int col, char currentChar)
{
    bool condition = false;
    foreach (string line in lines)
    {
        if (line[col] != currentChar)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
    }
    return condition;
}

resultOfAllTexts(path, result, resultComplete);

