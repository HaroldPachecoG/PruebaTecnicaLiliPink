namespace PruebaTecnica.Logica.Services
{
    public class EjercicioService
    {

        public static bool ContieneNombre(string[] info, string nombre)
        {
            int filas = info.Length;
            int columnas = info[0].Length;
            char[,] matriz = new char[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                    matriz[i, j] = info[i][j];

            return BuscarEnMatriz(matriz, filas, columnas, nombre);
        }

        private static bool BuscarEnMatriz(char[,] matriz, int filas, int columnas, string palabra)
        {
            int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    foreach (var dir in Enumerable.Range(0, 8))
                    {
                        int x = i, y = j, k;
                        for (k = 0; k < palabra.Length; k++)
                        {
                            if (x < 0 || x >= filas || y < 0 || y >= columnas || matriz[x, y] != palabra[k])
                                break;
                            x += dx[dir];
                            y += dy[dir];
                        }
                        if (k == palabra.Length) return true;
                    }
                }
            }
            return false;
        }
    }
}
